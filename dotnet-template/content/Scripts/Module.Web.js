//Call this to register our module to main application
var moduleTemplateName = "Module.Web";

if (AppDependencies != undefined) {
    AppDependencies.push(moduleTemplateName);
}

angular.module(moduleTemplateName, [])
.config(['$stateProvider', '$urlRouterProvider',
    function ($stateProvider, $urlRouterProvider) {
        $stateProvider
            .state('workspace.Module.Web', {
                url: '/Module.Web',
                templateUrl: '$(Platform)/Scripts/common/templates/home.tpl.html',
                controller: [
                    '$scope', 'platformWebApp.bladeNavigationService', function ($scope, bladeNavigationService) {
                        var newBlade = {
                            id: 'blade1',
                            controller: 'Module.Web.blade1Controller',
                            template: 'Modules/$(Module.Web)/Scripts/blades/helloWorld_blade1.tpl.html',
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
            path: 'browse/Module.Web',
            icon: 'fa fa-cube',
            title: 'Module.Web',
            priority: 100,
            action: function () { $state.go('workspace.Module.Web') },
            permission: 'Module.WebPermission'
        };
        mainMenuService.addMenuItem(menuItem);
    }
]);
