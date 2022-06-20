using Newtonsoft.Json;
using System;

namespace CinemaMApplication.Service
{
    class FilmRequest
    {
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("genreID")]
        public int genreID { get; set; }
        [JsonProperty("cinemaRoomID")]
        public int cinemaRoomID { get; set; }
        [JsonProperty("ticketPrice")]
        public double ticketPrice { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("start")]
        public DateTime start { get; set; }
        [JsonProperty("lastModified_18118032")]
        public DateTime lastModified_18118032 { get; set; }

    }
}
