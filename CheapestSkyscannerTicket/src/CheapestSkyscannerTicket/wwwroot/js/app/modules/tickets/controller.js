(function () {
    'use strict';

    //controller for cars part front-end
    angular
        .module('app.tickets')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = ['skyscannerApi'];

    function TicketsController(skyscannerApi) {
        var apiKey = 'te095065168589735671981266916440';
        var vm = this;
        vm.title = 'tickets';
        vm.currency = [];

        vm.getCurrency = function () {
            skyscannerApi.getCurrency(apiKey)
                .then(function (data) {
                    vm.currency = data;
                });
        };

    }
})();
