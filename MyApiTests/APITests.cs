namespace MyApiTests
{
    public class ApiTests
    {
        private readonly ITestOutputHelper output;

        [Fact]
        public void Test_Get_API_Call()
        {
            // Arrange
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("/api/users", Method.Get);

            // Act
            var response = client.Execute(request);
            output.WriteLine("This is a test output message.");

            // Assert
            Assert.True(response.IsSuccessful);
            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);
            Assert.Contains("name", response.Content);
        }
        private readonly RestClient _client;


        public ApiTests(ITestOutputHelper output)
        {
            _client = new RestClient();
            this.output = output;
        }

        [Fact]
        public void Test_Post_API_Calls()
        {
            var _client = new RestClient("https://reqres.in/");
            var request = new RestRequest("https://reqres.in/api/users", Method.Post);

            const string reqbody = @"{""name"":""Avipsa1 Mishra"",""Job"":""SeniorSoftwareEngineer""}";

            request.AddJsonBody(reqbody);

            var response = _client.Execute(request);

            //    dynamic responseData = JsonConvert.DeserializeObject<dynamic>(response.Content);
            //    output.WriteLine("Outputtttttt",responseData.name);   

            if (response.IsSuccessful)
            {
                // Successful response
                output.WriteLine("Request succeeded!");
                output.WriteLine(response.Content);
            }
            else
            {
                // Error handling
                output.WriteLine("Request failed!");
                output.WriteLine(response.ErrorMessage);
            }

            // Assert
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
            Assert.NotNull(response.Content);
            Assert.NotEmpty(response.Content);
            Assert.Contains("name", response.Content);
            // Assert.Equal("Avipsa1 Mishra", response.Content);
            // Assert.Equal(reqbody, response.Content);

        }
        [Fact]
        public void Test_Put_API_Call()
        {

            var client = new RestClient("https://reqres.in/");
            var request = new RestRequest("api/users/{id}", Method.Put);
            request.AddUrlSegment("id", "25");
            const string putreqbody = @"{""name"":""Avipsa1 Mishra"",""Job"":""SSoftwareEngineer""}";

            request.AddJsonBody(putreqbody);
            var response = client.Execute(request);

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);
            Assert.NotNull(response.Content);

        }

        [Fact]
        public void Test_Delete_API_Call()
        {
            // Create a RestClient and RestRequest
            var client = new RestClient("https://reqres.in");
            var request = new RestRequest("/api/users/{id}", Method.Delete);

            // Set the route parameter
            request.AddUrlSegment("id", "5");
            var response = client.Execute(request);

            // Assert the response status code
            Assert.Equal(System.Net.HttpStatusCode.NoContent, response.StatusCode);
            Assert.Empty(response.Content);

        }
    }
}
