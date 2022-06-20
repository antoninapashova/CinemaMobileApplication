using Newtonsoft.Json;
using System;


namespace CinemaMApplication.Service
{
    public class UserRequest
    {
        
        [JsonProperty("username")]
        public string username { get; set; }
        [JsonProperty("firstName")]
        public string firstName { get; set; }
        [JsonProperty("lastName")]
        public string lastName { get; set; }
        [JsonProperty("roleID")]
        public int roleID { get; set; }
        [JsonProperty("email")]
        public string email { get; set; }
        [JsonProperty("phone")]
        public string phone { get; set; }
        [JsonProperty("password")]
        public string password { get; set; }

        [JsonProperty("lastModified_18118032")]
        public DateTime lastModified_18118032 { get; set; }
    }
}
