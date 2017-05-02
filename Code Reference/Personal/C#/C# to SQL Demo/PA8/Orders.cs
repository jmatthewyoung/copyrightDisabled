using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PA8
{
    public class Order
    {
        private int id;
        private string name;
        private Sale sale;

        public Order(int id, string name)
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

        public Sale getSale()
        {
            return sale;
        }
        public void setSale(Sale sale)
        {
            this.sale = sale;
        }
    }
}
