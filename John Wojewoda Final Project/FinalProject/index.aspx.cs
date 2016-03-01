using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FinalProject
{
    public partial class index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetFocus(txtFirstName);
            }
        }

        public bool Validate_Name(string val, TextBox box)
        {
            bool retval = false;
            // remove numbers
            val = val.Replace("1", "");
            val = val.Replace("2", "");
            val = val.Replace("3", "");
            val = val.Replace("4", "");
            val = val.Replace("5", "");
            val = val.Replace("6", "");
            val = val.Replace("7", "");
            val = val.Replace("8", "");
            val = val.Replace("9", "");
            val = val.Replace("0", "");
            //remove special charactes
            val = val.Replace("~", "");
            val = val.Replace("!", "");
            val = val.Replace("@", "");
            val = val.Replace("#", ""); ;
            val = val.Replace("^", "");
            val = val.Replace("+", "");
            val = val.Replace("\\", "");
            val = val.Replace("/", "");
            val = val.Replace("&", "");

            box.Text = val; // assign the value back to the text box
            if (val.Length > 0)
            {
                retval = true;
            }
            else
            {
                retval = false;
            }
            return retval;
        }

        public void ClearScreen()
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = string.Empty;
            txtHours.Text = string.Empty;
            txtRate.Text = string.Empty;
            txtFirstNameOut.Text = string.Empty;
            txtLastNameOut.Text = string.Empty;
            txtHoursOut.Text = string.Empty;
            txtOverTimeHours.Text = string.Empty;
            txtRegularPay.Text = string.Empty;
            txtOverTimePay.Text = string.Empty;
            txtRateOut.Text = string.Empty;
            txtGrossOut.Text = string.Empty;
            txtTaxOut.Text = string.Empty;
            txtNetOut.Text = string.Empty;
            lblError.Text = string.Empty;
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            string firstName = string.Empty;//declare variables
            string lastName = string.Empty;

            

            string hours = string.Empty;
            string rate = string.Empty;

            decimal dHours = 0M;
            decimal dRate = 0M;

            decimal dHoursOut = 0M;
            decimal dRateOut = 0M;
            decimal dOverTimeHoursOut = 0M;
            decimal dRegularPayOut = 0M;
            decimal dOverTimePayOut = 0M;

            decimal dGrossOut = 0M;
            decimal dTaxOut = 0M;
            decimal dNetOut = 0M;

            firstName = txtFirstName.Text;//grab data from the screen
            lastName = txtLastName.Text;

            if (Validate_Name(firstName, txtFirstName))
            {
                txtFirstNameOut.Text = txtFirstName.Text;
            }

            if (Validate_Name(lastName, txtLastName))
            {
                txtLastNameOut.Text = txtLastName.Text;
            }

            hours = txtHours.Text;
            rate = txtRate.Text;

            if (Validate_Decimal(rate))
            {
                dRate = Convert.ToDecimal(rate);
            }
            else
            {
                lblError.Text = "Rate is InValid";
            }

            dHours = Convert.ToDecimal(hours);//convert to decimal data type
            

            

           
            dHoursOut = dHours;//do the calculations
            dRateOut = dRate;
            if (dHours >= 41M)
            {
                dOverTimeHoursOut = dHours - 40M;
            }
            else
            {
                dOverTimeHoursOut = 0M;
            }
            dRegularPayOut = (dHours - dOverTimeHoursOut) * dRate;
            dOverTimePayOut = dOverTimeHoursOut * (dRate * 1.5M);
            dGrossOut = dRegularPayOut + dOverTimePayOut;
            dTaxOut = dGrossOut *  0.24M;
            dNetOut = dGrossOut - dTaxOut;

            //display data
            
            txtHoursOut.Text = hours.ToString();
            txtOverTimeHours.Text = dOverTimeHoursOut.ToString();
            txtRegularPay.Text = dRegularPayOut.ToString("f2");
            txtOverTimePay.Text = dOverTimePayOut.ToString("f2");
            txtRateOut.Text = rate.ToString();
            txtGrossOut.Text = dGrossOut.ToString("f2");
            txtTaxOut.Text = dTaxOut.ToString("f2");
            txtNetOut.Text = dNetOut.ToString("f2");
            
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearScreen();
        }
        public bool Validate_Decimal(string val)
        {
            decimal valConverted = 0.0M;
            try
            {
                valConverted = Convert.ToDecimal(val);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}