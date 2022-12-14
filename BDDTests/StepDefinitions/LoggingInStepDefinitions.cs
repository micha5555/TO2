using NUnit.Framework;
using Services;
using System;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class LoggingInStepDefinitions
    {
        private AdministratorOperations _administratorOperations;
        private string _registrationLogin, _registrationPassword;
        private string _providedLogin, _providedPassword;
        private bool _isLogged;

        [Given(@"Admin in not logged in")]
        public void GivenAdminInNotLoggedIn()
        {
            _administratorOperations= new AdministratorOperations();    
        }

        [Given(@"Admin has registered before using <login> and <password>")]
        public void GivenAdminHasRegisteredBeforeUsingLoginAndPassword(Table table)
        {
            _registrationLogin = table.Rows[0][0];
            _registrationPassword= table.Rows[0][1];

            _administratorOperations.registerNewAdministrator(_registrationLogin, _registrationPassword);
        }

        [When(@"Admin enters correct login")]
        public void WhenAdminEntersCorrectLogin()
        {
            _providedLogin = _registrationLogin;
        }

        [When(@"Admin enters correct password")]
        public void WhenAdminEntersCorrectPassword()
        {
            _providedPassword = _registrationPassword;
        }

        [Then(@"The login data are correct")]
        public void ThenTheLoginDataAreCorrect()
        {
            _isLogged = _administratorOperations.checkAdministratorCredentials(_providedLogin, _providedPassword);

            Assert.IsTrue(_isLogged);
        }

        [When(@"Admin enters incorrect login")]
        public void WhenAdminEntersIncorrectLogin()
        {
            _providedLogin = "abc";
        }

        [When(@"Admin enters incorrect password")]
        public void WhenAdminEntersIncorrectPassword()
        {
            _providedPassword= "abc";
        }

        [Then(@"The login data are not correct")]
        public void ThenTheLoginDataAreNotCorrect()
        {
            _isLogged = _administratorOperations.checkAdministratorCredentials(_providedLogin, _providedPassword);

            Assert.IsFalse(_isLogged);
        }

    }
}
