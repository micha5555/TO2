using Frontend;

LoggedInAs loggedInAs;
MainProgram mainProgram = new MainProgram();

mainProgram.handleWelcomeScreen();
loggedInAs = mainProgram.handleLoginScreen();

Console.WriteLine($"Logged in as: {loggedInAs}");