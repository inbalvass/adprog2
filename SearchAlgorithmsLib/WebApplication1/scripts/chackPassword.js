function checkPass() {
    //Store the password field objects and message into variables
    var pass1 = document.getElementById('pass1');
    var pass2 = document.getElementById('pass2');
    var message = document.getElementById('confirmMessage');
    var submit = document.getElementById('submit');
    //Set the colors we will be using
    var goodColor = "#66cc66";
    var badColor = "#ff6666";
    //Compare the values in the password field 
    if (pass1.value == pass2.value) {
        //Set the color to the good color and inform 
        //the user that they have entered the correct password 
        pass2.style.backgroundColor = goodColor;
        message.style.color = goodColor;
        message.innerHTML = "Passwords Match!"
    } else {
        //Set the color to the bad color and notify the user.
        pass2.style.backgroundColor = badColor;
        message.style.color = badColor;
        message.innerHTML = "Passwords Do Not Match!"
        //submit.somthing
    }
}