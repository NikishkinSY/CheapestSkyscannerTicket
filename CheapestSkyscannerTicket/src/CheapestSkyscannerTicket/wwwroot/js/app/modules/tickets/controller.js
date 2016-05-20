(function () {
    'use strict';

    //controller for cars part front-end
    angular
        .module('app.tickets')
        .controller('TicketsController', TicketsController);

    TicketsController.$inject = [];

    function TicketsController() {
        var vm = this;
        vm.title = 'tickets';
        
    }
})();
