angular.module('Module.Web')
.controller('Module.Web.blade1Controller', ['$scope', 'Module.WebApi', function ($scope, api) {
    var blade = $scope.blade;
    blade.title = 'Module.Web';

    blade.refresh = function () {
        api.get(function (data) {
            blade.data = data.result;
            blade.isLoading = false;
        });
    }

    blade.refresh();
}]);
