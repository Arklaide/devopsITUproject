# Decision log

This is the decision log. Create a new headline (##) when creating updates and state the date.  
E.g \## Cloud hosting decision - UPDATE 2023-01-15

## Monitoring - UPDATE 2022-08-03 (Women's International Day)

We have started to implement monitoring using Prometheus and Grafana since it is industry standard.

## Virtualization techniques and Deployment targets

Our system deploys to Digital Ocean, since Digital Ocean is easy to use and has various support different os, moreover, it was introduced in the lectures and you can get $100 credit as a student. The machines were provisoned manually in the beginning before we got out infrastructure as code with terraform implemented. Vagrant was decided not to be used due to feeling using Docker fulfilled our needs of a development environment, however, it could have been an idea to try and use vagrant to see if it would improve conditions, however, the overhead of implementing vagrant was avoided. The setup had floating IPS enabled at one point, but was turned off, this was a poor decision of judgement, since when we had our server incident described in incidents_log.md, it would have been easier to allow the new machine to serve on the same IP (especially for the simulator. The floating IP was removed, since it did not seem necessary before it became necessary.

## CI DECISION & docker & more - UPDATE 2022-01-03 + more

- We have chosen to use GitHub Actions to keep more things on the same platform to reduce complexity of the project
- GitHub Actions is well-documented and GitHub has many features which comes in handy, like using GitHub secrets, notifications and so on. Other platforms offers this too, but having everything in GitHub simplifies it.
- We have chosen to use digital ocean since it provides a simple way to host servers both in times of their droplets where we run a docker container, providing a seperate database hosting, and aswell as having a container registry to store our docker images.
- We have chosen docker since it is widely used and it works in every environment
- We are doing a compose file to run multple docker images (services) to create simplicity and remove overhead of container for each.
- We have chosen the smallest plans on digital ocean simply to avoid costs. Later we upgraded due to logging being greedy, so we needed vertical scaling.
- We only have CI for our production environment (main branch) and not on our development/testing environment (develop branch) also to avoid costs. It would have been preferred to have this testing environment to ensure that no faulty code is released.
- We have added units tests to the CI to detects errors before they are released. Furthermore, we added some dotnet code analysis, snyk docker image scan, and some linting as checks. This however is having some issues, so the checks are not providing much value, as most of it fails, due to some version mismatch and more. Fixing this has not been prioritized, but implementing new things has. It is however, a bit important in the future to add the quality gates properly, and avoid deploying to digtical ocean if the checks does not pass good enough. However, we have a lot of checks when doing PR, which works, which led to the low priority. Moreover, it did not halt deployment, since the deploy part of the CI works, just ignoring the failed check steps.
- We have made sure that the docker container will not shutdown, but it will update to avoid downtime of the service (blue-green)
- Our GitHub actions are configured to deploy our docker swarm to digital ocean everytime there is a commit to main
- Our swarm uses the default ingress routing load balancer as we have not set up an additional one

## REFACTORING DECISION - UPDATE 2022-02-15

### Our choices

We are refactoring the project in C#, since it is a reliable programming language with many useful features. It is a bit heavy compared to Python. But we also wanted to create a solid piece of software with best practice. This cost some extra work-hours than refactoring it to another lightweight language such as TypeScript.

- Frontend: MVC-pattern .Net core 6. Reliable enterprise code and seperation of concerns using the MVC-pattern, great modalarization. (TENTATIVE)
- Backend: API using .Net and Entity Framework to provide a solid way to build am API when having a relational database storage.
- Database: postgressql, since our product has relational data, they are all linked to users. It is very well-known and secure and can also be scaled with clusters and more.

We have chosen to use DigitalOcean as our cloud solution, since it seem reliable and something new to work with. We are using docker containers both remote and locally since it is widely used in the industry as it ensures portability.

### Alternatives we explored, but did not go with

We could have used TypeScript for both the front-end and back-end. A simple way was to use React as frontend and a node.js backend. This could have saved work-hours. The architecutre pattern could have been pub-sub, since it is what twitter is.

### Programming language and framework

We chose our programming language and framework to maximize the performance of the API. There are 2 different framworks which performs way ahead of their competitors which is Dotnet Core and Node Express JS. We’ve decided to go for Dotnet Core, reason being that it is reliable and as fast as the competitor and it is a familiar techstack for us to use. Dotnet Core APis also has the positives of Endpoints being automatically serialized to properly formatted JSON, which
is being used in our frontend, aswell as the simulator, which is a nice QOL improvement for us.

### ORM Framework

We chose to go with Entity Framework since its an incorporated library in .Net. It provides also Language Integrated Query (LINQ), which lets us query database fields with the help of conceptual models. It is the Go to ORM framework for .Net applications, and have scaffolding build in to make the refactoring of the python program straight forward.
