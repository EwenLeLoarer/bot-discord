using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bot_discord
{
    public struct ConfigMALJson
    {
        public class AnimeStats
        {
            [JsonProperty("days Watch")]
            public double days_watched { get; set; }
            public double mean_score { get; set; }
            public int watching { get; set; }
            public int completed { get; set; }
            public int on_hold { get; set; }
            public int dropped { get; set; }
            public int plan_to_watch { get; set; }
            public int total_entries { get; set; }
            public int rewatched { get; set; }
            public int episodes_watched { get; set; }

        }

        public class MangaStats
        {
            public double days_read { get; set; }
            public int mean_score { get; set; }
            public int reading { get; set; }
            public int completed { get; set; }
            public int on_hold { get; set; }
            public int dropped { get; set; }
            public int plan_to_read { get; set; }
            public int total_entries { get; set; }
            public int reread { get; set; }
            public int chapters_read { get; set; }
            public int volumes_read { get; set; }

        }

        public class Character
        {
            public int mal_id { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public string name { get; set; }

        }

        public class Favorites
        {
            public List<object> anime { get; set; }
            public List<object> manga { get; set; }
            public List<Character> characters { get; set; }
            public List<object> people { get; set; }

        }

        public class Root
        {
            public string request_hash { get; set; }
            public bool request_cached { get; set; }
            public int request_cache_expiry { get; set; }
            public int user_id { get; set; }
            public string username { get; set; }
            public string url { get; set; }
            public string image_url { get; set; }
            public DateTime last_online { get; set; }
            public object gender { get; set; }
            public object birthday { get; set; }
            public string location { get; set; }
            public DateTime joined { get; set; }
            public AnimeStats anime_stats { get; set; }
            public MangaStats manga_stats { get; set; }
            public Favorites favorites { get; set; }
            public object about { get; set; }

        }

    }
}
