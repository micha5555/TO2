using TechTalk.SpecFlow;

namespace BDDTests.Steps
{
    [Binding]
    public sealed class CalculatorStepDefinitions
    {

       private readonly ScenarioContext _scenarioContext;

       public CalculatorStepDefinitions(ScenarioContext scenarioContext)
       {
           _scenarioContext = scenarioContext;
       }

      
    }
}
