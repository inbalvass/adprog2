﻿
//this scripts gets the maze string from the server.
var apiUrl = "api/SinglePlayer";
function getMaze() {
    var name = document.getElementById("txtName").value;
    var rows = document.getElementById("txtRows").value;
    var cols = document.getElementById("txtCols").value;
    document.title = name;
    $("#loader").show();
    //Ajax request for bringing the maze string
    $.getJSON(apiUrl + "/" + name + "/" + rows + "/" + cols)
        .done(function (maze) {
            var json = JSON.parse(maze);
            $("#loader").hide();
            $("#div").show();
            var playerImage = new Image();
            playerImage.src = "images/pacman.png";
            var exitImage = new Image();
            exitImage.src = "images/exit.jpg";

            //drawing the maze using code in the plugin.
            var myMazeBoard = $("#mazeCanvas").mazeBoard(json['Maze'],
                                                        json['Start']['Row'],
                                                        json['Start']['Col'],
                                                        json['End']['Row'],
                                                        json['End']['Col'],
                                                        playerImage, exitImage);
        })
        .fail(function (jqXHR, textStatus, err) {
            alert("problem connecting the server");
        });
}