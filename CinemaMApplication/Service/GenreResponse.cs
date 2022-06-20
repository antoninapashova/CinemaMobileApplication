using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
    public class GenreResponse
    {
        [JsonProperty("GenreID")]
        public int genreID { get; set; }
        [JsonProperty("name")]
        public string name { get; set; }
    }
}
