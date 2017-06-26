
var ViewModel = function () {
    var self = this; // make 'this' available to subfunctions or closures
   // self.DbInfoes = ko.observableArray([{ Username='dfg', Password='345' },{Username='asd', Password='346' }]);

    //alert(self.DbInfoes[0].Username);

    self.dbInfo = ko.observableArray(); // enables data binding
    alert(self.dbInfo.length);
    var uri = "/api/DbInfoes";
    function getAllPlayers() {
        $.getJSON(uri).done(function (data) {
            alert(data.length);
            self.dbInfo(data); //this not working
            alert(self.dbInfo.length);
        });
    }
    // Fetch the initial data
    getAllPlayers();
};
ko.applyBindings(new ViewModel()); // sets up the data binding
