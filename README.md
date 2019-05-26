# TheGuessingGame
Welcome! 

## Local builds
### Requirements
- Requires VS 2019 and ASP.NET Core 2.1 installed. 

### How to run
Load solution
Deploy to IIS Express

## How to use
- Load all collection and environment files located in the Postman directory.
- Use Create game request to generate a new game. A game object will be returned, complete with a id and data set.
- Use Retrieve game details to get details on a previously created game. An example request is {{URL}}/game/0/, where 0 is the id of the game you want mroe details on. 
- Use Add guess to add a set of {{URL}}/game/5/guess

## Improvements and TODOs
- Allow a numberOfQuestion parameters on the Create game post 
