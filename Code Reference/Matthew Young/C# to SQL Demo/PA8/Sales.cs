using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA8
{
    public class Sale
    {
        private int id;
        private string name;

        public Sale(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        public int ID
        {
            get { return id; }
        }

        public string Name
        {
            get { return name; }
        }
    }
}
