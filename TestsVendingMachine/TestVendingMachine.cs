using Selling;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsSelling
{
    /// <summary>
    /// Ussed for testing vending machine
    /// </summary>
    public class TestVendingMachine
    {
        private VendingMachine _vendingMachine;

        /// <summary>
        /// Setup a vending machine with articles for all tests
        /// </summary>
        [SetUp]
        public void Setup()
        {
            List<Article> articleList = new List<Article>
            {
                new Article("Smarlies", "A01", 10, 1.60m),
                new Article("Carampar", "A02", 5, 0.60m),
                new Article("Avril", "A03", 2, 2.10m),
                new Article("KokoKola", "A04", 1, 2.95m)
            };

            _vendingMachine = new VendingMachine(articleList);
        }

        /// <summary>
        /// Test a nominal case with A01 article, result and change is tested
        /// </summary>
        [Test]
        public void VendingMachine_ChooseA01_NominalCase()
        {
            //Given
            decimal expectedChange = 1.80m;
            string expectedResult = "Vending Smarlies";

            //When
            _vendingMachine.InsertCredits(3.40m);
            string actualResult = _vendingMachine.ChooseArticle("A01");
            decimal actualChange = _vendingMachine.Change;

            //Then
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(actualChange, Is.EqualTo(expectedChange));
        }

        /// <summary>
        /// Test nominal case on A03 article, result, change and balance is tested
        /// </summary>
        [Test]
        public void VendingMachine_ChooseA03_NominalCase()
        {
            //Given
            decimal expectedBalance = 2.10m;
            decimal expectedChange = 0;
            string expectedResult = "Vending Avril";

            //When
            _vendingMachine.InsertCredits(2.10m);
            string actualResult = _vendingMachine.ChooseArticle("A03");
            decimal actualBalance = _vendingMachine.Balance;
            decimal actualChange = _vendingMachine.Change;

            //Then
            Assert.That(actualResult, Is.EqualTo(expectedResult));
            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
            Assert.That(actualChange, Is.EqualTo(expectedChange));
        }

        /// <summary>
        /// Test when there's not enough money on the machine
        /// </summary>
        [Test]
        public void VendingMachine_ChooseA01_NotEnoughMoney()
        {
            //Given
            string expectedResult = "Not enough money!";

            //When
            string actualResult = _vendingMachine.ChooseArticle("A01");

            //Then
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test multiple choice when there's not enough money on the machine
        /// </summary>
        [Test]
        public void VendingMachine_ChooseMultiple_NotEnoughtMoneyForOne()
        {
            //Given
            string expectedResult1 = "Not enough money!";
            string expectedResult2 = "Vending Carampar";

            //When
            _vendingMachine.InsertCredits(1.00m);
            string actualResult1 = _vendingMachine.ChooseArticle("A01");
            _vendingMachine.InsertCredits(1.00m);
            string actualResult2 = _vendingMachine.ChooseArticle("A02");

            //Then
            Assert.That(actualResult1, Is.EqualTo(expectedResult1));
            Assert.That(actualResult2, Is.EqualTo(expectedResult2));

        }

        /// <summary>
        /// Test when choosing an non existant article 
        /// </summary>
        [Test]
        public void VendingMachine_ChooseA05_InvalidSelection()
        {
            //Given
            string expectedResult = "Invalid selection!";

            //When
            _vendingMachine.InsertCredits(1.00m);
            string actualResult = _vendingMachine.ChooseArticle("A05");

            //Then
            Assert.That(actualResult, Is.EqualTo(expectedResult));
        }

        /// <summary>
        /// Test when there's no more article for the choosen one
        /// </summary>
        [Test]
        public void VendingMachine_ChooseMultiple_OutOfStock()
        {
            //Given
            string expectedResult1 = "Vending KokoKola";
            string expectedResult2 = "Item KokoKola: Out of stock!";
            decimal expectedChange = 3.05m;

            //When
            _vendingMachine.InsertCredits(6.00m);
            string actualResult1 = _vendingMachine.ChooseArticle("A04");
            string actualResult2 = _vendingMachine.ChooseArticle("A04");
            decimal actualChange = _vendingMachine.Change;

            //Then
            Assert.That(actualResult1, Is.EqualTo(expectedResult1));
            Assert.That(actualResult2, Is.EqualTo(expectedResult2));
            Assert.That(actualChange, Is.EqualTo(expectedChange));
        }

        /// <summary>
        /// Test a nominal case for multiple choosen
        /// </summary>
        [Test]
        public void VendingMachine_ChooseMultiple_NominalCase()
        {
            //Given
            string expectedResult1 = "Vending KokoKola";
            string expectedResult2 = "Item KokoKola: Out of stock!";
            string expectedResult3 = "Vending Smarlies";
            string expectedResult4 = "Vending Carampar";
            string expectedResult5 = "Vending Carampar";
            decimal expectedChange = 6.25m;
            decimal expectedBalance = 5.75m;

            //When
            _vendingMachine.InsertCredits(6.00m);
            string actualResult1 = _vendingMachine.ChooseArticle("A04");
            _vendingMachine.InsertCredits(6.00m);
            string actualResult2 = _vendingMachine.ChooseArticle("A04");
            string actualResult3 = _vendingMachine.ChooseArticle("A01");
            string actualResult4 = _vendingMachine.ChooseArticle("A02");
            string actualResult5 = _vendingMachine.ChooseArticle("A02");
            decimal actualChange = _vendingMachine.Change;
            decimal actualBalance = _vendingMachine.Balance;

            //Then
            Assert.That(actualResult1, Is.EqualTo(expectedResult1));
            Assert.That(actualResult2, Is.EqualTo(expectedResult2));
            Assert.That(actualResult3, Is.EqualTo(expectedResult3));
            Assert.That(actualResult4, Is.EqualTo(expectedResult4));
            Assert.That(actualResult5, Is.EqualTo(expectedResult5));
            Assert.That(actualChange, Is.EqualTo(expectedChange));
            Assert.That(actualBalance, Is.EqualTo(expectedBalance));
        }

        /// <summary>
        /// Test a nominal case when get the top 3 of best turnover
        /// </summary>
        [Test]
        public void VendingMachine_BestTurnover_NominalCase()
        {
            //Given
            string expectedResult = "Hour 23 generated a revenue of 4.80\r\nHour 9 generated a revenue of 3.20\r\nHour 20 generated a revenue of 1.60";

            //When
            _vendingMachine.InsertCredits(1000.00m);
            DateTimeProvider.Now = new DateTime(2020, 1, 1, 20, 30, 0);
            _vendingMachine.ChooseArticle("A01");
            DateTimeProvider.Now = new DateTime(2020, 3, 1, 23, 30, 0);
            _vendingMachine.ChooseArticle("A01");
            DateTimeProvider.Now = new DateTime(2020, 3, 4, 09, 22, 0);
            _vendingMachine.ChooseArticle("A01");
            DateTimeProvider.Now = new DateTime(2020, 4, 1, 23, 00, 0);
            _vendingMachine.ChooseArticle("A01");
            DateTimeProvider.Now = new DateTime(2020, 4, 1, 23, 59, 59);
            _vendingMachine.ChooseArticle("A01");
            DateTimeProvider.Now = new DateTime(2020, 4, 4, 09, 12, 0);
            _vendingMachine.ChooseArticle("A01");
            string actualResult = _vendingMachine.BestTurnover();

            //Then
            Assert.That(actualResult, Is.EqualTo(expectedResult));
           
        }
    }
}
