//Call this to register our module to main application
var moduleName = "$ext_safeprojectnamecamel$";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .run(['$rootScope', 'virtoCommerce.customerModule.memberTypesResolverService',
        function ($rootScope, memberTypesResolverService) {

            // add JobTitle field to Contact detail blade
            var contactInfo = memberTypesResolverService.resolve("Contact");
            contactInfo.detailBlade.metaFields.unshift({
                name: 'jobTitle',
                title: "JobTitle",
                valueType: "ShortText"
            });

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
