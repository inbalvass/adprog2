function getSolution() {
  
    var apiUrl = "api/SinglePlayer";
    var name = document.getElementById("txtName").value;
    var algo = document.getElementById("algorithm").value;

    $.getJSON(apiUrl + "/" + name + "/" + algo)
       .done(function (solution) {
           var json = JSON.parse(solution);
           $("#mazeCanvas").drawSolution(json['Solution']);

       })
        .fail(function (jqXHR, textStatus, err) {
            alert("maze not found");
        });
}