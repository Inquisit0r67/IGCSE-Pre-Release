//This program is courtesy of S.Jani 11W [pls no steal :(]
using System;
using System.Linq; //This may not be acceptable in an exam as Linq is only used in .net languages
using System.Collections.Generic;
using static System.Console;
namespace GCSE_pre_release
{ 
    class Program
    {
        //Initialising arrays for parts and components
        static string[] Parts = { "Proccesor", "RAM", "Storage", "Screen", "Case", "USB ports" };
        static string[] Components = { "p3", "p5", "p7", "16GB", "32GB", "1TB", "2TB", "19\"", "23\"", "Mini tower", "Midi tower","2 ports", "4 ports" };
        //Self explanitory, these are the prices for the Components
        static int[] Prices = { 100, 120, 200, 75, 150, 50, 100, 65, 120, 40, 70, 10, 20 };
        //Skip will be used to get how many items to skip in the array components to get the items we want.
        //Range_size will be used to select the size of the range of items from the array Components, it will start at the item reached after skip
        static int[] Range_size = { 3, 2, 2, 2, 2, 2 };         
        static int[] Skip = { 0, 3, 5, 7, 9, 11};
        //Initialising Stock and an array for amount ordered of each part
        static int[] Stock = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
        static int[] Running_Stock = { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, };
        static List<string> Customer_choice = new List<string>(); //A list for saving customer choice
        static List<int> Order_price = new List<int>(); //List for saving the order price
        static int Order_Num_Gen = 0; //Used for creating unique order number
        static int Amount_Orders_made = 0; //Saves number of orders made
        static string date = DateTime.Today.ToString("dd/MM/yy"); //Gets the current date of the computer
        static List<string> Customer_details = new List<string>(); //Stores all details of order per customer
  
        static void Main()
        {  
            //Task 1
            var EOD = false; //End of day, program for customer choice will loop till "end of day = True"
            while (EOD == false)
            {
                //Here the program will iterate through the array parts and print out each item
                for (int j = 0; j < Parts.Length; j++)
                {
                    WriteLine("\n" + "Choose " + Parts[j]);
                    //Temp is the temporary array used to store the specific range of items selcted
                    //It uses the array Skip and Range_size to get the specific range of items from Components
                    var Temp = Components.Skip(Skip[j]).Take(Range_size[j]).ToArray(); //Using Linq may not be accepted in exam (.Skip and .Take)
                    var Temp_prices = Prices.Skip(Skip[j]).Take(Range_size[j]).ToArray(); //Temp_prices stores the prices for items chosen
                    for (int i = 0; i < Temp.Length; i++)
                    {
                        WriteLine("{0}." + Temp[i], i + 1);
                    }
                    var check = true;
                    while (check == true) //Will repeat the specific try if an exception is thrown
                    {
                        try
                        {
                            var input = Convert.ToInt32(ReadLine()) - 1; //Uses the input and converts it to an integer and then subtracts one to get the correct place in the array
                            Customer_choice.Add(Temp[input]);
                            Order_price.Add(Temp_prices[input]); //Appends the chosen items and price to seperate list, did not use 2d arrays cause exame board are unclear on what they accept
                            check = false;
                            break;
                        }
                        catch (Exception) //Program will "catch" any exception
                        {
                            WriteLine("An invalid input was detected, please try again");
                        }
                    }
                };
                WriteLine("\n" + "\n");
                WriteLine("---------------------------------------------------------------------------------------------");
                WriteLine("Your order summary:" + "\n");
                Customer_choice.Zip(Order_price, (a, b) => a + " : $" + b).ToList().ForEach(x => WriteLine(x)); //Another linq function .Zip allows to combine two lists for viewing (aethetics only)
                WriteLine();
                WriteLine("Total cost of your order is $" + Order_price.Sum() * 1.2 + " including 20% VAT\n"); //Gets sum of Order_price and then adds 20% as per pre release requirements          

                //Task 2
                var In_Stock = true;
                for (int k = 0; k < Running_Stock.Length; k++) //Iterrates through stock
                {
                    if (Running_Stock[k] < 1 & Customer_choice.Contains(Components[k])) //Check if there is any item in stock is less than one (so empty) and if it is contained within the order
                    {
                        WriteLine(Components[k] + " is out of stock and order will not be completed");
                        In_Stock = false; //Flags as out of stock if an item if out of stock, this will prevent an order being placed
                    };
                }
                //Asks user to confirm the order they have selected
                WriteLine("\nDo you want to make your order? (y/n)"); 
                var check1 = true;
                while (check1 == true)
                {
                    var input1 = ReadLine();
                    if (input1 == "y" & In_Stock == true)
                    { //If "y" is selected and items are in stock the order will be saved
                        for (int o = 0; o < Components.Length; o++) //Iterates through components
                        {
                            if (Customer_choice.Contains(Components[o])) //if item is on the order list
                            {
                                Running_Stock[o] -= 1; //Take away stock from that component
                            }
                        }
                        Order_Num_Gen++;
                        WriteLine("\nOrder made " + date + ". Enter customer details...");
                        var Customer_Details_input = ReadLine();
                        //Adds all details to list
                        Customer_details.Add("Customer: **" + Customer_Details_input + "** made order on " + date + ". Order Num is: " + Order_Num_Gen + ". The value of the order is $" + Order_price.Sum() * 1.2);                                            
                        Amount_Orders_made++; //Adds an order to orders made
                        break;
                    }
                    else if (input1 == "n" || In_Stock == false)
                    { //If "n" is selcetd or the items are not in stock no order details will be saved
                        WriteLine("Order not made");
                        ReadKey();
                        break;
                    }

                }

                //Task 3
                WriteLine("\nIs it endo of day? (y/n)");               
                var Check = true;
                while (Check == true)
                {
                    var Input = ReadLine();
                    if (Input == "y") //Asks user to check if its end of day
                    { //If its end of day the program prints out the number of orders made and all the unique order numbers
                        WriteLine("\nThe amount of orders made is: " + Amount_Orders_made);
                        WriteLine("\nHere are all the details of orders made: ");
                        Customer_details.ForEach(WriteLine); //Prints out the whole list with order details
                        WriteLine("\nAmount sold of each product:");
                        //Once again Linq saves the day with .Zip, this just subtracts staring stock by current to get amount sold as a new array
                        int[] Amount_sold = Stock.Zip(Running_Stock, (a, b) => a - b).ToArray(); 
                        for (int i = 0; i < Amount_sold.Length; i++) //Prints out the array amount sold
                        {
                            WriteLine(Components[i] + ": " + Amount_sold[i]);
                        }
                        ReadKey();
                        EOD = true;
                        break;
                    }
                    else if (Input == "n") //If value entered is "n" it will not change the EOD Bool and so program will loop
                    {
                        Check = false;
                        break;
                    }
                }
                Customer_choice.Clear(); // Refreshes the lists so they can be re-used for the next loop/customer
                Order_price.Clear();
            }
        }
    }
}


    

