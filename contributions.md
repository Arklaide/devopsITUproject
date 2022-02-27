# Contributing to the repository

## Which repository setup will we use?

We will use a mono-repository which contains everything in the same place. 

## Which branching model will we use?

We will use the branching model GitFlow, which means we have a `main` branch for releases, a `develop` branch for testing. We will create feature branches continuously. Each developer will create pull requests from a feature branch into the `develop` branch and assign one or more reviewers. When we are ready for a release, we create a PR from `develop` to `main` and once approved, it will automatically trigger a deployment in DigitalOcean. 

## Which distributed development workflow will we use?

We will use GitHub issues and project to coordinate tasks. There is a kanban-like feature where we can create, assign, comment, and keep track of statuses of tasks. We will work on the project together every Tuesday after the lecture until 4pm and we will work distributed for the remaining tasks of the week. 

## How do we expect contributions to look like?

We will create a PR template, which must be met for every pull request. This will include information about the contribution and any underlying decisions. 

## Who is responsible for integrating/reviewing contributions?

Someone from the group, who has not worked directly on the contribution in question. 
