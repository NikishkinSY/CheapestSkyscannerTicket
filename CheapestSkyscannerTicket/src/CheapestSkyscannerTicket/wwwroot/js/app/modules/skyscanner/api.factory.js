(function () {
    'use strict';

    //factory for receiving skyscanner data

    angular
        .module('app.skyscanner')
        .factory('skyscannerApi', skyscannerApi);

    skyscannerApi.$inject = ['$http'];

    function skyscannerApi($http) {

        $http.defaults.useXDomain = true;

        var service = {
            GetPlaces: GetPlaces
        };

        function GetPlaces(query, config)
        {
            return $http({
                url: "/api/skyscanner/places/" + query,
                method: "GET",
                config: config
            })
        }

        return service;
    }
})();