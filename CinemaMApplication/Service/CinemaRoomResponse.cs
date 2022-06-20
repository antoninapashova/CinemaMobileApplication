using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
   public  class CinemaRoomResponse
    {
        [JsonProperty("cinemaRoomId")]
        public int cinemaRoomId { get; set; }
        [JsonProperty("number")]
        public string number { get; set; }
        [JsonProperty("seats")]
        public int seats { get; set; }
    }
}
