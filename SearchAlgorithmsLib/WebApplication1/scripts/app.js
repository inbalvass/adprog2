
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

    self.addPlayer = function (e) {
        $.post(uri, new Player(self.newPlayer)).done(function (item) {
            self.dbInfo.push(item);
            sessionStorage.username = item.Username;
            sessionStorage.setItem('password', item.Password);
            window.open("HomePage.html", "_self");
        })
            .fail(function (jqXHR, textStatus, err){
                alert("username and password already exist.please change one of them");
            }
         );
    }
    // Fetch the initial data
    getAllPlayers();
};
ko.applyBindings(new ViewModel()); // sets up the data binding
