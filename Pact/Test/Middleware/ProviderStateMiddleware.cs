using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Pact.Test.Middleware
{
    class ProviderStateMiddleware
    {
        private const string ConsumerName = "NASM";
        private readonly RequestDelegate _next;
        private readonly IDictionary<string, Action> _providerStates;
        private int i = 0;
        private dynamic contractFile;

        public ProviderStateMiddleware(RequestDelegate next)
        {
            _next = next;
            _providerStates = new Dictionary<string, Action>
            {
                { "Invoking Post request", DummyMethod },
                { "Invoking Get request", DummyMethod },
                { "Invoking Get resource request", DummyMethod },
                { "Invoking Put request", DummyMethod },
                { "Invoking Patch request", DummyMethod },
                { "Invoking Post unscuccess request", DummyMethod },
                { "Invoking Post login request", DummyMethod },
                { "Invoking Get all resource request", DummyMethod },
                { "Invoking Get all user resource request", DummyMethod },
            };
        }
        private void DummyMethod()
        {
            //Blank method for provider state for no tasks
        }

        public async Task Invoke(HttpContext context)
        {
            if (context.Request.Path.Value == "/provider-states")
            {
                this.HandleProviderStatesRequest(context);
                await context.Response.WriteAsync(String.Empty);
            }
            else
            {
                await this._next(context);
            }
        }
        private void HandleProviderStatesRequest(HttpContext context)
        {
            context.Response.StatusCode = (int)HttpStatusCode.OK;
            string jsonRequestBody = String.Empty;
            //StreamReader reader = new StreamReader(@"/builds/cadp/nasm-ct-ua/NASM-CRM-UA/pacts/nasm-crm-ua.json", Encoding.UTF8);
            StreamReader reader = new StreamReader(@"../../../pacttest/dev-ua.json", Encoding.UTF8);
            jsonRequestBody = reader.ReadToEnd();

            contractFile = JValue.Parse(jsonRequestBody.ToString());
            while (i < contractFile.interactions.Count)
            {
                _providerStates[contractFile.interactions[i].providerState.Value].Invoke();
                i++;
            }
        }
    }
}
