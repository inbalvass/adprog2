//this script gets the solution of the maze from the server.
function getSolution() {
    var apiUrl = "api/SinglePlayer";
    var name = document.getElementById("txtName").value;
    var algo = document.getElementById("algorithm").value;

    //ajax request to the server to recieve the solution.
    $.getJSON(apiUrl + "/" + name + "/" + algo)
       .done(function (solution) {
           var json = JSON.parse(solution);
           //drawing it using a function in the plugin
           $("#mazeCanvas").drawSolution(json['Solution']);

       })
        .fail(function (jqXHR, textStatus, err) {
            alert("problem connecting the server");
        });
}