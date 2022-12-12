using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using Services;
using NUnit.Framework;
using Repo.DataAccessClass;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class ServiceStepDefinitions
    {
        AdministratorOperations ao;
        List<string> dictionary;
        bool yes;
        DataAccess da;
        string login;
        string password;
        Frontend.RegistrationStatus status;

        [Given(@"I enter login and password")]
        public void GivenIEnterLoginAndPassword(Table table)
        {
            da = DataAccess.Instance;
            da.AdminList.Add(new Shared.Administrator("test", "test"));
            ao = new AdministratorOperations();
            dictionary = new List<string>();
            foreach(var row in table.Rows) {
                dictionary.Add(row[0]);
                dictionary.Add(row[1]);
            }
        }

        [When(@"Check credentials is checked")]
        public void WhenCheckCredentialsIsChecked()
        {
            yes = ao.checkAdministratorCredentials(dictionary[0], dictionary[1]);
        }

        [Then(@"Admin is logged in")]
        public void ThenAdminIsLoggedIn()
        {
            Assert.True(yes);
        }

        [Given(@"valid login and password")]
        public void GivenValidLoginAndPassword()
        {
            da = DataAccess.Instance;
            ao = new AdministratorOperations();
            login = "yes";
            password = "no";
        }

        [When(@"Register new Administrator is being activated")]
        public void WhenRegisterNewAdministratorIsBeingActivated()
        {
            status = ao.registerNewAdministrator(login, password);
        }

        [Then(@"Admin added new Administrator")]
        public void ThenAdminAddedNewAdministrator() {
            Assert.AreEqual(Frontend.RegistrationStatus.Registered, status);
        }

    }
}
