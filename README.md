# TheGuessingGame
Welcome! 

## Local builds
### Requirements
- Requires VS 2019 and ASP.NET Core 2.1 installed. 

### How to run
- Load solution
- Deploy to IIS Express

## How to use
- Load all collection and environment files located in the Postman directory.
- Use Create game request to generate a new game. A game object will be returned, complete with a id and data set.
- Use Retrieve game details request to get details on a previously created game. An example request is {{URL}}/game/0/, where 0 is the id of the game you want mroe details on. 
- Use Add guess to add a set of guesses. Guesses are in id:name format, where the id is the id of the employee and name is thte first name. An example request URL is {{URL}}/game/5/guess, where 5 is the game id.
- Use the Get grades request to get a list of grades for your previously submitted guess. Example request URL is {{URL}}/game/5/guess/0, where 5 is the game id and 0 is the guess id.

## Improvements and TODOs
- Allow a numberOfQuestion parameters on the Create game post that allows the client to adjust the number of employees associated with a game. Currently, 5 employees are returend per game.
- Add additional unit tests.
- Add a user registration step. One thought here is to use IdentityServer and hookup a 3rd party identity provider (e.g. Google). 
- Add a PUT endpoint where the user can modify their guess.
