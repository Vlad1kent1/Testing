using RestSharp;
using TechTalk.SpecFlow;

namespace lab3_Testing.Steps.Part2
{
    [Binding]
    public class OwenWilsonApiSteps
    {
        private RestClient client;
        private RestRequest request;
        private RestResponse response;
        private string? year;

        public OwenWilsonApiSteps()
        {
            client = new RestClient("https://owen-wilson-wow-api.onrender.com/");
            request = new RestRequest();
            response = new RestResponse();
        }

        [When(@"I request a random ""wow"" moment")]
        public void WhenIRequestARandomWowMoment()
        {
            request = new RestRequest("wows/random", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"I should receive a ""wow"" moment details")]
        public void ThenIShouldReceiveAWowMomentDetails()
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content?.Contains("wow"));
        }

        [When(@"I request all ""wow"" moments")]
        public void WhenIRequestAllWowMoments()
        {
            request = new RestRequest("wows/all", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"I should receive a list of ""wow"" moments")]
        public void ThenIShouldReceiveAListOfWowMoments()
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content?.Contains("wow"));
        }

        [Given(@"I have a specific year ""(.*)""")]
        public void GivenIHaveASpecificYear(string specificYear)
        {
            year = specificYear;
        }

        [When(@"I request ""wow"" moments for that year")]
        public void WhenIRequestWowMomentsForThatYear()
        {
            request = new RestRequest($"wows/random?year={year}", Method.Get);
            response = client.Execute(request);
        }

        [Then(@"I should receive ""wow"" moments from ""(.*)""")]
        public void ThenIShouldReceiveWowMomentsFrom(string specificYear)
        {
            Assert.IsNotNull(response);
            Assert.IsTrue(response.Content?.Contains("wow"));
            Assert.IsTrue(response.Content?.Contains(specificYear));
        }
    }
}