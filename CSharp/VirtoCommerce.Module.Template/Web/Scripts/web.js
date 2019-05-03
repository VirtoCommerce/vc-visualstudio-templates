//Call this to register our module to main application
var moduleName = "$ext_safeprojectnamecamel$";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .config(['$stateProvider', '$urlRouterProvider',
        function ($stateProvider, $urlRouterProvider) {
            $stateProvider
                .state('workspace.$ext_supersafenamejs$State', {
                    url: '/$ext_safeprojectnamecamel$',
                    templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                    controller: [
                        '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                            var newBlade = {
                                id: 'blade1',
                                controller: '$ext_safeprojectnamecamel$.helloWorldController',
                                template: 'Modules/$($ext_safeprojectnamecamel$)/Scripts/blades/helloWorld.tpl.html',
                                isClosingDisabled: true
                            };
                            bladeNavigationService.showBlade(newBlade);
                        }
                    ]
                });
        }
    ])
    .run(['$rootScope', 'platformWebApp.mainMenuService', 'platformWebApp.widgetService', '$state',
        function ($rootScope, mainMenuService, widgetService, $state) {
            //Register module in main menu
            var menuItem = {
                path: 'browse/$ext_safeprojectnamecamel$',
                icon: 'fa fa-cube',
                title: '$ext_projectname$',
                priority: 100,
                action: function () { $state.go('workspace.$ext_supersafenamejs$State'); },
                permission: '$ext_safeprojectnamecamel$.WebPermission'
            };
            mainMenuService.addMenuItem(menuItem);
        }
    ]);
