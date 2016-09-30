using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using COA.Properties;

namespace COA
{
    class Program
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            //Check for First Run and Set starting Capital


            if (Settings.Default.FirstRunning == true)
            {
                Console.WriteLine("Please State Starting Capital: ");
                try
                {
                    decimal capital = decimal.Parse(Console.ReadLine());
                    BalanceSheet.setCapital(capital);
                    Settings.Default.FirstRunning = false;
                    Settings.Default.Save();
                }
                catch (InvalidCastException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }

            //Display Options
            DisplayOptions();


        }

        static void DisplayOptions()
        {

            Console.WriteLine("Please choose transaction Options: 0-4\n0 - Add Transaction\n1 - Add Expenditure\n2 - Show Cash Book\n3 - Show Expenditures\n4 - Show Balance Sheet");
            try
            {
                int option = int.Parse(Console.ReadLine());
                switch (option)
                {
                    case 0:
                        {
                            Transactions.begin();
                        }
                        break;

                    case 1:
                        {
                            Expenditures.begin();
                        }
                        break;
                    case 2:
                        {
                            Transactions.getReport();
                        }
                        break;
                    case 3:
                        {
                            Expenditures.getReport();
                        }
                        break;

                    case 4:
                        {
                            BalanceSheet.getTable();
                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Options");
                        Console.ReadLine();
                        //Recursive
                        DisplayOptions();
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("\t PLease Choose a Valid option" + ex.Message + ex.StackTrace + "\n");

                //Recursive
                DisplayOptions();
            }

        }


    }

}