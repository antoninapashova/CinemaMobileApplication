using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
    public class FilmResponse
    {

        [JsonProperty("filmID")]
        public int filmID { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
        [JsonProperty("description")]
        public string description { get; set; }
        [JsonProperty("ticketPrice")]
        public double ticketPrice { get; set; }
        [JsonProperty("duration")]
        public string duration { get; set; }
        [JsonProperty("start")]
        public DateTime start { get; set; }
        [JsonProperty("genre")]
        public GenreResponse genre { get; set; }
        [JsonProperty("cinemaRoom")]
        public CinemaRoomResponse cinemaRoom {get; set;}
        [JsonProperty("reservations")]
        public List<ReservationResponse> reservations { get; set; }
    }
}
