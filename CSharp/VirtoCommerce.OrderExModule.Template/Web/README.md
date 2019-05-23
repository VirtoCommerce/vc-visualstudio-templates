# Extension of the functionality of the cart and order modules.

The extension of the cart module is a wish list, and the order module is an Invoice.

## Getting started

""Local installation""

* Recover packages and build solution.
* On a pre-deployed platform (locally), create a link to the project directory in the Modules directory in your vc-platform. For example, through the command line `mklink /d <path to .Web project> <path to your platform>\Modules`.

## Solution architecture

### .Core

""Business/Application Model""

The project must contain a business model, services and interfaces. These interfaces should include abstractions for operations that will be performed using infrastructure, such as data access, file system access, network calls, etc. In addition, services or interfaces defined at this level can work with non-object types. that are independent of the user. interface or infrastructure and are defined as simple data transfer objects (DTO).

### .Data (.Cart.Data, .Order.Data)

""Data Access Logic""

The project includes the implementation of data access. Namely, the data access implementation classes (Repositories), any EF Migration objects that have been defined, and EF Entities models. In addition to the data access implementations, the project must contain service implementations that must interact with infrastructure problems. These services must implement the interfaces defined in Core, and therefore the project must have a reference to the Core project.

### .Web

""Presentation Logic and Entry Point""

The user interface level in an ASP.NET MVC application is the entry point for the application. This project must refer to the Core project, and its types must interact with the data layer strictly through the interfaces defined in Core. Direct creation or static calls for user-level data types are not allowed at the user interface level.

The Startup class is responsible for setting up the application and connecting the implementation types to the interfaces, which allows you to correctly inject dependencies at runtime. And to enable dependency injection in ConfigureServices in the Startup.cs file of the user interface project, it refers to data projects.

## Problems and fixs:

""Migrations""

The migration context may become obsolete. In particular, if the state of the database has changed since the generation of the existing migration. Because of this, there will be problems with migration and errors in the integration of the module.
You must recreate the migration or add a new one in order to get the current state of the models. It is also necessary to remove changes to entities that have already been made. Only what we did in the extension should remain.