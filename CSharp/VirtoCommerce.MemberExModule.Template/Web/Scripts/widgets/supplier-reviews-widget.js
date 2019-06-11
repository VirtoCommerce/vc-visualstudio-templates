angular.module('$ext_safeprojectnamecamel$')
    .controller('$ext_safeprojectnamecamel$.reviewsWidgetController',
        ['$scope', 'platformWebApp.bladeNavigationService',
            function ($scope, bladeNavigationService) {
                var blade = $scope.blade;

                $scope.openBlade = function () {
                    if ($scope.loading)
                        return;

                    var newBlade = {
                        id: "supplierReviews",
                        title: blade.currentEntity.name,
                        subtitle: 'external-customer.widgets.supplier-reviews.title',
                        controller: '$ext_safeprojectnamecamel$.reviewsController',
                        template: 'Modules/$($ext_safeprojectnamecamel$v)/Scripts/blades/supplier-review-list.html'
                    };
                    bladeNavigationService.showBlade(newBlade, blade);
                };
            }]);
