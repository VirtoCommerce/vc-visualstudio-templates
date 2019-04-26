angular.module('$ext_safeprojectnamecamel$')
    .factory('$ext_safeprojectnamecamel$.webApi', ['$resource', function ($resource) {
        return $resource('api/$ext_safeprojectnamecamel$');
}]);
