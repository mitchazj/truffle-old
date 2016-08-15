$('#settings').click(function() {
    //truffleService.testing = "Open Settings";
    truffleService.sendMessage("Open Settings");
});
$('#donate').click(function() {
    truffleService.sendMessage("Open Donate");
});
$('#sync').click(function() {
    truffleService.sendMessage("Start Sync");
});

// Initialize Firebase
// var config = {
//     apiKey: "AIzaSyBEaesrRCB2xcIPlNF8s2rwCL1sbri7yO0",
//     authDomain: "truffle-91bcf.firebaseapp.com",
//     databaseURL: "https://truffle-91bcf.firebaseio.com",
//     storageBucket: "truffle-91bcf.appspot.com",
// };
// firebase.initializeApp(config);

//truffleService.sendMessage("awesome!");
//$('#student-number').text("Sweet");
//$('#student-number').text(truffleService.getUnitCount);
//truffleService.sendMessage("Yeah!");

//Connect
//var database = firebase.database();

//var email = "mitchellazj@gmail.com";
//var password = "whatevs";

// firebase.auth().createUserWithEmailAndPassword(email, password).catch(function(error) {
//   // Handle Errors here.
//   var errorCode = error.code;
//   var errorMessage = error.message;
//   alert(errorCode);
//   alert(errorMessage);
//   // ...
// });

//firebase.auth().onAuthStateChanged(function(user) {
//    if (user) {
//        writeUserData("mitchazj", "Mitchell Johnson", "mitchellazj@gmail.com", "https://mitchellazj.com/me.png");
//    } else {
//        alert("Signed out");
//    }
//});

//function writeUserData(userId, name, email, imageUrl) {
//    firebase.database().ref('users/' + userId).set({
//        username: name,
//        email: email,
//        profile_picture : imageUrl
//    });
//}