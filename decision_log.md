# Decision log

This is the decision log. Create a new headline (##) when creating updates and state the date.  
E.g \## Cloud hosting decision - UPDATE 2023-01-15

## Monitoring - UPDATE 2022-08-03 (Women's International Day)

We have started to implement monitoring using Prometheus following this guide: https://dale-bingham-soteriasoftware.medium.com/net-core-web-api-metrics-with-prometheus-and-grafana-fe84a52d9843

## CI DECISION - UPDATE 2022-01-03

- We have chosen to use GitHub Actions to keep more things on the same platform to reduce complexity of the project
- GitHub Actions is well-documented and GitHub has many features which comes in handy, like using GitHub secrets, notifications and so on. Other platforms offers this too, but having everything in GitHub simplifies it.
- We have chosen to use digital ocean since it provides a simple way to host servers both in times of their droplets where we run a docker container, providing a seperate database hosting, and aswell as having a container registry to store our docker images.
- We have chosen docker since it is widely used and it works in every environment
- We are doing a compose file to run two docker images in one container to create simplicity and remove overhead of containers. Frontend and backend image (TODO)
- We have chosen the smallest plans on digital ocean simply to avoid costs
- We only have CI for our production environment (main branch) and not on our development/testing environment (develop branch) also to avoid costs. It would have been preferred to have this testing environment to ensure that no faulty code is released.
- We have added units tests to the CI to detects errors before they are released (TODO)
- We have made sure that the docker container will not shutdown, but it will update to avoid downtime of the service (TODO)
- Our GitHub actions are configured to deploy our docker container to digital ocean everytime there is a commit to main

## REFACTORING DECISION - UPDATE 2022-02-15

### Our choices

We are refactoring the project in C#, since it is a reliable programming language with many useful features. It is a bit heavy compared to Python. But we also wanted to create a solid piece of software with best practice. This cost some extra work-hours than refactoring it to another lightweight language such as TypeScript.

- Frontend: MVC-pattern .Net core 6. Reliable enterprise code and seperation of concerns using the MVC-pattern, great modalarization. (TENTATIVE)
- Backend: API using .Net and Entity Framework to provide a solid way to build am API when having a relational database storage.
- Database: postgressql, since our product has relational data, they are all linked to users. It is very well-known and secure and can also be scaled with clusters and more.

We have chosen to use DigitalOcean as our cloud solution, since it seem reliable and something new to work with. We are using docker containers both remote and locally since it is widely used in the industry as it ensures portability.

### Alternatives we explored, but did not go with

We could have used TypeScript for both the front-end and back-end. A simple way was to use React as frontend and a node.js backend. This could have saved work-hours. The architecutre pattern could have been pub-sub, since it is what twitter is.
