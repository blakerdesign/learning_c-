using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    class Guy
    {
        private String name;
        private int availableAmount = 0;
        private int sentAmount = 0;
        private int receivedAmount = 0;

        public Guy(int initialAmount, String name)
        {
            this.availableAmount = initialAmount;
            this.name = name;
        }

        public void receiveCash(int amountReceived)
        {
            this.availableAmount += amountReceived;
            this.receivedAmount += amountReceived;
        }

        public Boolean sendCash(int amountSent)
        {
            if (availableAmount >= amountSent)
            {
                this.availableAmount -= amountSent;
                this.sentAmount += amountSent;
                return true;
            }
            else
            {
                MessageBox.Show(this.getName() + " does not have enough money for that.");
                return false;
            }
        }

        public void setName(String name)
        {
            this.name = name;
        }

        public String getName()
        {
            return this.name;
        }

        public int getAvailableAmount()
        {
            return this.availableAmount;
        }

        public int getSentAmount()
        {
            return this.sentAmount;
        }

        public int getReceievedAmount()
        {
            return this.receivedAmount;
        }

    }
}
