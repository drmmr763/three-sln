# A demo solution

This is a demo solution which features 3 DotCore projects:
- AppApi
- ApiCli
- AppShared

## AppApi
This project contains the rest api project features. The goal of this project is to implement all the REST Api endpoints with controllers, routing, input validation, and error handling.

## AppCli
This project contains the cli interface for the project. This is highly useful for testing and implementing the persistence layer and implementing stand up features such as a seeder.

## AppShared
This project is a consumed library that is utilized by both the API and the CLI applications. The point of this project is to have a centralized source for all domain and business logic. This is where entities, repositories, services, dbcontext, and migrations should be stored. This allows these components to be reused in the CLI or the API as needed.