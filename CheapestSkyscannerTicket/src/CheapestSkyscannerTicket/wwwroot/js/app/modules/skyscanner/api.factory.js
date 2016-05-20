(function () {
    'use strict';

    //factory for receiving skyscanner data

    angular
        .module('app.skyscanner')
        .factory('skyscannerApi', skyscannerApi);

    skyscannerApi.$inject = ['$http'];

    function skyscannerApi($http) {
        var service = {
            getCurrency: getCurrency,
            getLocalizations: getLocalizations
        };

        //fetch currency types
        function getCurrency(apiKey) {
            return $http({
                url: "http://partners.api.skyscanner.net/apiservices/reference/v1.0/currencies?apiKey=" + apiKey,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };

        //fetch localizations
        function getLocalizations(apiKey) {
            return $http({
                url: "http://partners.api.skyscanner.net/apiservices/reference/v1.0/locales?apiKey=" + apiKey,
                method: "GET",
            })
            .then(function (response) {
                return response.data;
            })
            .catch(console.log.bind(console));
        };



        return service;
    }
})();