namespace VendingMachine
{
    class VendingMachine
    {
        private List<string> products = new List<string>() { "cola", "chips", "candy" }; // set the list of products
        private List<decimal> prices = new List<decimal>() { 1.00m, 0.50m, 0.65m }; // set the list for the prices of the products
        private decimal currentAmount = 0.00m;

        public void Run() // Main method
        {
            //displaying the customers to insert a coin to purchase a product
            Console.WriteLine("Welcome to the vending machine!");
            Console.WriteLine("INSERT COIN (nickels - 0.05, dimes - 0.10, quarters - 0.25) or type 'exit' to quit.");

            try
            {
                while (true)
                {
                    Console.WriteLine($"Current amount: {currentAmount:C}"); // shows the current amount

                    string input = Console.ReadLine(); // get the input from the customer

                    if (input.ToLower() == "exit") //application terminates if user enters exit
                    {
                        break;
                    }

                    if (decimal.TryParse(input, out decimal coin))
                    {
                        if (coin == 0.05m || coin == 0.10m || coin == 0.25m) // check if inserted amount is 0.05 or 0.10 or 0.25
                        {
                            currentAmount += coin;
                            Console.WriteLine($"Added {coin:C}. Current amount: {currentAmount:C}"); // it will show thw amount as added
                        }
                        else
                        {
                            Console.WriteLine($"Coin Return: {coin:C}"); // else return the coin
                        }
                    }
                    else if (input.ToLower() == "cola" || input.ToLower() == "chips" || input.ToLower() == "candy") // check the input for the product
                    {
                        int index = products.IndexOf(input.ToLower());

                        if (currentAmount >= prices[index]) // check if the balance is equal or greater than the price of the product
                        {
                            currentAmount -= prices[index]; //if yes it will cut the product price from the current amount
                            Console.WriteLine($"Dispensing {products[index]}");// shows the product as dispensed
                            Console.WriteLine("THANK YOU");
                        }
                        else
                        {
                            Console.WriteLine($"PRICE: {prices[index]:C}. Current amount: {currentAmount:C}"); // shows the balanced amount as current amount
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input."); // it will show Invalid input if customer enters wrong product
                    }
                }
            }
            catch (Exception ex)
            {
            }

        }
    }
}

