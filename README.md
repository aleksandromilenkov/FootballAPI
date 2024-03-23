#Football API
This is ASP.NET Web API for Football Application.  
The API has 3 main entities: Club, Country and Footballer, also it has Users with the help of Identity package.  
You can make all the CRUD operations.  
This API has advanced search implementation for every entity.   
Every Club has multiple Footballers and Every Footballer has just One Club ( One-To-Many Relationship)  
Every Club has just One Country (One-To-One Relationship)   
Every Country has multiple Footballers and Every Footballer has just one Country (One-To-Many Relationship)  
Every Country has multiple Clubs and Every Club has One Country (One-To-Many relationship)  
This API is using Authentication and Authorization with Json Bearer Web Token and Identity package which allows creating tokens and Users to login and signup. Also you can't access some routes if you are not logged in (You need the Bearer Token in the Authorization Header in the HTTP request).   
This API is using EntityFramework to manipulate with the Microsoft SQL Server Database.  
This API serves as backend for this frontend: https://github.com/aleksandromilenkov/FootballAPI_Frontend
