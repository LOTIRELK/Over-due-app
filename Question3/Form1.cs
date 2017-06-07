using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Question3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //convert day to int
            string d = cboDay.Text;
            int day = Convert.ToInt32(d);

            //convert month to integer representation
            string m = cboMonth.Text;
            int month = DateTime.ParseExact(m, "MMMM", System.Globalization.CultureInfo.InvariantCulture).Month;

            //convert year to int
            string y = cboYear.Text;
            int year = Convert.ToInt32(y);

            //date entered is duedate
            DateTime dueDate = new DateTime(year, month, day);

            //get current date
            DateTime currentDate = DateTime.Now;

            ////subtract to get days overdue
            TimeSpan numDays = currentDate.Subtract(dueDate);
            int days = numDays.Days;
            //create double variable for fee
            double fee = 0;
            //if due date is in the future
            if (dueDate > currentDate)
            {
                txtFeeDue.Text = "No Fee Due";
            }
            else
            {
                //if num days less or equal to 10
                if (days <= 10)
                {
                    //for each day add 0.50c to fee
                    for (int i = 1; i <= days; i++)
                    {
                        fee += 0.50; ;
                    }
                }
                //if num days greater than 10 and less than 20
                else if (days > 10 && days < 20)
                {
                    //fee is amount for 10 days + num remaining days 
                    //num of days -10 to get remaining days
                    fee = 5;
                    days -= 10;
                    for (int i = 0; i < days; i++)
                    {
                        fee += 1;
                    }
                }
                //if num days greater than or equal to 20
                else if (days >= 20)
                {
                    //fee is amount for 19 days + num remaining days 
                    //num of days -19 to get remaining days
                    fee = 14;
                    days -= 19;
                    for (int i = 1; i < days; i++)
                    {
                        fee += 2;
                    }
                }
                txtFeeDue.Text = fee.ToString("c");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
