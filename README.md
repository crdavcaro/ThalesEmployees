# Thales Employees

Project to apply for the Senior .NET Developer position.

## Technologies

The technologies and libraries used in the project are the following:

- .NET Core
  - Auto Mapper
  - MsTest
- Angular 16
  - PrimeNg
  - Prime Flex
  - Prime Icons
- Others
  - Gravatar Image Service

- The API is based on a repository pattern to separate the logic from the data access (in this case the consumption of the API rest). It consists of 4 projects:

   - API
   - Business
   - Model
   - Test

- The Client consists of 2 modules
  
   - employee
   - shared
  
each with its corresponding components, pages and services.

## How to Start

- Restore NuGet packages
```bash
nuget restore
```

- Restore npm Packages
```bash
  npm install
```
The application API uses port 5007 By default. If you want to change the port you must configure it in the .net project solution and in the environment file of the angular project

## Demo

![Demo](https://raw.githubusercontent.com/crdavcaro/ThalesEmployees/master/readme_assets/demo.gif)
