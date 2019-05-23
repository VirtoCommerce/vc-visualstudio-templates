//Call this to register our module to main application
var moduleName = "$ext_safeprojectnamecamel$";

if (AppDependencies !== undefined) {
    AppDependencies.push(moduleName);
}

angular.module(moduleName, [])
    .run(['virtoCommerce.orderModule.knownOperations', '$http', '$compile',
        function (knownOperations, $http, $compile) {
            var foundTemplate = knownOperations.getOperation('CustomerOrder');
            if (foundTemplate) {
                foundTemplate.detailBlade.metaFields.push(
                    {
                        name: 'newField',
                        title: "New field",
                        valueType: "ShortText"
                    });

                foundTemplate.detailBlade.knownChildrenOperations.push('Invoice');
            }

            var invoiceOperation = {
                type: 'Invoice',
                description: 'Sample Invoice document',
                treeTemplateUrl: 'invoiceOperation.tpl.html',
                detailBlade: {
                    template: 'Modules/$($ext_safeprojectnamecamel$)/Scripts/blades/invoice-detail.html',
                    metaFields: [
                        {
                            name: 'number',
                            isRequired: true,
                            title: "Invoice number",
                            valueType: "ShortText"
                        },
                        {
                            name: 'createdDate',
                            isReadonly: true,
                            title: "created",
                            valueType: "DateTime"
                        },
                        {
                            name: 'customerId',
                            title: "Customer",
                            templateUrl: 'customerSelector.html'
                        }
                    ]
                }
            };
            knownOperations.registerOperation(invoiceOperation);

            $http.get('Modules/$($ext_safeprojectname$)/Scripts/tree-template.tpl.html').then(function (response) {
                // compile the response, which will put stuff into the cache
                $compile(response.data);
            });
        }]);