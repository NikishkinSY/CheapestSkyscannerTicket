(function () {
    'use strict';

    //controller for cars part front-end
    angular
        .module('app.tickets')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = ['skyscannerApi'];

    function TicketsController(skyscannerApi) {
        var vm = this;
        vm.title = 'tickets';
        vm.query = {};
        vm.originPlace;
        vm.destinationPlace;
        vm.outboundDate;
        vm.inboundDate;
        vm.cheapestTicket = {};

        //search matching query places
        vm.CustomSearch = function (userInputString, timeoutPromise) {
            return skyscannerApi.GetPlaces(userInputString, { timeout: timeoutPromise })
                .then(function (response) {
                    return response;
                })
                .catch(console.log.bind(console));
        }

        //check input field data before run function
        vm.CheckInputData = function () {
            if (vm.originPlace &&
                vm.destinationPlace && 
                vm.outboundDate &&
                vm.inboundDate)
                return true
            else {
                alert("Not all fields are entered");
                return false;
            }
        }

        //start search ticket
        vm.SearchCheapestTicket = function () {
            vm.query.originPlace = vm.originPlace.description.PlaceId;
            vm.query.destinationPlace = vm.destinationPlace ? vm.destinationPlace.description.PlaceId : "anywhere";
            vm.query.outboundDate = vm.outboundDate ? vm.outboundDate : "anytime";
            vm.query.inboundDate = vm.inboundDate ? vm.inboundDate : "anytime";
            skyscannerApi.GetCheapestTicket(vm.query)
                .then(function (response) {
                    vm.cheapestTicket = response.data;
                })
                .catch(console.log.bind(console));
        }
       
    }
})();
