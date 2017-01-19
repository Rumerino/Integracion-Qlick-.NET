using System;
using System.Collections.Generic;
using System.Linq;

namespace QlikSense
{
    public class Application
    {
        private string AppId;
        private ILocation Location;

        public string Id { get { return AppId; } }
        public string Language { get; set; }
        public string Ticket { get; set; }
        
        public Application(ILocation location)
        {
            Location = location;
            Language = "en";
        }
    }
}
