(function () {
    'use strict';

    //controller for cars part front-end
    angular
        .module('app.tickets')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = ['skyscannerApi', '$q', '$timeout', '$http'];

    function TicketsController(skyscannerApi, $q, $timeout, $http) {
        var vm = this;
        vm.title = 'tickets';
        vm.query = {};
        vm.originPlace = {};

        vm.CustomSearch = function (userInputString, timeoutPromise) {
            return skyscannerApi.GetPlaces(userInputString, { timeout: timeoutPromise })
                .then(function (response) {
                    return response.data;
                })
        }

        vm.SearchCheapestTicket = function() {
            var test = vm.query.destinationPlace;
        }
       
    }
})();
