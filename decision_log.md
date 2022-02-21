# Decision log

This is the decision log create a new headline (##) when creating updates and state the date.  
E.g \## Cloud hosting decision - UPDATE 2023-01-15

## REFACTORING DECISION - UPDATE 2022-02-15

### Our choices 

We are refactoring the project in C#, since it is a reliable programming language with many useful features. It is a bit heavy compared to Python. But we also wanted to create a solid piece of software with best practice. This cost some extra work-hours than refactoring it to another lightweight language such as TypeScript. 

- Frontend: MVC-pattern .Net core 6. Reliable enterprise code and seperation of concerns using the MVC-pattern, great modalarization. (TENTATIVE)
- Backend: API using .Net and Entity Framework to provide a solid way to build am API when having a relational database storage.
- Database: postgressql, since our product has relational data, they are all linked to users. It is very well-known and secure and can also be scaled with clusters and more.

We have chosen to use DigitalOcean as our cloud solution, since it seem reliable and something new to work with. We are using docker containers both remote and locally since it is widely used in the industry as it ensures portability.

### Alternatives we explored, but did not go with

We could have used TypeScript for both the front-end and back-end. A simple way was to use React as frontend and a node.js backend. This could have saved work-hours. The architecutre pattern could have been pub-sub, since it is what twitter is.
 


