using PactNet;
using PactNet.Mocks.MockHttpService;
using System;
using System.Collections.Generic;
using System.Text;

namespace Pact.Consumer
{
    public class consumerpact:IDisposable
    {
        public IPactBuilder PactBuilder { get; private set; }
        public IMockProviderService MockProviderService { get; private set; }
        public int MockServerPort { get { return 9229; } }
        public string MockProviderServiceBaseUri { get { return String.Format("http://localhost:{0}", MockServerPort); } }
        public consumerpact()
        {
            //Pact Configuration
            var pactConfig = new PactConfig
            {
                SpecificationVersion = "2.0.0",
                PactDir = @"..\..\..\pacttest",
                LogDir = @"..\..\..\pact_logs"
            };
            PactBuilder = new PactBuilder(pactConfig);

            PactBuilder.ServiceConsumer("Dev").HasPactWith("UA");

            MockProviderService = PactBuilder.MockService(MockServerPort);
        }
       public void Dispose()
        {
            PactBuilder.Build();
        }
    }
}
