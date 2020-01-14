angular.module('$ext_safeprojectnamecamel$')
    .controller('$ext_safeprojectnamecamel$.supplierDetailController', ['$scope',
        function ($scope) {
            var blade = $scope.blade;

            if (blade.isNew) {
                blade.title = 'external-customer.blades.supplier-detail.title';

                if (blade.parentBlade.currentEntity.id) {
                    blade.currentEntity.organizations.push(blade.parentBlade.currentEntity.id);
                }

                blade.fillDynamicProperties();
            } else {
                blade.subtitle = 'external-customer.blades.supplier-detail.subtitle';
            }

            // base function override (optional)
            blade.customInitialize = function () {
                if (!blade.isNew) {
                    blade.title = blade.currentEntity.name;
                }
            };
    }]);

