function drawMaze(maze, rows, cols, startRow, startCol, endRow, endCol, playerImage, exitImage, isEnabled) {
   //var rows = document.getElementById("txtRows").value;
   // var cols = document.getElementById("txtCols").value;
    var indexInMaze;
    var myCanvas = document.getElementById("mazeCanvas");
    //var context = $(this).getContext("2d");  
    var context = myCanvas.getContext("2d");
    var cellWidth = myCanvas.width / cols;
    var cellHeight = myCanvas.height / rows;
    var counter = 0;
    for (var i = 0; i < rows; i++) {
        for (var j = 0; j < cols; j++) {
            if (maze[counter] == '1') {
                context.fillRect(cellWidth * j, cellHeight * i, cellWidth, cellHeight);
            }
            if (i == startRow && j == startCol) {
                
                playerImage.onload = function () {
                    context.drawImage(playerImage, cellWidth * startCol, cellHeight * startRow, cellWidth, cellHeight);
                };
                indexInMaze = counter;
            }
            if (i == endRow && j == endCol) {
                
                exitImage.onload = function () {
                    context.drawImage(exitImage, cellWidth * endCol, cellHeight * endRow, cellWidth, cellHeight);
                };
            }
            counter++;
        }
    }
}

//handle here also in movements and 'solve'
