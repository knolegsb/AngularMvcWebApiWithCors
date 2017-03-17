(function () {
    "use strict";

    angular.module("common.services")
    .factory("productResource", ["$resource", "appSettings", productResource]);

    function productResource($resource, appSettings) {
        return $resource(appSettings.serverPath + "/api/products/:id");
        //    null, {
        //    'get': {
        //        headers: { 'Authorization': 'Bearer' + currentUser.getProfile().token }
        //    },
        //    'save': {
        //        headers: { 'Authorization': 'Bearer' + currentUser.getProfile().token }
        //    },
        //    'update': {
        //        method: 'PUT',
        //        headers: { 'Authorization': 'Bearer' + currentUser.getProfile().token }
        //    }
        //});
    }
}());