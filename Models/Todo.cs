using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace HttpClientSample.Models
{
    public class Todo
    {
        [JsonProperty("userId")]
        public int UserId { get; set; }

        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("completed")]
        public bool Completed { get; set; } = false;

    }
}
