using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28.Classes
{
    public class RentCs
    {
        public int id {  get; set; }
        public DateTime time_rent { get; set; }
        public string name_client { get; set; }
        public int idClub {  get; set; }
        public string nameClub { get; set; }

        public RentCs(int id, DateTime time_rent, string name_client, int idClub, string nameClub) 
        {
            this.id = id;
            this.time_rent = time_rent;
            this.name_client = name_client;
            this.idClub = idClub;
            this.nameClub = nameClub;
        }

        public RentCs(DateTime time_rent, string name_client, int idClub)
        {
            this.time_rent = time_rent;
            this.name_client = name_client;
            this.idClub = idClub;
        }
    }
}
