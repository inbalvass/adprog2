var currRow, currCol, startRow, startCol, cellWidth, cellHeight, context;
var endRow, endCol, playerImage;

(function ($) {
    $.fn.mazeBoard = function (maze, startR, startC, endR, endC,
                                playerIm, exitImage, isEnabled) {
        var rows = parseInt($("#txtRows").val());
        var cols = parseInt($("#txtCols").val());
        var myCanvas = this[0];
        var indexInMaze;
        context = myCanvas.getContext("2d");
        cellWidth = myCanvas.width / cols;
        cellHeight = myCanvas.height / rows;
        var counter = 0;
        //initialize globals
        playerImage = playerIm;
        endRow = endR;
        endCol = endC;
        startRow = startR;
        startCol = startC;
        currRow = startRow;
        currCol = startCol;
        //clear all canvas
        context.clearRect(0, 0, myCanvas.width, myCanvas.height);
        drawMaze();
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

        function deletePlayer() {
            context.clearRect(currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        };

        function drawPlayer() {
            context.drawImage(playerImage, currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        };

        function move(e) {
            var newCurrCol = currCol;
            var newCurrRow = currRow;
            var newIndexInMaze = indexInMaze;
            switch (e.keyCode) {
                case 38:
                    newCurrRow -= 1;
                    newIndexInMaze -= cols;
                    break;
                case 40:
                    newCurrRow += 1;
                    newIndexInMaze += cols;
                    break;
                case 39:
                    newCurrCol += 1;
                    newIndexInMaze += 1;
                    break;
                case 37:
                    newCurrCol -= 1;
                    newIndexInMaze -= 1;
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

        function checkIfWin() {
            if (currCol == endCol && currRow == endRow) {
                alert("Congratulations, You Won!");
           }
        }    
    };
    $.fn.drawSolution = function (solution) {
        //***moving player to start point***
        //delete the player
        context.clearRect(currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        //updating indexes
        currCol = startCol;
        currRow = startRow;
        //draw the Player
        context.drawImage(playerImage, currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);
        //check if the player won
        if (currCol == endCol && currRow == endRow) {
            alert("Congratulations, You Won!");
        }

        //move the player to the end, using setInterval
        var i = 0;
        var moveOn = true;
        timer = setInterval(moveOrEnd, 200, solution);

        function moveOrEnd(solution) {
            if (moveOn) {
                moveOneStep(solution, i);
                i++;
            }
            else {
                clearInterval(timer);
                i = 0;
            }
        }
        function moveOneStep(solution, j) {
            var newCurrCol = currCol;
            var newCurrRow = currRow;
            switch (solution[j]) {
                case '2':
                    newCurrRow--;
                    break;
                case '3':
                    newCurrRow++;
                    break;
                case '1':
                    newCurrCol++;
                    break;
                case '0':
                    newCurrCol--;
                    break;
            }

            //delete the player
            context.clearRect(currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);

            //updating new indexes
            currCol = newCurrCol;
            currRow = newCurrRow;

            //draw the player in the new position
            context.drawImage(playerImage, currCol * cellWidth, currRow * cellHeight, cellWidth, cellHeight);

            //check if the player won
            if (currCol == endCol && currRow == endRow) {
                moveOn = false;
                alert("Congratulations, You Won!");
            }
        }
    }
})(jQuery);