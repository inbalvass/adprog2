$("#rows").val(localStorage.getItem("Rows"));
$("#cols").val(localStorage.getItem("Cols"));
// Declare a proxy to reference the hub
var mp = $.connection.mpHub;

// Create a function that the hub can call to broadcast messages
mp.client.message = function (message) {

    switch (message) {
        case "waiting":
            $("#loader").show();
            break;
        case "startPlay":
            $("#loader").hide();
            $("#left").show();
            $("#right").show();
            break;
        case "Lose":
            alert("Sorry, you lost.");
            $("#left").hide();
            $("#right").hide();
        //movements notifications
        case 'Left':
            $("#mazeCanvas2").moveLeft();
            break;
        case 'Right':
            $("#mazeCanvas2").moveRight();
            break;
        case 'Up':
            $("#mazeCanvas2").moveUp();
            break;
        case 'Down':
            $("#mazeCanvas2").moveDown();
            break;
        default:
            break;
    }
};

mp.client.drawMazes = function (maze) {
    var json = JSON.parse(maze);
    var playerImage = new Image();
    playerImage.src = "images/pacman.png";
    var exitImage = new Image();
    exitImage.src = "images/exit.jpg";
    //drawing the two mazes
    var myMazeBoard = $("#mazeCanvas1").mazeBoard(json['Maze'], json['Name'], json["Rows"], json["Cols"],
                                               json['Start']['Row'],
                                               json['Start']['Col'],
                                               json['End']['Row'],
                                               json['End']['Col'],
                                               playerImage, exitImage, mp);

    var rivalPlayerImage = new Image();
    rivalPlayerImage.src = "images/pacman - Copy.png";
    var rivalExitImage = new Image();
    rivalExitImage.src = "images/exit - Copy.jpg";
    var rivalMazeBoard = $("#mazeCanvas2").rivalMazeBoard(json['Maze'], json['Rows'], json['Cols'],
                                                json['Start']['Row'],
                                                json['Start']['Col'],
                                                json['End']['Row'],
                                                json['End']['Col'],
                                                rivalPlayerImage, rivalExitImage);
    var myMazeBoard = $("#mazeCanvas1").mazeBoard(json['Maze'], json['Name'], json['Rows'], json['Cols'],
        json['Start']['Row'],
        json['Start']['Col'],
        json['End']['Row'],
        json['End']['Col'],
        playerImage, exitImage, mp);
  
}
//get the list of mazes from the hub

mp.client.getMazesList = function (names) {
    var list = document.getElementById("gamesList");
    list.options.length = 0;
    for (i = 0; i < names.length; i++) {
        var option = document.createElement("option");
        option.text = names[i];
        list.add(option);
    }
}

$.connection.hub.start().done(function () {
    mp.server.getMazesList();
    $("#startNewGame").click(function () {
        var name = document.getElementById("name").value;
        var rows = document.getElementById("rows").value;
        var cols = document.getElementById("cols").value;
        mp.server.startGame(name, rows, cols);

    });
    //join an existing game
    $("#joinGame").click(function () {
        var name = $("#gamesList").val();
        mp.server.joinGame(name);
    }); 
});
