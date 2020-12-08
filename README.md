# leaderboard
This is a .NET Core application written to act as a Tournament Earnings UI, this includes an api with Swagger UI.

## Getting Started
After cloning the repo locally, the starup projects will need to be configured as Action - Start.
- Pegler.Leaderboard
- Pegler.Players

The appsettings will need to be adjusted
- Pegler.Leaderboard
 - Services:Players:Endpoint - to match the url of Pegler.Players
- Pegler.Players
 - ConnectionStrings:PlayersConnection - to match your db source

A DB migration script was added and will need to be run, or the DB manaually created to match PlayerDto.cs

The project can then be built locally using Visual Studio (F5)

## Considerations for Expansion
There are several items which would expand this project

- UI:
 - Currently writting in basic html with Bootstrap default as the UI
 - I would like this to use a JavaScript framework, Angular or React
- Authentication:
  - I would add an IdentityServer4 project under the services Folder
  - This will act as the Auth service for both the UI and the Service.
  - It could be further extened with a SQL Database and an Admin Portal UI.
- Logging:
  - Currently a basic log to file has been added.
  - This should be expanded to include a middleware to log each request, with sensitive data redacted.
  - The logging as it is is for tracing errors and is by no means complete.
- Unit Testing:
 - This is completely missing and needs to be added for each controller and manager output.
- Integration Testing:
  - A test project will need to be added to run through an end to end process.
- CI/CD
  - An automated build should be implemented which will run Unit Tests on every commit, followed by a deployment to a non-production environment to allow Integration tests to be run.
  - In the past I've used Bamboo and Octopus.

