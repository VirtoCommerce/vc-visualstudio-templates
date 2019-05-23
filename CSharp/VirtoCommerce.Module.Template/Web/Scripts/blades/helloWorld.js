angular.module('$ext_safeprojectnamecamel$')
    .controller('$ext_safeprojectnamecamel$.helloWorldController', ['$scope', '$ext_safeprojectnamecamel$.webApi', function ($scope, api) {
        var blade = $scope.blade;
        blade.title = '$ext_projectname$';

        blade.refresh = function () {
            api.get(function (data) {
                blade.data = data.result;
                blade.isLoading = false;
            });
        };

        blade.refresh();
    }]);