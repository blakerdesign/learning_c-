using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        List<Guy> guys = new List<Guy>();

        public Form1()
        {
            InitializeComponent();
            setupOptions();
        }

        private void setupOptions()
        {
            
            Guy guy1 = new Guy(1200, "Bob");
            Guy guy2 = new Guy(800, "Steve");
            Guy guy3 = new Guy(50000, "Brutus");
            guys.Add(guy1);
            guys.Add(guy2);
            guys.Add(guy3);

            populateListItems();
            
        }

        private void populateListItems()
        {
            toGuy.Items.Clear();
            fromGuy.Items.Clear();

            for (int i = 0; i < guys.Count(); i++)
            {
                toGuy.Items.Add(generateListOptionString(guys[i]));
                fromGuy.Items.Add(generateListOptionString(guys[i]));
            }
        }

        private String generateListOptionString(Guy someGuy)
        {
            return someGuy.getName() + " ( $" + someGuy.getAvailableAmount().ToString() + " )";
        }

        private Boolean compareTransferingToAndFrom()
        {
            int fromIndex = fromGuy.SelectedIndex;
            int toIndex = toGuy.SelectedIndex;

            if (fromIndex == toIndex)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void transfer_Click(object sender, EventArgs e)
        {

            if (fromGuy.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter someone to transfer money from.");
                return;
            }

            if (toGuy.SelectedIndex == -1)
            {
                MessageBox.Show("Please enter someone to transfer money to.");
                return;
            }

            if (amount.Text == "")
            {
                MessageBox.Show("You need to enter an amount.");
                return;
            }

            if (compareTransferingToAndFrom())
            {
                Guy selectedFromGuy = guys[fromGuy.SelectedIndex];
                Guy selectedToGuy = guys[toGuy.SelectedIndex];
                int amountToTransfer = Convert.ToInt32(amount.Text);

                Boolean transferPossible = selectedFromGuy.sendCash(amountToTransfer);

                if (transferPossible)
                {
                    selectedToGuy.receiveCash(amountToTransfer);

                    String messageString = selectedFromGuy.getName() + " now has $" + Convert.ToString(selectedFromGuy.getAvailableAmount());
                    messageString += ", and ";
                    messageString += selectedToGuy.getName() + " now has $" + Convert.ToString(selectedToGuy.getAvailableAmount());

                    //MessageBox.Show(messageString);

                    guyStats.Text = selectedFromGuy.getName() + " has transferred a total of " + selectedFromGuy.getSentAmount().ToString() + ". Has receieved a total of " + selectedFromGuy.getReceievedAmount().ToString() + ".";
                    guyStats.Text += " " + selectedToGuy.getName() + " has transferred a total of " + selectedToGuy.getSentAmount().ToString() + ". Has receieved a total of " + selectedToGuy.getReceievedAmount().ToString() + ".";

                    amount.Text = "";
                    populateListItems();
                }
            }
            else
            {
                MessageBox.Show("You cannot transfer money to the same person who wishes to send it! IDIOT!");
            }

        }

    }
}
