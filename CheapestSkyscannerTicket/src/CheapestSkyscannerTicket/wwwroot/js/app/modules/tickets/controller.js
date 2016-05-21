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
    }
})();
