//a mazeBoard jquery plugin for the multi player.

var currRow, currCol, startRow, startCol, cellWidth, cellHeight, context;
var endRow, endCol, playerImage, rows, cols;

(function ($) {
    $.fn.mazeBoard = function (maze, name, rowsM, colsM, startR, startC, endR, endC,
                                playerIm, exitImage, hub) {
        var myCanvas = this[0];
        var indexInMaze;
        context = myCanvas.getContext("2d");
        cellWidth = myCanvas.width / cols;
        cellHeight = myCanvas.height / rows;
        var counter = 0;
        //initialize globals
        rows = rowsM;
        cols = colsM;
        playerImage = playerIm;
        endRow = endR;
        endCol = endC;
        startRow = startR;
        startCol = startC;
        currRow = startRow;
        currCol = startCol;
        drawMaze();
        //binding the key presses
        myCanvas.onkeydown = move.bind(this);
        function drawMaze() {
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
            //focuse on the maze
            myCanvas.focus();
        }

        //delete the player from the canvas.
        function deletePlayer() {
            context.clearRect(currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        };

        //draw the player on the canvas
        function drawPlayer() {
            context.drawImage(playerImage, currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        };

        //move the player on the given direction
        function move(e) {
            var newCurrCol = currCol;
            var newCurrRow = currRow;
            var newIndexInMaze = indexInMaze;
            switch (e.keyCode) {
                case 38:
                    newCurrRow -= 1;
                    newIndexInMaze -= cols;
                    hub.server.move(name, "Up");
                    break;
                case 40:
                    newCurrRow += 1;
                    newIndexInMaze += cols;
                    hub.server.move(name, "Down");
                    break;
                case 39:
                    newCurrCol += 1;
                    newIndexInMaze += 1;
                    hub.server.move(name, "Right");
                    break;
                case 37:
                    newCurrCol -= 1;
                    newIndexInMaze -= 1;
                    hub.server.move(name, "Left");
                    break;
            }
            //check if the new indexes are legel
            if ((newCurrCol < cols) && (newCurrRow < rows)
                && (newCurrCol >= 0) && (newCurrRow >= 0) && maze[newIndexInMaze] == '0') {

                //delete the player
                deletePlayer();

                //updating new indexes
                currCol = newCurrCol;
                currRow = newCurrRow;
                indexInMaze = newIndexInMaze;

                //draw the player in the new position
                drawPlayer();

                //check if the player won
                checkIfWin();
            }
        }

        //check if the player won
        function checkIfWin() {
            if (currCol == endCol && currRow == endRow) {
                alert("Congratulations, You Won!");
            }
        }
    };

    //movements function to move when the hub tells to
    $.fn.moveLeft = function () {
        var newCurrCol = currCol;
        deletePlayer();
        newCurrCol -= 1;
        currCol = newCurrCol;
        drawPlayer();
        checkIfWin();
        return this;
    };

    $.fn.moveRight = function () {
        var newCurrCol = currCol;
        deletePlayer();
        newCurrCol += 1;
        currCol = newCurrCol;
        drawPlayer();
        checkIfWin();
        return this;
    };

    $.fn.moveUp = function () {
        var newCurrRow = currRow;
        deletePlayer();
        newCurrRow -= 1;
        currRow = newCurrRow;
        drawPlayer();
        checkIfWin();
        return this;
    };

    $.fn.moveDown = function () {
        var newCurrRow = currRow;
        deletePlayer();
        newCurrRow += 1;
        currRow = newCurrRow;
        drawPlayer();
        checkIfWin();
        return this;
    };

})(jQuery);