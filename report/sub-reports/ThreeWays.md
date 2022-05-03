# Three Ways

Consider how much you as a group adhere to the "Three Ways" characterizing DevOps (from "The DevOps Handbook"):

Flow
Feedback
Continual Learning and Experimentation

Map what you are doing with regards to each principle. In case you realize you are not doing something for a principle change the way you are working as a group accordingly.

These notes are for internal use and learning/documentation.

## Flow

- There is not a long way to release to production. It is simply a pull request from develop to main, which triggers the CI/CD pipeline, which in a few minutes pushes the newest code to production. There is also feature branches that needs to be merged into develop before this can happen. This also helps reducing the number of handoffs, so we avoid creating waiting queues for things to be completed. Our CI/CD pipeline helps with the following.

  - Environment creation: We can create environments on demand
  - Code deployment: Our deployment to production only takes a matter of minutes which allows for our on-demand enviroments
  - Test setup and run: Our deployment runs our units test before deploying, so we ensure a safe environment
  - Overly tight architecture: We have simple and loosely coupled architecture in order to avoid blocking architecture meetings before changes can be deployed

- This ensures that we can deliver often to our "customers" and elimate waste in our development and operation flow.

- We use a Kanban board inside the new GitHub project (beta). Here we have the following columns
  - Todo: Where we keep our issues that needs to be done in the future
  - In Progress: Here we keep our issues we are currently working on - We try to limit our WIP to work in small batches to increase productivity. This also helps us in avoiding context switching, since we try to focus on one issue at the time.
  - Code review: Here we keep our issues which are to be code reviewed before merging to the develop branch
  - Ready for release: Here we keep our issues which are approved and waiting in develop to be merged for a release to main
  - Done: Here we keep our issues which are done and deployed to main

## Feedback

- We can quickly create a hotfix since we have fast deployment

- Furthermore, we avoid big bang releases, so we can ensure better and faster QA

- We have setup email notifications from GitHub Actions, so when you trigger a workflow you receive a email everytime a deploy fails, this enables us to react fast if problems occur. The responsible can then fix the problem or gather a team for it (swarming).

- We also wanted to create a CI workflow for our develop branch to ensure a safety checkpoint and a testing environment before deploying to production. However, we chose not to because of costs - this decision is described in the decision log.

- Code reviews ensures we get assurance for our changes in our daily work. Furthermore, this ensures that the codebase is more pleasant to work with for future developers.

## Continual Learning and Experimentation

- We share responsiblity, since we also code review, so everyone is responsible for features being released

- We create a culture where failures are not punished, such that we can ensure great trust and openness among team members. We learn from eachother and our failures, and improve our workflow accordingly. We aim to be a generative organization.

- We try to improve our daily work to allow for removing techinical debts and fixing bugs

- We should consider in the future to conduct scientific experiments to improve our process. Where we set goals and test out hypotheses to try different ways to achieve those

## Conlusion

We follow the principles to a good and reasonable extent. We are in a learning environment and a small organization, which creates some constraints.
