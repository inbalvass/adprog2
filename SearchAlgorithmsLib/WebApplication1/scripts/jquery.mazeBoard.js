(function ($) {
    $.fn.mazeBoard = function (maze, startRow, startCol, endRow, endCol,
                                playerImage, exitImage, isEnabled) {
        var rows = parseInt($("#txtRows").val());
        var cols = parseInt($("#txtCols").val());
        var myCanvas = this[0];
        var indexInMaze;
        var context = myCanvas.getContext("2d");
        var cellWidth = myCanvas.width / cols;
        var cellHeight = myCanvas.height / rows;
        var counter = 0;

        var currRow = startRow;
        var currCol = startCol;
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


                checkIfWin();
            }
        }

        function checkIfWin() {
            if (currCol == endCol && currRow == endRow) {
                //$("#dialog").dialog();
                alert("Congratulations, You Won!");
            }
        }

        
    };
    $.fn.drawSolution = function (solution) {
        //alert(solution);
        //לוגיקת הציור כאן
        deletePlayer();

        currCol = startCol;
        currRow = startRow;
        drawPlayer();
        checkIfWin();

        var newCurrCol = startCol;
        var newCurrRow = startRow;
        for (i = 0; i < solution.length; i++)
        {
            alert("here");
            switch (solution[i])
            {
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
            //waiting for the task to finish drawing
            //await Task.Delay(200);

            //delete the player
            deletePlayer();

            //updating new indexes
            currCol = newCurrCol;
            currRow = newCurrRow;

            //draw the player in the new position
            drawPlayer();

            //check if the player won
            checkIfWin(); // להוציא מהפור?
        }
    }
})(jQuery);