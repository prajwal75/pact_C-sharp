using Pact.Outputter;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using PactNet;
using PactNet.Infrastructure.Outputters;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace Pact.Test
{
   public class ProviderPACTTest
    {
        private string _providerUri { get; }
        private string _pactServiceUri { get; }
        private IWebHost _webHost { get; }

        private readonly ITestOutputHelper _output;

        public ProviderPACTTest(ITestOutputHelper output)
        {
            _output = output;
            _providerUri = "https://reqres.in";
            _pactServiceUri = "https://localhost:5003";

            _webHost = WebHost.CreateDefaultBuilder()
                .UseUrls(_pactServiceUri)
                .UseStartup<TestStartup>()
                .Build();

            _webHost.Start();
        }

        [Fact]
        public void TestProvider()
        {
            var config = new PactVerifierConfig
            {
                Outputters = new List<IOutput> //NOTE: We default to using a ConsoleOutput, however xUnit 2 does not capture the console output, so a custom outputter is required.
                {
                    new XUnitOutput(_output)
                },

                Verbose = true //Output verbose verification logs to the test output
            };

            new PactVerifier(config).ProviderState($"{_pactServiceUri}/provider-states")
                .ServiceProvider("UA", _providerUri)
                .HonoursPactWith("Dev")
                .PactUri(@"..\..\..\pacttest\dev-ua.json")
                .Verify();
        }

    }
}
