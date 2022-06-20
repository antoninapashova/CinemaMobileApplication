using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
    class ReservationRequest
    {
        [JsonProperty("userID")]
        public int userID { get; set; }
        [JsonProperty("filmId")]
        public int filmID { get; set; }
        [JsonProperty("numberOfTickets")]
       public int numberOfTickets { get; set; }
        [JsonProperty("lastModified_18118032")]
        public DateTime lastModified_18118032 { get; set; }
    }
}
