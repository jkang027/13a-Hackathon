using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonGames.Core.Domain
{
    public class Result
    {
        public string name { get; set; }
        public string description { get; set; }
        public string deck { get; set; }
        public int number_of_user_reviews { get; set; }
        public string original_release_date { get; set; }
        public Image image { get; set; }
        public List<Platform> platforms { get; set; }
    }
}
