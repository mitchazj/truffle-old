using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blacksink.Blackboard
{
    public static class Script
    {
        /// <summary>
        /// Returns a vanilla JS script customized to the user's username and password.
        /// This script can be injected into almost any Blackboard page - it will automatically figure out what to do.
        /// </summary>
        /// <param name="username">The user's student number</param>
        /// <param name="password">The user's password</param>
        /// <returns>One script to rule them all</returns>
        public static string getScript(string username, string password) {
            string template_str = @"
                function e(id) {
                    var to_return = document.querySelectorAll(id);
                    return (to_return.length == 1) ? to_return[0] : to_return;
                }
                String.prototype.contains = function(q) { return this.indexOf(q) != -1; }

                var USERNAME = '[USERNAME GOES HERE]', PASSWORD = '[PASSWORD GOES HERE]';

                function main() {
                    //Login? :D
                    if (window.location.href.contains('/qut-login')) {
                        try {
                            e('#username').value = USERNAME;
                            e('#password').value = PASSWORD;
                            e('.form-group-container button.btn').click();
                            return 'login successful';
                        }
                        catch (e) {
                            return 'login unsuccessful';
                        }
                    }
                    else {
                        //We're in. Now gimme units.
                        if (e('#UnitList').length != 0) {
                            //We have our units before us. Extract the data and calculate the inverse chromosome.
                            var units = e('#qutmyunits_' + (new Date()).getFullYear() + ' a'), unit_names = [], unit_links = [];
                            for (var j = 0; j < units.length; ++j) {
                                unit_names[j] = units[j].textContent;
                                unit_links[j] = units[j].getAttribute('href');
                            }
                            //JSON-ify the data
                            var unit_data = { };
                            for (var j = 0; j < unit_names.length; ++j) {
                                unit_data[unit_names[j]] = unit_links[j];
                            }
                            return JSON.stringify(unit_data);
                        }
                        else {
                            //Hey, we've already grabbed our units. Where are we?
                            if (!window.location.href.contains('webapps/blackboard/execute/announcement')) {
                                //Do not try to bend the data; that's impossible. Instead, only try to realize the truth... there is no data.
                                var links = e('#content_listContainer a'), urls = [];
                                for (var j = 0; j < links.length; ++j) {
                                    var u_href = links[j].getAttribute('href');
                                    if (u_href.contains('/bbcswebdav/') || u_href.contains('/webapps/blackboard/content/')) {
                                        urls.push(u_href);
                                    }
                                }
                                return JSONify(urls);
                            }
                            else {
                                //We are on the Announcements page. These are not the links you're looking for.
                                var links = e('#courseMenuPalette_contents a'), urls = [];
                                for (var j = 0; j < links.length; ++j) {
                                    var u_href = links[j].getAttribute('href'), u_content = links[j].children[0].getAttribute('title');
                                    if (u_content.contains('Assessment') || u_content.contains('Learning Resources')) {
                                        urls.push(u_href);
                                    }
                                }
                                return JSONify(urls);
                            }
                        }
                    }
                }

                function JSONify(array) {
                    var data_json = { };
                    for (var j = 0; j < array.length; ++j) { data_json[j] = array[j]; }
                    return JSON.stringify(data_json);
                }

                main();";

            //To get our personalized script, just swap in our Username and Password.
            return template_str.Replace("[USERNAME GOES HERE]", username).Replace("[PASSWORD GOES HERE]", password);
        }
    }
}
