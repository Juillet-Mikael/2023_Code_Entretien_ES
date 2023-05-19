using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Selling
{
    /// <summary>
    /// This class is designed to manage vending machine
    /// </summary>
    public class VendingMachine
    {
        private List<Article> _articleList;
        private decimal _change;
        private decimal _balance;
        private List<Purchase> _puchaseList = new List<Purchase>();

        /// <summary>
        /// This constructor allow to create a new VendingMachine object
        /// </summary>
        /// <param name="articles"> Need to pass a list of Articles </param>
        public VendingMachine(List<Article> articles) {
            _articleList = articles;
            _change = 0;
            _balance = 0;
        }

        /// <summary>
        /// Used to chose one article in the vending machine. 
        /// </summary>
        /// <param name="articleCode"> Need to pass article code in string </param>
        /// <returns> Return a string with the information about the transaction </returns>
        public string ChooseArticle(string articleCode)
        {
            foreach (var article in _articleList)
            {
                if (article.Code == articleCode)
                {
                    // If there's not VendingMachine
                    if (_change < article.Price)
                    {
                        return "Not enough money!";
                    }

                    // Check if  there's a sufficient quantity of the article 
                    if (article.Quantity <= 0)
                    {
                        return "Item " + article.Name + ": Out of stock!";
                    }

                        
                    article.Remove(1);
                    _change -= article.Price;
                    _balance += article.Price;
                    _puchaseList.Add(new Purchase(DateTimeProvider.Now, article.Price));
                    
                    return "Vending " + article.Name;

                }
            }
            return "Invalid selection!";
        }

        /// <summary>
        /// Used to insert change in the machine 
        /// </summary>
        /// <param name="amount"> The amount of changes inserted in double</param>
        public void InsertCredits(decimal amount) 
        {
            _change += amount;
        }

        /// <summary>
        /// Used to get the 3 best turnover of the puchases. 
        /// </summary>
        /// <returns> Returns a string formated for the top 3 => Hour "purchaseHour" generated a revenue of "amount" </returns>
        public string BestTurnover() 
        {
            //Solution was fount on this site : https://learn.microsoft.com/en-us/dotnet/api/system.collections.generic.list-1.sort?view=net-7.0
            List<Tuple<int, decimal>> purchaseByHour = new List<Tuple<int, decimal>>();

            decimal total = 0;
            string result = "";

            //Check for each hours if there's puchase and totalise the price of each one
            for (int hour = 0; hour < 24; hour ++)
            {
                foreach(var purchase in _puchaseList)
                {
                    if (hour == purchase.Date.Hour)
                    {
                        total = total + purchase.Amount;
                    }
                }

                //Create a purchaseByHour List with int for hour and decimal for the total price
                if (total != 0)
                {
                    purchaseByHour.Add(new Tuple<int, decimal>(hour, total));
                }
                total = 0;
            }

            //Order by decending to get top 3 element first
            purchaseByHour = purchaseByHour.OrderByDescending(t => t.Item2).ToList();

            //Create return string
            for (int i = 0; i < 3; i++)
            {
                result = result.Insert(result.Length, "Hour "+ purchaseByHour[i].Item1 +" generated a revenue of " + purchaseByHour[i].Item2 + "\r\n");             
            }

            //Remove whitespace and newline characters at the end of the string (\r\n)
            return result.TrimEnd();
        }

        /// <summary>
        /// Allows to get change
        /// </summary>
        public decimal Change
        {
            get
            {
                return _change;
            }
        }

        /// <summary>
        /// Allows to get balance
        /// </summary>
        public decimal Balance
        {
            get 
            {
                return _balance; 
            }
        }
    }
}
