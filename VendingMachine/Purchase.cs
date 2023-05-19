using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling
{
    /// <summary>
    /// This class is designed to manage purchase
    /// </summary>
    public class Purchase
    {
        private DateTime _date;
        private decimal _amount;

        /// <summary>
        /// This constructor allow to create a new Purchase object
        /// </summary>
        /// <param name="date"> Date of purchase </param>
        /// <param name="amount"> Price of the purchase </param>
        public Purchase(DateTime date, decimal amount)
        {
            _date = date;
            _amount = amount;
        }

        /// <summary>
        /// Allows to get amount 
        /// </summary>
        public decimal Amount 
        { 
            get 
            { 
                return _amount; 
            } 
        }
        
        /// <summary>
        /// Allows to get date
        /// </summary>
        public DateTime Date
        {
            get
            {
                return _date;
            }
        }
    }
}
