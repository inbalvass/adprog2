//save the default settings 
$("#txtRows").val(localStorage.getItem("Rows"));
$("#txtCols").val(localStorage.getItem("Cols"));
$("#algorithm").val(localStorage.getItem("Algo"));

(function ($) {
    $("#save").click(function (e) {
        var rows = $("#txtRows").val();
        var cols = $("#txtCols").val();
        var algo = $("#algorithm").val();
        localStorage.setItem("Rows", rows);
        localStorage.setItem("Cols", cols);
        localStorage.setItem("Algo", algo);
    });
})(jQuery);