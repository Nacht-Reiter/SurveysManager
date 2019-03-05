# SurvaysManager

This is small app for creating surveys.

Backend is 3-layers asp.net core solution. It consists of API project (controllers), Business logic progect (services), Data access project (unit of work and repository patterns used) and Common project (AutoMapper configuration and DTOs declaration). Api project is covered by unit tests.

You should restore nu-get packages and run backend using iis express. DB migrations should be applied automatically, if not - run Update-Database command in Package manager console.

Default api url is http://localhost:56942, you can change is in launchSettings.json

Frontend is Angular 6 app.
You should have installed npm and angular cli.
Update npm packages by runing  npm update.
Run front using ng serve command.
Default front url is http://localhost:4200
If you have changed api url on back, change it on front in environment.ts 
