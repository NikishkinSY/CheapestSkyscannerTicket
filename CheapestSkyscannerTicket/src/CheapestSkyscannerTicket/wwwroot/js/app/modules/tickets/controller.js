(function () {
    'use strict';

    //controller for cars part front-end
    angular
        .module('app.tickets')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = ['skyscannerApi', '$mdToast'];

    function TicketsController(skyscannerApi, $mdToast) {
        var vm = this;
        vm.title = 'tickets';
        vm.query = {};
        vm.originPlace;
        vm.destinationPlace;
        vm.dateTimeNow = new Date(Date.now());
        vm.outboundDate;
        vm.inboundDate;
        vm.cheapestTicket = {};
        vm.ticketVisible = "visibility: hidden";

        //search matching query places
        vm.CustomSearch = function (userInputString, timeoutPromise) {
            return skyscannerApi.GetPlaces(userInputString, { timeout: timeoutPromise });
        }

        //check input field data before run function
        vm.CheckInputData = function () {
            if (vm.originPlace &&
                vm.destinationPlace && 
                vm.outboundDate &&
                vm.inboundDate)
                return true
            else {
                $mdToast.show($mdToast.simple().textContent('Не все поля введены!'));
                return false;
            }
        }

        //convert date to yyyy-mm-dd
        function DateFormat(date) {
            var yyyy = date.getFullYear().toString();
            var mm = (date.getMonth() + 1).toString(); // getMonth() is zero-based 
            var dd = date.getDate().toString();
            return yyyy + "-" + (mm[1] ? mm : "0" + mm[0]) + "-" + (dd[1] ? dd : "0" + dd[0]); // padding 
        };

        //start search ticket
        vm.SearchCheapestTicket = function () {
            vm.ticketVisible = "visibility:hidden";
            vm.query.originPlace = vm.originPlace.description.PlaceId;
            vm.query.destinationPlace = vm.destinationPlace.description.PlaceId;
            vm.query.outboundDate = DateFormat(vm.outboundDate);
            vm.query.inboundDate = DateFormat(vm.inboundDate);
            skyscannerApi.GetCheapestTicket(vm.query)
                .then(function (response) {
                    vm.cheapestTicket = response.data;
                    if (!response.data) { $mdToast.show($mdToast.simple().textContent('Нет совпадений!')); }
                    else { vm.ticketVisible = "visibility:visible"; }
                })
                .catch(console.log.bind(console));
        }

        //sorry for this! I have not time to solve this, asp.net core web api 2.2 works after 3 time request
        var first = skyscannerApi.GetPlaces("1", null);
        var second = skyscannerApi.GetPlaces("2", null);
    }
})();
