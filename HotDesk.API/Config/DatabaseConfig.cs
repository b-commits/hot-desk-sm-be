using System;
namespace HotDesk.API.Config
{
    public class DatabaseConfig
    {
        public string DatabaseName { get; set; }

        public string ConnectionString { get; set;  }

        public string ReservationsCollectionName { get; set; }

        public string LocationsCollectionName { get; set; }

        public string DesksCollectionName { get; set;  }

    }
}

