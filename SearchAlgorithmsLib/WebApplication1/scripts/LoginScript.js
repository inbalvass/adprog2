
/*
    *@description: confrim user name and password by calling server to check in the DB
    *if the user exist - log in, otherwise show validation error
 */
function login() {
    var url = "api/DbInfoes";
    var name = $("#login-username").val();
    var password = $("#login-password").val();

    /*
    *check that all the necessary fields aren't empty
    *show validation for each empty field
    */
    var validation = false;
    if (name == "") {
        document.getElementById("login-userName-required").classList.add('is-visible');
        validation = true;
    }
    if (password == "") {
        document.getElementById("login-password-required").classList.add('is-visible');
        validation = true;
    }
    if (validation) {
        return;
    }

    alert(url + "/" + name + "/" + password);
    $.get(url, { name: name, password: password })
        .done(function (item) {
        sessionStorage.username = item.Username;
        sessionStorage.setItem('password', item.Password);
        window.open("HomePage.html", "_self");
    }).fail(function (response) {
        alert("username or password is incorrect");
        });
    alert("pleas wait while login");
}