using Frontend;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("BDDTests.StepDefinitions")]


MainProgram mainProgram = new MainProgram();

mainProgram.handleWelcomeScreen();
// mainProgram.handleLoginScreen();
mainProgram.handleUser();


