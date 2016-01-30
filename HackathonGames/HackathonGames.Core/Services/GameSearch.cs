using HackathonGames.Core.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace HackathonGames.Core
{
    public class GameSearch
    {
        private const string GiantBombApiKey = "2beb382fcdfd6deffa3b0bd8781c14c6d2b01cdd";
        
        public static GameSearchResult getGameSearchResultsFor(string gameName)
        {
            using (WebClient wc = new WebClient())
            {
                string json = wc.DownloadString($"http://www.giantbomb.com/api/search/?api_key={GiantBombApiKey}&format=json&query={gameName}&resources=game");
                
                var oResults = JsonConvert.DeserializeObject<GameSearchResult>(json);
                return oResults;
            }
        }
    }
}