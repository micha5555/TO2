using System;
using TechTalk.SpecFlow;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class ListingItemsStepDefinitions
    {
        [Given(@"Being in the ""([^""]*)"" section\.")]
        public void GivenBeingInTheSection_(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"List of items is empty")]
        public void WhenListOfItemsIsEmpty()
        {
            throw new PendingStepException();
        }

        [When(@"Enter the option number ""([^""]*)""")]
        public void WhenEnterTheOptionNumber(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"""([^""]*)"" is visible")]
        public void ThenIsVisible(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"Message ""([^""]*)"" displays")]
        public void ThenMessageDisplays(string p0)
        {
            throw new PendingStepException();
        }

        [When(@"List of items has one item Szlifierka")]
        public void WhenListOfItemsHasOneItemSzlifierka()
        {
            throw new PendingStepException();
        }

        [When(@"Item Szlifierka costs (.*)")]
        public void WhenItemSzlifierkaCosts(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"Item Szlifierka has description Szlifierka o wadze (.*)kg")]
        public void WhenItemSzlifierkaHasDescriptionSzlifierkaOWadzeKg(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"Item Szlifierka is of the category Narzędzia")]
        public void WhenItemSzlifierkaIsOfTheCategoryNarzedzia()
        {
            throw new PendingStepException();
        }

        [Then(@"Szlifierka with Narzędzia category and (.*) price displays")]
        public void ThenSzlifierkaWithNarzedziaCategoryAndPriceDisplays(int p0)
        {
            throw new PendingStepException();
        }
    }
}
