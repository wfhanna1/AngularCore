# AngularCore
StirTrek 2018

This project was generated with [Angular CLI](https://github.com/angular/angular-cli) version 1.2.7.

All the Angular code resides under the folder src and the ng build process outputs the code to the wwwroot folder.


## Development server
`bower install --config.interactive=false`

To run within the asp.net application you will need to do the following: (Step 3 - 7 only needed when setting up for the first time)
1. DO NOT RUN `ng serve`
2. Ensure that you have npm, node.js, and angular installed
3. Run `npm install -g gulp`
4. Run `npm install --save gulp-install`
5. Run `npm install gulp-clean`
6. Run `npm install -g bower`
7. Run `bower install --config.interactive=false`
8. Compile the dotnet application through visual studio or through the command line (`dotnet restore` followed by `dotnet build`) or through gulp by using 'gulp dotnetBuild'
    * a. If you start the application within visual studio it will launch a browser
    * b. If you start the application from the command prompt(`gulp dotnetRunNWatch` or 'gulp dotnetRun'), navigate to http://localhost:PortNumber
        * i. `gulp dotnetRunNWatch` will run 3 commands, `dotnet restore`, `dotnet build`, and `dotnet watch run` (`dotnet watch run` will listen to any changes and rebuild the .net code, it will also display any errors, and any information that would normally show in the output window in visual studio)
    * NOTE: If you see errors during build regarding "Unexpected token =" or "The command `ng-build --delete-output-path=false`" try doing a `npm install gulp` to install Gulp in your local directory and avoid using the one installed in your Roaming directory.
9. Run `gulp default`
    * a. This will run `npm install` in the background
    * b. Then `ng build`
    * c. Then `bower install` 
    * d. The gulp process will keep watching for any changes in ts files under the src folder. Keep that terminal running and it will rebuild as you make changes to the angular application
10. js code will redirect you to /index.html which will serve the angular application

## Code scaffolding

Run `ng generate component component-name` to generate a new component. You can also use `ng generate directive|pipe|service|class|guard|interface|enum|module`.

## Build

1. Run `npm install`
2. Run `ng build`
3. Run `bower install`

## Running unit tests

Run `ng test` to execute the unit tests via [Karma](https://karma-runner.github.io).

## Running end-to-end tests

Run `ng e2e` to execute the end-to-end tests via [Protractor](http://www.protractortest.org/).
Before running the tests make sure you are serving the app via `ng serve`.

## Further help

To get more help on the Angular CLI use `ng help` or go check out the [Angular CLI README](https://github.com/angular/angular-cli/blob/master/README.md).
