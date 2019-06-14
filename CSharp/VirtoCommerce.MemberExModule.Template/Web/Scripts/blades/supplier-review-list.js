angular.module('$ext_safeprojectnamecamel$')
    .controller('$ext_safeprojectnamecamel$.supplierReviewListController', ['$scope', 'platformWebApp.bladeNavigationService',
        function ($scope, bladeNavigationService) {
            var blade = $scope.blade;
            blade.updatePermission = 'customer:update';
            $scope.selectedItem = null;

            function initializeBlade(data) {
                blade.currentEntities = angular.copy(data);
                blade.origEntity = data;
                blade.isLoading = false;
            }

            $scope.selectItem = function (listItem) {
                $scope.selectedItem = listItem;
            };

            blade.onClose = function (closeCallback) {
                bladeNavigationService.showConfirmationIfNeeded(isDirty(), canSave(), blade, $scope.saveChanges, closeCallback, "external-customer.dialogs.reviews-save.title", "external-customer.dialogs.reviews-save.message");
            };

            function isDirty() {
                return !angular.equals(blade.currentEntities, blade.origEntity) && blade.hasUpdatePermission();
            }

            function canSave() {
                return isDirty() && formScope && formScope.$valid;
            }

            var formScope;
            $scope.setForm = function (form) { formScope = form; };

            $scope.cancelChanges = function () {
                $scope.bladeClose();
            };

            $scope.saveChanges = function () {
                angular.copy(blade.currentEntities, blade.origEntity);
                $scope.bladeClose();
            };

            blade.toolbarCommands = [
                {
                    name: "platform.commands.add", icon: 'fa fa-plus',
                    executeMethod: function () {
                        blade.currentEntities.push({ "review": '' });
                    },
                    canExecuteMethod: function () {
                        return true;
                    },
                    permission: blade.updatePermission
                },
                {
                    name: "platform.commands.reset", icon: 'fa fa-undo',
                    executeMethod: function () {
                        angular.copy(blade.origEntity, blade.currentEntities);
                    },
                    canExecuteMethod: isDirty,
                    permission: blade.updatePermission
                },
                {
                    name: "platform.commands.delete", icon: 'fa fa-trash-o',
                    executeMethod: function () {
                        var idx = blade.currentEntities.indexOf($scope.selectedItem);
                        if (idx >= 0) {
                            blade.currentEntities.splice(idx, 1);
                        }
                    },
                    canExecuteMethod: function () {
                        return $scope.selectedItem;
                    },
                    permission: blade.updatePermission
                }
            ];

            $scope.$watch('blade.parentBlade.currentEntity.reviews', function (currentEntities) {
                initializeBlade(currentEntities);
            });
        }]);
