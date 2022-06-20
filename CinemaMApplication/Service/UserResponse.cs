using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
    public class UserResponse
    {
        [JsonProperty("UserID")]
        public int userID { get; set; }
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
        [JsonProperty("reservations")]
        public IList<ReservationResponse> reservations { get; set; }
       
    }
}
