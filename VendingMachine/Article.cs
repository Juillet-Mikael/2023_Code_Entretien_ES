using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selling
{
    /// <summary>
    /// This class is designed to manage Article
    /// </summary>
    public class Article
    {
        private string _name;
        private string _code;
        private int _quantity;
        private decimal _price;

        /// <summary>
        /// This constructor allow to create a new Article object
        /// </summary>
        /// <param name="name"> Name of the article in string </param>
        /// <param name="code"> Code of the article in string </param>
        /// <param name="quantity"> Quantity of the article in int </param>
        /// <param name="price"> Price of the article in decimal (ex. 1.90m) </param>
        public Article(string name, string code, int quantity, decimal price) 
        {
            _name = name;
            _code = code;
            _quantity = quantity;
            _price = price;
        }

        /// <summary>
        /// Remouve a certain amount of article
        /// </summary>
        /// <param name="number"> Number of article to remove </param>
        public void Remove(int number)
        {
            _quantity -= number;
        }

        /// <summary>
        /// Allows to get the article name
        /// </summary>
        public string Name 
        { 
            get 
            { 
                return _name; 
            } 
        }

        /// <summary>
        /// Allows to get the article code
        /// </summary>
        public string Code 
        { 
            get 
            { 
                return _code; 
            } 
        }

        /// <summary>
        /// Allows to get the article quantity
        /// </summary>
        public int Quantity 
        { 
            get 
            { 
                return _quantity; 
            } 
        }

        /// <summary>
        /// Allows to get the article price
        /// </summary>
        public decimal Price
        { 
            get 
            { 
                return _price; 
            } 
        }
    }
}
