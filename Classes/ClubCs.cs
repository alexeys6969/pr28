using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pr28.Classes
{
    public class ClubCs
    {
        public int id {  get; set; }
        public string name { get; set; }
        public string adress { get; set; }

        public ClubCs(int id, string name, string adress) 
        {
            this.id = id;
            this.name = name;
            this.adress = adress;
        }

        public ClubCs(string name, string adress)
        {
            this.name = name;
            this.adress = adress;
        }

        public ClubCs() { }
    }
}
