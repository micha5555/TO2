using NUnit.Framework;
using Services;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class LoggingInAsAdminStepDefinitions
    {
        private AdministratorOperations _administratorOperations;
        private string _registrationLogin, _registrationPassword;
        private string _providedLogin, _providedPassword;
        private Table _invalidLoginData;
        private bool _isLogged;

        [Given(@"Admin in not logged in")]
        public void GivenAdminInNotLoggedIn()
        {
            _administratorOperations= new AdministratorOperations();    
        }

        [Given(@"Admin has registered before using login and password")]
        public void GivenAdminHasRegisteredBeforeUsingLoginAndPassword(Table table)
        {
            _registrationLogin = table.Rows[0]["login"];
            _registrationPassword= table.Rows[0]["password"];

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

        [Then(@"The admin's login data are correct")]
        public void ThenTheLoginDataAreCorrect()
        {
            _isLogged = _administratorOperations.checkAdministratorCredentials(_providedLogin, _providedPassword);

            Assert.IsTrue(_isLogged);
        }

        [When(@"Admin enters incorrect login and password")]
        public void WhenAdminEntersIncorrectLoginAndPassword(Table table)
        {
            _invalidLoginData = table;
        }

        [Then(@"The admin's login data are not correct")]
        public void ThenTheLoginDataAreNotCorrect()
        {
            foreach(var row in _invalidLoginData.Rows)
            {
                _providedLogin = row[0];
                _providedPassword = row[1];
                _isLogged = _administratorOperations.checkAdministratorCredentials(_providedLogin, _providedPassword);
                Assert.IsFalse(_isLogged);
            }
        }
    }
}
