using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
    public class ReservationResponse
    {
        [JsonProperty("reservationID")]
        public int  reservationId { get; set; }
        [JsonProperty("film")]
        public FilmResponse filmResponse { get; set; }
        [JsonProperty("numberOfTickets")]
        public int numberOfTickets { get; set; }
    }
}
