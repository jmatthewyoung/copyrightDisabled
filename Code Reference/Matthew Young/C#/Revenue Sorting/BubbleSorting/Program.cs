using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BubbleSorting
{
    public class Program
    {
        static void Main(string[] args)
        {
            Listing one = new Listing(4, 1.00);
            Listing two = new Listing(3, 2.00);
            Listing three = new Listing(2, 3.00);
            Listing four = new Listing(1, 4.00);
            Listing[] listings = new Listing[200];
            listings[0] = one;
            listings[1] = two;
            listings[2] = three;
            listings[3] = four;

            Transaction t1 = new Transaction(listings[0], "Jan 4, 2001");
            Transaction t2 = new Transaction(listings[1], "Jan 4, 2001");
            Transaction t3 = new Transaction(listings[1], "Jan 4, 2001");
            Transaction t4 = new Transaction(listings[2], "Jan 4, 2001");
            Transaction t5 = new Transaction(listings[3], "Feb 1, 2004");
            Transaction t6 = new Transaction(listings[3], "Feb 1, 2004");
            Transaction t7 = new Transaction(listings[3], "Feb 1, 2004");
            Transaction t8 = new Transaction(listings[3], "Feb 1, 2004");
            Transaction[] transactions = new Transaction[200];
            transactions[0] = t1;
            transactions[1] = t2;
            transactions[2] = t3;
            transactions[3] = t4;
            transactions[4] = t5;
            transactions[5] = t6;
            transactions[6] = t7;
            transactions[7] = t8;


            String reportMessage = "";

            transactions.OrderBy(o => o.RentalDate.Year).ThenBy(o => o.RentalDate.Month);

            Revenue[] revenues = new Revenue[200];
            int count = 0;

            Revenue r1 = new Revenue();
            r1.Amount += transactions[0].Listing.Price;
            r1.Date = transactions[0].RentalDate;
            for(int i = 1; i < transactions.Length; i++)
            {
                if(transactions[i] != null)
                {
                    if (transactions[i].RentalDate.CompareTo(r1.Date) != 0)
                    {
                        revenues[count] = r1;
                        count++;
                        r1 = new Revenue();
                        r1.Amount += transactions[i].Listing.Price;
                        r1.Date = transactions[i].RentalDate;
                    }
                    else
                    {
                        r1.Amount += transactions[i].Listing.Price;
                    }
                }
            }
            revenues[count] = r1;

            for (int i = 0; i < revenues.Length; i++)
            {
                for(int j = i + 1; j < revenues.Length - 1; j++)
                {
                    if(revenues[j] != null)
                    {
                        if(revenues[i].Date.CompareTo(revenues[j].Date) < 0)
                        {
                            Revenue temp = revenues[i];
                            revenues[i] = revenues[j];
                            revenues[j] = temp;
                        }
                    }
                }
            }
            reportMessage += "Report 3\n";
            reportMessage += "Revenue | Date\n";
            reportMessage += "--------------\n";
            foreach (Revenue r in revenues)
            {
                if(r != null)
                {
                    reportMessage += String.Format("{0:C2} - | {1}\n", r.Amount, r.Date.ToShortDateString());
                }
            }
            Console.Out.Write(reportMessage);
            Console.ReadLine();
        }
    }

    public class Revenue
    {
        private double amount;
        private DateTime date;

        public Revenue()
        {
            amount = 0;
        }

        public double Amount
        {
            get
            {
                return amount;
            }

            set
            {
                amount = value;
            }
        }

        public DateTime Date
        {
            get
            {
                return date;
            }

            set
            {
                date = value;
            }
        }
    }

    public class Listing
    {
        private int id;
        private double price;
        

        public Listing(int id, double price)
        {
            this.id = id;
            this.price = price;
            
        }

        public double Price
        {
            get
            {
                return price;
            }

            set
            {
                price = value;
            }
        }

        public int Id
        {
            get
            {
                return id;
            }

            set
            {
                id = value;
            }
        }
    }



    public class Transaction
    {
        private Listing listing;
        private string rentalDateString;
        private DateTime rentalDate;

        public Transaction(Listing listing, string rentalDateString)
        {
            this.listing = listing;
            this.rentalDateString = rentalDateString;
            this.rentalDate = DateTime.Parse(rentalDateString);
        }

        public Listing Listing
        {
            get
            {
                return listing;
            }

            set
            {
                listing = value;
            }
        }

        public string RentalDateString
        {
            get
            {
                return rentalDateString;
            }

            set
            {
                rentalDateString = value;
            }
        }

        public DateTime RentalDate
        {
            get
            {
                return rentalDate;
            }

            set
            {
                rentalDate = value;
            }
        }
    }
}
