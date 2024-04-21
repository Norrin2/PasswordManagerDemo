# Password Manager Demo.
This is a Password Manager app.
The project uses a simple MVC approach, there is no Service Layer, Clean Architecture, DDD or any other more complex architecture as with how simple the problem is this would simply be over-engineering.
Always feel free to refer to other .NET projects on my github for more complex samples.
## Back-end
- .NET 8
- The back-end provides an API that exposes CRUD operations over the Saved Passwords. The passwords are stored in memory and for that purpose a PasswordRepository is used, following the RepositoryPattern which brings the demo a little closer to what a real application would be. The repository is injected as a singleton to ensure it stays alive while the application is running.
- There is a test project which covers use cases over the repository and the controller. It uses the xUnit nuget package which is one of the standard options for testing in .NET.

  
## Front-end
- Angular 17
- The front-end consumes the api project and allows for crud operations and displays the password cards using flex layout in order to give a responsive feel.
- Angular Material is used to make the project a little "nicer looking" and also provide easy access to things such as stylized buttons and button icons.
- There is a search functionality in the front-end which filters the existing list. Considering the entire list is already there it is much easier/faster to just filter it trough front-end, however an API method was exposed for this as well.

## Running the Project (back-end)

To run the Password Manager project, follow these steps:

1. Open the solution in Visual Studio 2022 or later.
2. Set the PioresFilmes project as the startup project.
3. Build the solution.
4. Press F5 or use the Debug -> Start Debugging menu to run the project.

Alternatively, you can use the .NET CLI to run the project:

    cd PasswordManagerDemo/PasswordManager
    dotnet run

## Running the Tests

To run the unit tests in the Password Manager Test project, follow these steps:

1. Open the solution in Visual Studio 2022 or later.
2. Set the Test Explorer window as the active window.
3. Build the solution.
4. In the Test Explorer window, select the tests you want to run.
5. Press the Run button or use the Test -> Run menu to run the selected tests.

Alternatively, you can use the .NET CLI to run the tests:

    cd PasswordManagerDemo/PasswordManager.Tests
    dotnet test

## Running the Project (front-end)

To run the Password Manager front-end project, follow these steps:

1. cd password-manager-frontend
2. npm install
3. ng serve
4. access http://localhost:4200/
Note that Node.js v18.13 or higher is required

## Tools used - Visual Studio 2022 (back-end) - VS Code (front-end)