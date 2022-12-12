using NUnit.Framework;
using System.IO;
using System;
using System.Text;
using Moq;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class AdminLoginStepDefinitions
    {/*
        StringBuilder _ConsoleOutput;
        Mock<TextReader> _ConsoleInput;

        [SetUp]
        public void Setup()
        {
            _ConsoleOutput = new StringBuilder();
            var consoleOutputWriter = new StringWriter(_ConsoleOutput);
            _ConsoleInput = new Mock<TextReader>();
            Console.SetOut(consoleOutputWriter);
            Console.SetIn(_ConsoleInput.Object);
        }

        private MockSequence SetupUserResponse(params string[] userResponses)
        {
            var sequence = new MockSequence();
            foreach (var response in userResponses)
            {
                _ConsoleInput.InSequence(sequence).Setup(x => x.ReadLine()).Returns(response);
            }
            return sequence;
        }

        private string[] RunMainAndGetConsoleOutput()
        {
            Program.Main(default);
            return _ConsoleOutput.ToString().Split('\n');
        }

        [Test]
        public void blabla()
        {
            SetupUserResponse("a", "2");
            var expectedPrompt = "Podaj login: ";
            var outputLines = RunMainAndGetConsoleOutput();
            Assert.AreEqual(expectedPrompt, outputLines[0]);
        }

        [Given(@"Being on the application login page")]
        public void GivenBeingOnTheApplicationLoginPage()
        {
            throw new PendingStepException();
        }

        [Given(@"Enter the option number ""([^""]*)""")]
        public void GivenEnterTheOptionNumber(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"Enter the following details")]
        public void WhenEnterTheFollowingDetails(Table table)
        {
            throw new PendingStepException();
        }

        [When(@"Press enter")]
        public void WhenPressEnter()
        {
            throw new PendingStepException();
        }

        [Then(@"""([^""]*)"" is visible")]
        public void ThenIsVisible(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Option ""([^""]*)"" is visible")]
        public void ThenOptionIsVisible(string wylogowanie)
        {
            throw new PendingStepException();
        }*/
    }
}
