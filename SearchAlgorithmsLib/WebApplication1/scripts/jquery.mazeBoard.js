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
        drawMaze();
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
        }

        function move() {

        }
        
        
    };
})(jQuery);