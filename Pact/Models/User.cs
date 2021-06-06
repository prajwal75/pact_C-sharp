using System;
using System.Collections.Generic;
using System.Text;

namespace Pact.Models
{
   public class User
    {
        public String name{ get; set; }

        public String job { get; set; }
    }

    public class user_response
    {
        public String name { get; set; }

        public String job { get; set; }

        public String id { get; set; }

        public String createdAt { get; set; }
    }

    public class get_user
    {
        public User_Data data { get; set; }

        public User_Support support { get; set; }

    }

                        public class User_Support
                        {

                            public String url { get; set; }
                            public String text { get; set; }
                        }

                        public class User_Data
                        {
                            public int id { get; set; }
                            public String email { get; set; }
                            public String first_name { get; set; }
                            public String last_name { get; set; }
                            public String avatar { get; set; }
                        }

    public class get_user_res
    {
        public User_Data_Res data { get; set; }

        public User_Support_Res support { get; set; }

    }

                        public class User_Support_Res
                        {

                            public String url { get; set; }
                            public String text { get; set; }
                        }

                        public class User_Data_Res
                        {
                            public int id { get; set; }
                            public String name { get; set; }
                            public int year { get; set; }
                            public String color { get; set; }
                            public String pantone_value { get; set; }
                        }



    public class Put_Request
    {
        public String name { get; set; }

        public String job { get; set; }
    }

    public class Put_Response
    {
        public String name { get; set; }

        public String job { get; set; }

        public String updatedAt { get; set; }
    }


    public class Post_un_req
    {
        public String email { get; set; }
    }
    public class Post_un_res
    {
        public String error { get; set; }
    }


    public class Post_login_req
    {
        public String email { get; set; }
        public String password { get; set; }
    }
    public class Post_login_res
    {
        public String token { get; set; }
    }


    public class GetUserList
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }

        public List<User_Data> data { get; set; }

        public User_Support_Res support { get; set; }
    }


    public class GetListResource
    {
        public int page { get; set; }
        public int per_page { get; set; }
        public int total { get; set; }
        public int total_pages { get; set; }

        public List<User_Data_Res> data { get; set; }

        public User_Support_Res support { get; set; }

    }
}
