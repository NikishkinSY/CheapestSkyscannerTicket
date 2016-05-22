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
            GetPlaces: GetPlaces,
            GetCheapestTicket: GetCheapestTicket
        };

        function GetPlaces(query, config)
        {
            return $http({
                url: "/api/skyscanner/places/" + query,
                method: "GET",
                config: config
            })
        }

        function GetCheapestTicket(query) {
            return $http({
                url: "/api/skyscanner/cheapestticket/" + query.originPlace + "/" + query.destinationPlace + "/" + query.outboundDate + "/" + query.inboundDate,
                method: "GET"
            })
        }

        return service;
    }
})();