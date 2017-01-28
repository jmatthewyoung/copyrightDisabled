using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PA8
{
    public partial class Form1 : Form
    {
        List<Sale> sales;
        List<Order> orders;
        List<Sale> currentSales = new List<Sale>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sales = new List<Sale>(10);
            orders = new List<Order>(10);

            for(int i = 0; i < 10; i++)
            {
                Sale sale = new Sale(i*2, ("a"));
                Order order = new Order(i, ("b"));

                sales.Add(sale);
                orders.Add(order);

                orders[i].setSale(sales[i]);
            }

            BindGrid();
        }

        private void BindGrid()
        {
            dgv1.DataSource = typeof(Order);
            dgv1.DataSource = orders;
        }

        private void BindGrid2()
        {
            dgv2.DataSource = typeof(Sale);
            dgv2.DataSource = currentSales;
        }

        private void dgv1_SelectionChanged(object sender, EventArgs e)
        {
            List<int> ids = new List<int>();
            ids.Clear();
            for(int i = 0; i < dgv1.SelectedRows.Count; i++)
            {
                ids.Add(Int32.Parse(dgv1.SelectedRows[i].Cells["ID"].Value.ToString()));
            }

            currentSales.Clear();

            for (int i = 0; i < orders.Count; i++)
            {
                for (int j = 0; j < ids.Count; j++)
                {
                    if (orders[i].ID == ids[j])
                    {
                        currentSales.Add(orders[i].getSale());
                    }
                }
            }

            BindGrid2();
        }
    }
}
