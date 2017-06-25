//src = "/jquery.mazeBoard.js";

function getSolution() {
    //alert("solution");
    //$.getScript("jquery.mazeBoard.js", function () {

    //    alert("Script loaded but not necessarily executed.");

    //});

    var apiUrl = "api/SinglePlayer";
    //var name = $("#txtName").val();
    var name = document.getElementById("txtName").value;
    var algo = document.getElementById("algorithm").value;
    //var algo = $("#algorithm").val();


    //after we have db with list of games:

    //$.get(apiUrl, { name: name, algo: algorithm })
    //        .done(function (solution) {
    //            $("#mazeCanvas").solveMaze(solution);
    //        })
    //        .fail(...) {

    //        });

    //check


    $.getJSON(apiUrl + "/" + name + "/" + algo)
       .done(function (solution) {
           var json = JSON.parse(solution);
           $("#mazeCanvas").drawSolution(json['Solution']);

       })
        .fail(function (jqXHR, textStatus, err) {
            alert("maze not found");
        });


    
}