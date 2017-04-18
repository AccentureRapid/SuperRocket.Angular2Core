# SuperRocket.Angular2Core
SuperRocket.Angular2Core is an template based on ABP Module Zero ASP.NET Core Template, which is a ready to go version.

Introduction
The easiest way of starting a new project using ABP and module-zero for ASP.NET Core with Angular (also known as Angular2) is to create a template on templates page. Remember to check "Include module zero".

After creating and downloading your project, follow below steps to run your application.

ASP.NET Core Application
Open your solution on Visual Studio 2017+.
Select the 'Web.Host' project as startup project.
Migrator.EF tool is used for adding/applying EntityFramework migrations. In order to create your database, open command prompt and move to root folder of EntityFramework project in your solution. Then run "dotnet ef database update" command."
Run the application. It will show swagger-ui if it is successfull.
In this template, multi-tenancy is enabled by default. You can disable it in Core project's module class if you don't need.

If you have problems with running the application, please try close and open your Visual Studio again. It sometimes fail on first package restore.
Social Logins
Startup template supports Facebook and Google+ logins. You can see the following settings in appsettings.json of Web.Host project:

 "Facebook": {
  "IsEnabled": "false",
  "AppId": "",
  "AppSecret": ""
},
"Google": {
  "IsEnabled": "false",
  "ClientId": "",
  "ClientSecret": ""
}
			
Here, you can enable which you need. Surely, you must have application keys and passwords which you need to get from related social web site. You can find guides from web to learn how to obtain this keys. Once you enable a social login and enter true keys, you will see a button in the login page. You can implement other logins as similar.

Token Based Authentication
If you want to consume APIs/application services from a mobile application, you can use token based authentication mechanism just like we do it for Angular client. Startup template includes JwtBearer token authentication infrastructure.

Here, Postman (chrome extension) will be used to demonstrate requests and responses.

Authentication
Just send a POST request to http://localhost:21021/api/TokenAuth/Authenticate with Context-Type="application/json" header as shown below:

Swagger UI auth

We sent values usernameOrEmailAddress and password. As seen above, result property of returning JSON contains the token and expire time (which is 24 hours by default and can be configured). We can save it and use for next requests.

About Multi Tenancy
API will work as host users by default. You can send Abp.TenantId header value to work with a specified tenant. It's an integer value and 1 for default tenant by default.
Use API
After authenticate and get the token, we can use it to call any authorized action. All application services are available to be used remotely. For example, we can use the User service to get a list of users:

Swagger API usage

Just made a GET request to http://localhost:21021/api/services/app/user/getUsers with Content-Type="application/json" and Authorization="Bearer your-auth-token ".

Note that we also added X-Requested-With header to indicate that this is an AJAX request. Thus, ASP.NET Core can better handle the request and return appropriate return values on success and error cases.

All functionality available on UI is also available as API.

Migrator Console Application
Startup template includes a tool, Migrator.exe, to easily migrate your databases. You can run this application to create/migrate host and tenant databases.

Database Migrator

This application gets host connection string from it's own appsettings.json file. It will be same in the appsettings.json in the .Web.Host project at the beggining. Be sure that the connection string in config file is the database you want. After getting host connection sring, it first creates the host database or apply migrations if it does already exists. Then it gets connection strings of tenant databases and runs migrations for those databases. It skips a tenant if it has not a dedicated database or it's database is already migrated for another tenant (for shared databases between multiple tenants).

You can use this tool on development or on product environment to migrate databases on deployment, instead of EntityFramework's own tooling (which requires some configuration and can work for single database/tenant in one run).

Unit Testing
Startup template includes test infrastructure setup and a few tests under the .Test project. You can check them and write similar tests easily. Actually, they are integration tests rather than unit tests since they tests your code with all ASP.NET Boilerplate infrastructure (including validation, authorization, unit of work...).

Angular Application
Prerequirements
Angular application needs to following tools be installed:

nodejs 6.9+ with npm 3.10+
Typescript 2.0+
We used angular-cli to develop the Angular application.

Restore Packages
Open a command prompt, navigate to angular folder which contains *.sln file and run the following command to restore packages:

npm install
Notice that npm install may show some warn messages, which is not related to our solution and generally it's not a problem.

Run The Application
In your opened command prompt, run the following command:

npm start
Once the application compiled, you can browse http://localhost:4200 in your browser. Be sure that Web.Host application is running at the same time. Angular client app has also HMR (Hot Module Replacement) enabled. You can use the following command (instead of npm start) to enable HMR on development time:

npm run hmr
Login
Now you can login the application using default credentials. User name is 'admin' and password is '123qwe' as default. If you want to login as a tenant, first switch to that tenant in login page.

Deployment
We used angular-cli tooling to build Angular solution. You can use ng build command to publish your project. It publishes to dist folder by default. Then you can host this folder on IIS or any web server you like.
