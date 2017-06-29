
/*
    check if there's user logged in
    if there show user name and log out btn ,also hides sign in and register
*/
if (sessionStorage.getItem('username')) {
    document.getElementById("hello").innerText = sessionStorage.getItem('username');
    document.getElementById("hello").style.visibility = "visible";
    document.getElementById("register").style.visibility = "hidden";
    document.getElementById("login").style.visibility = "hidden";
    document.getElementById("index").style.visibility = "visible";
}



/*
   log out the user by deleting the user from the session Storage
 */
function logOutOnClick(e) {
    sessionStorage.removeItem('username');
    document.getElementById("hello").style.visibility = "hidden";
    document.getElementById("register").style.visibility = "visible";
    document.getElementById("login").style.visibility = "visible";
    document.getElementById("index").style.visibility = "hidden";
}

/*
check that the player is log in before go to multi player game
*/
function MultiPlayerOnClick() {
    if (sessionStorage.getItem('username')) {
        window.location.href = "MultiPlayerPage.html";
    }
    else {
        alert("Please Sign in or Register");
    }
}