# MyApiProject
It is a web api project built on below technologies:

Technologies used:
 ##### .net 7
 ##### CQRS & Mediator pattern (MediatR)
 ##### JWT token based authentication and authorization
 ##### Entity Framework Core
 ##### Entity Framework Core In-memory Database
 ##### Swagger
 ##### xunit and MOQ for unit testing

Data is seeded in memory when application starts.

## Instruction to run application:
#### Just download code and run it in visual studio.

APIs can be tested using swagger in browser on below URL:
##### https://localhost:5001/index.html

Feel free to test on postman if you like so. You might need JWT bearer tokens to call some of the APIs.

Below APIs are implemented

  https://localhost:5001/User/authenticate => POST - input schema: {"username":"admin","password": "admin"}  
  https://localhost:5001/user => GET - Authorization Required  
  
  https://localhost:5001/product => GET  
  https://localhost:5001/product/1 => GET  
  https://localhost:5001/product/save => POST - Authorization Required  
  https://localhost:5001/product/update => POST - Authorization Required  
  https://localhost:5001/product/delete => POST - Authorization Required  

    Product Schema for testing:
    {
      "id": 0,
      "name": "string",
      "description": "string",
      "price": 0
    }

Feel free to run unit tests to test the business logic. Database APIs are mocked so you cannot actually make changes to database running unit tests.
*I will implement integration test later.*

Please let me know if you have any questions or issues.
