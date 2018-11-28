angular.module('Module.Web')
.factory('Module.WebApi', ['$resource', function ($resource) {
    return $resource('api/Module.Web');
}]);
