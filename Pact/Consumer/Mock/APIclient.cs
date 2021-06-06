using Pact.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;

namespace Pact.Consumer.Mock
{
    public class APIclient
    {
        private readonly HttpClient _client;



        public APIclient(string baseUri = null)
        {
            _client = new HttpClient { BaseAddress = new Uri(baseUri ?? "http://localhost:60881") };
        }

        public user_response CreateUser()
        {
            string reasonPhrase;
            User accessCodes = new User();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";
           
            var output = JsonConvert.SerializeObject(accessCodes);
            var stringContent = new StringContent(output, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/users");
           // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
            request.Content = stringContent;

            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.Created)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<user_response>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);

        }

        public get_user GetSingleUser()
        {
            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users/2");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
          
            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<get_user>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);
         }

        public get_user_res GetSingleUserResponse()
        {
            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/unknown/2");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<get_user_res>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);
        }


        public Put_Response PutUser()
        {
            string reasonPhrase;
            Put_Request accessCodes = new Put_Request();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";

            var output = JsonConvert.SerializeObject(accessCodes);
            var stringContent = new StringContent(output, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Put, "/api/users/2");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
            request.Content = stringContent;

            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<Put_Response>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);

        }


        public Put_Response PatchUser()
        {
            string reasonPhrase;
            Put_Request accessCodes = new Put_Request();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";

            var output = JsonConvert.SerializeObject(accessCodes);
            var stringContent = new StringContent(output, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Patch, "/api/users/2");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
            request.Content = stringContent;

            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<Put_Response>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);

        }


        public Post_un_res Post_Unscuccess()
        {
            string reasonPhrase;
            Post_un_req accessCodes = new Post_un_req();

            accessCodes.email = "sydney@fife";
            
            var output = JsonConvert.SerializeObject(accessCodes);
            var stringContent = new StringContent(output, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/register");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
            request.Content = stringContent;

            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body
            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.BadRequest)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<Post_un_res>(content)
                  : null;
            }
            throw new Exception(reasonPhrase);
        }

        public Post_login_res Post_login()
        {
            string reasonPhrase;
            Post_login_req accessCodes = new Post_login_req();

            accessCodes.email = "eve.holt@reqres.in";
            accessCodes.password = "cityslicka";

            var output = JsonConvert.SerializeObject(accessCodes);
            var stringContent = new StringContent(output, Encoding.UTF8, "application/json");
            var request = new HttpRequestMessage(HttpMethod.Post, "/api/login");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");
            request.Content = stringContent;

            var response = _client.SendAsync(request);
            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body
            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)    
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<Post_login_res>(content)
                  : null;
            }
            throw new Exception(reasonPhrase);
        }

        public GetUserList GetUsers()
        {
            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/users?page=2");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<GetUserList>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);
        }

        public GetListResource GetListRes()
        {
            string reasonPhrase;
            var request = new HttpRequestMessage(HttpMethod.Get, "/api/unknown");
            // request.Headers.Add("Authorization", "Token token=c02920d6-1a49-45a4-9060-24664574b881");

            var response = _client.SendAsync(request);

            var content = response.Result.Content.ReadAsStringAsync().Result;
            var status = response.Result.StatusCode;

            reasonPhrase = response.Result.ReasonPhrase; //NOTE: any Pact mock provider errors will be returned here and in the response body

            request.Dispose();
            response.Dispose();

            if (status == HttpStatusCode.OK)
            {
                return !String.IsNullOrEmpty(content) ?
                  JsonConvert.DeserializeObject<GetListResource>(content)
                  : null;
            }

            throw new Exception(reasonPhrase);
        }
    }
}
