
var ViewModel = function () {
    var self = this; // make 'this' available to subfunctions or closures
    self.dbInfo = ko.observableArray(); // enables data binding
    //alert(self.dbInfo.length);
    var uri = "/api/DbInfoes";
    function getAllPlayers() {
        $.getJSON(uri).done(function (data) {
            self.dbInfo(data);
            self.dbInfo.sort(function (a, b) { return (b.Wins - b.Losses) - (a.Wins - a.Losses) });
        });
    }

    self.newPlayer = {
        Username: ko.observable(""),
        Password: ko.observable(""),
        Email: ko.observable(""),
        Wins: ko.observable("0"),
        Losses: ko.observable("0")
    }

    var Player = function (data) {
        var self = this;
        self.Username = ko.observable(data.Username()),
            self.Password = ko.observable(data.Password()),
            self.Email = ko.observable(data.Email()),
            self.Wins = ko.observable(data.Wins()),
            self.Losses = ko.observable(data.Losses())
    }

    self.addPlayer = function () {
        //alert(self.dbInfo().length);
        $.post(uri, new Player(self.newPlayer)).done(function (item) {
            self.dbInfo.push(item);
        });
    }
    // Fetch the initial data
    getAllPlayers();
};
ko.applyBindings(new ViewModel()); // sets up the data binding
