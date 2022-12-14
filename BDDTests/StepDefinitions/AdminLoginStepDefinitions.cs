using NUnit.Framework;

namespace BDDTests.StepDefinitions
{
    [Binding]
    public class AdminLoginStepDefinitions
    {
        int number, sum;

        [Given(@"number (.*)")]
        public void GivenNumber(int p0)
        {
            sum = 0;
            sum += p0;
        }

        [When(@"added (.*)")]
        public void WhenAdded(int p0)
        {
            sum += p0;
        }

        [Then(@"sum is (.*)")]
        public void ThenSumIs(int p0)
        {
            Assert.AreEqual(4, sum);
        }
    }
}
