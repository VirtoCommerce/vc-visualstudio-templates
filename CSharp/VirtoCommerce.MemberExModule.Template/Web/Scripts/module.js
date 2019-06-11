// Call this to register your module to main application
var moduleName = "$ext_safeprojectnamecamel$";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, ['virtoCommerce.customerModule'])
    .run(['platformWebApp.widgetService', 'virtoCommerce.customerModule.memberTypesResolverService',
        function (widgetService, memberTypesResolverService) {

            var addressesWidget = {
                controller: 'virtoCommerce.customerModule.memberAddressesWidgetController',
                template: 'Modules/$(VirtoCommerce.Customer)/Scripts/widgets/memberAddressesWidget.tpl.html'
            };
            var emailsWidget = {
                controller: 'virtoCommerce.customerModule.memberEmailsWidgetController',
                template: 'Modules/$(VirtoCommerce.Customer)/Scripts/widgets/memberEmailsWidget.tpl.html'
            };
            var phonesWidget = {
                controller: 'virtoCommerce.customerModule.memberPhonesWidgetController',
                template: 'Modules/$(VirtoCommerce.Customer)/Scripts/widgets/memberPhonesWidget.tpl.html'
            };
            var dynamicPropertyWidget = {
                controller: 'platformWebApp.dynamicPropertyWidgetController',
                template: '$(Platform)/Scripts/app/dynamicProperties/widgets/dynamicPropertyWidget.tpl.html',
                isVisible: function (blade) { return !blade.isNew; }
            };
            var indexWidget = {
                documentType: 'Member',
                controller: 'virtoCommerce.coreModule.searchIndex.indexWidgetController',
                template: 'Modules/$(VirtoCommerce.Core)/Scripts/SearchIndex/widgets/index-widget.tpl.html',
                isVisible: function (blade) { return !blade.isNew; }
            };
            var reviewsWidget = {
                controller: '$ext_safeprojectnamecamel$.reviewsWidgetController',
                template: 'Modules/$($ext_safeprojectnamecamel$)/Scripts/widgets/supplier-reviews-widget.html',
                isVisible: function (blade) { return !blade.isNew; }
            };

            // Register widgets in supplier details
            widgetService.registerWidget(addressesWidget, 'supplierDetail1');
            widgetService.registerWidget(emailsWidget, 'supplierDetail1');
            widgetService.registerWidget(phonesWidget, 'supplierDetail1');
            widgetService.registerWidget(dynamicPropertyWidget, 'supplierDetail2');
            widgetService.registerWidget(indexWidget, 'supplierDetail2');
            widgetService.registerWidget(reviewsWidget, 'supplierDetail2');


            // register new Supplier member type
            memberTypesResolverService.registerType({
                memberType: 'Supplier',
                description: 'Supplier description',
                fullTypeName: '$ext_safeprojectname$.Core.Models.Supplier',
                icon: 'fa fa-truck',
                detailBlade: {
                    template: 'Modules/$($ext_safeprojectnamecamel$)/Scripts/blades/supplier-detail.html',
                    metaFields: [{
                        name: 'contractNumber',
                        title: "Contract Number",
                        valueType: "ShortText"
                    }]
                }
            });

            // registering Supplier as possible child for Organization
            var organizationMetadata = memberTypesResolverService.resolve('Organization');
            organizationMetadata.knownChildrenTypes.push('Supplier');
        }
    ]);
