var apiUrl = "api/SinglePlayer";
//var btn = document.getElementById("StartGameBtn");
(function ($) {
    $("#StartGameBtn").click(function () {
        var name = document.getElementById("txtName").value;
        var rows = document.getElementById("txtRows").value;
        var cols = document.getElementById("txtCols").value;
        $.getJSON(apiUrl + "/" + name + "/" + rows + "/" + cols)
            .done(function (maze) {
                var json = JSON.parse(maze);
                //  var theKey = 'Rows';
                //alert(json['Rows']);
                alert('h');
            })
            .fail(function (jqXHR, textStatus, err) {
                $("#product").text("Error: " + err);
            });
    });
});
