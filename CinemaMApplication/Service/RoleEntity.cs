using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace CinemaMApplication.Service
{
   public  class RoleEntity
    {
        [JsonProperty("role")]
        public string role { get; set; }
    }
}
