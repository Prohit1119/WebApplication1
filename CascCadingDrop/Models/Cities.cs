using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CascCadingDrop.Models
{
    public class Cities
    {
        public int CitieID { get; set; }

        public string CitieName { get; set; }
    }

    public class State
    {
        public int StateID { get; set; }    

        public string StateName { get; set; } = string.Empty;

        public int CitiesId { get; set; }
    }
}