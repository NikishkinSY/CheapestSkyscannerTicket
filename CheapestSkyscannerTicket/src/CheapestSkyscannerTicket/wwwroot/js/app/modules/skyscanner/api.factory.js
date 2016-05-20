(function () {
    'use strict';

    //factory for receiving skyscanner data

    angular
        .module('app.skyscanner')
        .factory('skyscannerApi', skyscannerApi);

    skyscannerApi.$inject = ['$http'];

    function skyscannerApi($http) {
        var service = {
        };

        return service;
    }
})();