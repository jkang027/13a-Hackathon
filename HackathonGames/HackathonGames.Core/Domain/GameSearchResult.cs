using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackathonGames.Core.Domain
{
    public class GameSearchResult
    {
        public List<Result> results { get; set; }
        public int number_of_total_results { get; set; }
    }
}
