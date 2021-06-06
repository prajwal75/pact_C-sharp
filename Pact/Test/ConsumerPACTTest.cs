using Pact.Consumer;
using Pact.Consumer.Mock;
using Pact.Models;
using PactNet.Matchers;
using PactNet.Mocks.MockHttpService;
using PactNet.Mocks.MockHttpService.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Pact.Test
{
    public class ConsumerPACTTest : IClassFixture<consumerpact>
    {
        private IMockProviderService _mockProviderService;
        private string _mockProviderServiceBaseUri;

        public ConsumerPACTTest(consumerpact data)
        {
            _mockProviderService = data.MockProviderService;
            _mockProviderService.ClearInteractions();
            _mockProviderServiceBaseUri = data.MockProviderServiceBaseUri;
        }

        [Fact]
        public void CreateBatchOfAccessCodes()
        {
            User accessCodes = new User();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";
            //Arrange
            _mockProviderService
                .Given("Invoking Post request")
                .UponReceiving("A Post request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/api/users",
                    Headers = new Dictionary<string, object>
                    {

                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = accessCodes
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 201,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        name = Match.Type("Prajwal"),
                        job = Match.Type("Engineer"),
                        id = Match.Type("378"),
                        createdAt = Match.Type("2021-05-27T07:45:47.513Z"),
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.CreateUser();
            Assert.Equal("Prajwal", result.name);
            _mockProviderService.VerifyInteractions();
        }
        [Fact]
        public void GetSingleUser()
        {
            //Arrange
            _mockProviderService
                .Given("Invoking Get request")
                .UponReceiving("A Get request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/users/2",
                   
                 
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        data= new
                        {
                            id=Match.Type(2),
                            email = Match.Type("abc@xyz.in"),
                            first_name = Match.Type("abc"),
                            last_name = Match.Type("xyz"),
                            avatar = Match.Type("Image"),

                        },

                        support = new
                        {
                            url = Match.Type("aaaaaaaaa"),
                            text = Match.Type("bbbbbbbbb"),
                        }

                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.GetSingleUser();
            Assert.Equal("abc", result.data.first_name);
            _mockProviderService.VerifyInteractions();

        }


        [Fact]
        public void GetSingleUserResponse()
        {
            //Arrange
            _mockProviderService
                .Given("Invoking Get resource request")
                .UponReceiving("A Get resource request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/unknown/2",


                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        data = new
                        {
                            id = Match.Type(2),
                            name = Match.Type("abc@xyz.in"),
                            year = Match.Type(1995),
                            color = Match.Type("xyz"),
                            pantone_value = Match.Type("Image"),
                        },

                        support = new
                        {
                            url = Match.Type("aaaaaaaaa"),
                            text = Match.Type("bbbbbbbbb"),
                        }
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result1 = consumer.GetSingleUserResponse();
            Assert.Equal("xyz", result1.data.color);
            _mockProviderService.VerifyInteractions();
          
        }


        [Fact]
        public void PutUser()
        {
            Put_Request accessCodes = new Put_Request();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";
            //Arrange
            _mockProviderService
                .Given("Invoking Put request")
                .UponReceiving("A Put request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Put,
                    Path = "/api/users/2",
                    Headers = new Dictionary<string, object>
                    {

                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = accessCodes
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        name = Match.Type("Prajwal"),
                        job = Match.Type("Engineer"),
                        updatedAt = Match.Type("2021-05-27T07:45:47.513Z"),
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.PutUser();
            Assert.Equal("Prajwal", result.name);
            _mockProviderService.VerifyInteractions();
        }

        [Fact]
        public void PatchUser()
        {
            Put_Request accessCodes = new Put_Request();

            accessCodes.name = "Prajwal";
            accessCodes.job = "Engineer";
            //Arrange
            _mockProviderService
                .Given("Invoking Patch request")
                .UponReceiving("A Patch request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Patch,
                    Path = "/api/users/2",
                    Headers = new Dictionary<string, object>
                    {

                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = accessCodes
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        name = Match.Type("Prajwal"),
                        job = Match.Type("Engineer"),
                        updatedAt = Match.Type("2021-05-27T07:45:47.513Z"),
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.PatchUser();
            Assert.Equal("Prajwal", result.name);
            _mockProviderService.VerifyInteractions();
        }


        [Fact]
        public void Post_Unscuccessfu()
        {
            Post_un_req accessCodes = new Post_un_req();

            accessCodes.email = "sydney@fife";
            //Arrange
            _mockProviderService
                .Given("Invoking Post unscuccess request")
                .UponReceiving("A Post unsuccess request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/api/register",
                    Headers = new Dictionary<string, object>
                    {

                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = accessCodes
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 400,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        error= Match.Type("Missing password"),
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.Post_Unscuccess();
            Assert.Equal("Missing password", result.error);
            _mockProviderService.VerifyInteractions();
        }

        [Fact]
        public void Post_login_success()
        {
            Post_login_req accessCodes = new Post_login_req();

            accessCodes.email = "eve.holt@reqres.in";
            accessCodes.password = "cityslicka";
            //Arrange
            _mockProviderService
                .Given("Invoking Post login request")
                .UponReceiving("A Post login request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Post,
                    Path = "/api/login",
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = accessCodes
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        token = Match.Type("QpwL5tke4Pnpja7X4"),
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result = consumer.Post_login();
            Assert.Equal("QpwL5tke4Pnpja7X4", result.token);
            _mockProviderService.VerifyInteractions();
        }

        [Fact]
        public void GetUsers()
        {
            //Arrange
            _mockProviderService
                .Given("Invoking Get all resource request")
                .UponReceiving("A Get resource request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/users",
                    Query=@"page=2",
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        page= Match.Type(2),
                        per_page = Match.Type(6),
                        total= Match.Type(12),
                        total_pages= Match.Type(2),

                        data = Match.MinType(new 
                        {
                            id = Match.Type(2),
                            email = Match.Type("abc@xyz.in"),
                            first_name = Match.Type("abc"),
                            last_name = Match.Type("xyz"),
                            avatar = Match.Type("Image"),
                        },3),

                        support = new
                        {
                            url = Match.Type("aaaaaaaaa"),
                            text = Match.Type("bbbbbbbbb"),
                        }
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result1 = consumer.GetUsers();
            Assert.Equal(2, result1.data[0].id);
            _mockProviderService.VerifyInteractions();
        }

        [Fact]
        public void GetUserList()
        {
            //Arrange
            _mockProviderService
                .Given("Invoking Get all user resource request")
                .UponReceiving("A Get resource request is created")
                .With(new ProviderServiceRequest
                {
                    Method = HttpVerb.Get,
                    Path = "/api/unknown",
                })
                .WillRespondWith(new ProviderServiceResponse
                {
                    Status = 200,
                    Headers = new Dictionary<string, object>
                    {
                        { "Content-Type", "application/json; charset=utf-8" }
                    },
                    Body = new
                    {
                        page = Match.Type(2),
                        per_page = Match.Type(6),
                        total = Match.Type(12),
                        total_pages = Match.Type(2),

                        data = Match.MinType(new
                        {
                            id = Match.Type(2),
                            name = Match.Type("abc@xyz.in"),
                            year = Match.Type(1998),
                            color = Match.Type("xyz"),
                            pantone_value = Match.Type("Image"),
                        }, 3),

                        support = new
                        {
                            url = Match.Type("aaaaaaaaa"),
                            text = Match.Type("bbbbbbbbb"),
                        }
                    }
                });

            var consumer = new APIclient(_mockProviderServiceBaseUri);
            var result1 = consumer.GetListRes();
            Assert.Equal(1998, result1.data[0].year);
            _mockProviderService.VerifyInteractions();
        }
    }
   }
