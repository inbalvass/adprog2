var apiUrl = "api/SinglePlayer";
function getMaze() {
    var name = document.getElementById("txtName").value;
    var rows = document.getElementById("txtRows").value;
    var cols = document.getElementById("txtCols").value;
    //$("#product").text(rows);
    //$.get(apiUrl + "/" + name + "/" + rows + "/" + cols)
    $.get(apiUrl, {name: name, cols: cols, rows: rows})
        .done(function (data) {
           // alert(data.MazeStr);
            alert(data.Cols);
        })
        .fail(function (jqXHR, textStatus, err) {
            $("#product").text("Error: " + err);
        });
}