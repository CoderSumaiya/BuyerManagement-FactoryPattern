using Buyer_Management.Entities;
using Buyer_Management.Enums;
using Buyer_Management.Factory;
using Buyer_Management.Manager;
using Buyer_Management.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Buyer_Management
{
    internal class Program
    {
        public static BuyerRepo repo = new BuyerRepo();
        static void Main(string[] args)
        {
            try
            {
                DoTask();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
            finally
            {
                Console.ReadLine();

            }
        }

        private static void DoTask()
        {
           
            DrawLine(ConsoleColor.DarkGray);

            Console.WriteLine();
            WriteCentered("Buyer Management", ConsoleColor.Magenta);
            WriteCentered("===============================", ConsoleColor.Magenta);

            Console.WriteLine();
            WriteCentered("How many operations would you like to perform?", ConsoleColor.White);
            Console.Write("\n" + "".PadLeft(Console.WindowWidth / 2 - 2) + "Input: ");

         
            if (int.TryParse(Console.ReadLine(), out int opCount))
            {
                for (int i = 0; i < opCount; i++)
                {
                    Console.WriteLine();
                    WriteCentered("1.Read | 2.Create | 3.Update | 4.Delete | 5.Single Info", ConsoleColor.Yellow);
                    Console.Write("\n" + "".PadLeft(Console.WindowWidth / 2 - 8) + "Select Operation: ");

                    if (int.TryParse(Console.ReadLine(), out int choice))
                    {
                        switch (choice)
                        {
                            case 1: 
                                ShowAllBuyer(0);
                                break;
                            case 2:
                                CreateNewBuyer();
                                break;
                            case 3: 
                                UpdateBuyer();
                                break;
                            case 4:
                                DeleteBuyer(); 
                                break;
                            case 5: 
                                ShowBuyerById();
                                break;
                            default: WriteCentered("Select valid operation", ConsoleColor.Red);
                                break;
                        }
                    }
                }
            }
        }

        private static void CreateNewBuyer()
        {
            WriteCentered("--- Create New Buyer ---", ConsoleColor.Cyan);
        EnterBuyerType:
            Console.Write("Enter Buyer Type (1. Regular, 2. New): ");
            if (!int.TryParse(Console.ReadLine(), out int btype)) goto EnterBuyerType;

            BuyerType type = (btype == 1) ? BuyerType.Regular : BuyerType.New;

            Console.Write("Enter Name: "); string name = Console.ReadLine();
            Console.Write("Enter Email: "); string email = Console.ReadLine();
            Console.Write("Enter Total Amount: "); double totalAmt = Convert.ToDouble(Console.ReadLine());

            Buyer newbyr = new Buyer(0, name, email, type, totalAmt, 0, 0);
            BaseBuyerFactory factory = new BuyerManagerFactory().CreateFactory(newbyr);
            factory.ApplyDisCount();

            repo.SaveBuyer(newbyr);
            WriteCentered("✔ Buyer Created Successfully!", ConsoleColor.Green);
            ShowAllBuyer(0);
        }

        private static void UpdateBuyer()
        {
            WriteCentered("--- Update Buyer ---", ConsoleColor.Cyan);
            Console.Write("Enter Buyer Id to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

        EnterBuyerType:
            Console.Write("Enter New Buyer Type (1. Regular, 2. New): ");
            if (!int.TryParse(Console.ReadLine(), out int btype)) goto EnterBuyerType;

            BuyerType type = (btype == 1) ? BuyerType.Regular : BuyerType.New;

            Console.Write("Enter New Name: "); string name = Console.ReadLine();
            Console.Write("Enter New Email: "); string email = Console.ReadLine();
            Console.Write("Enter New Total Amount: "); double totalAmt = Convert.ToDouble(Console.ReadLine());

            Buyer upByr = new Buyer(id, name, email, type, totalAmt, 0, 0);
            BaseBuyerFactory factory = new BuyerManagerFactory().CreateFactory(upByr);
            factory.ApplyDisCount();

            repo.UpdateBuyer(upByr);
            WriteCentered("✔ Buyer Updated!", ConsoleColor.Green);
            ShowAllBuyer(0);
        }

        private static void DeleteBuyer()
        {
            WriteCentered("--- Delete Buyer ---", ConsoleColor.Red);
            Console.Write("Enter Buyer Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            repo.DeleteBuyer(id);
            WriteCentered("✔ Buyer Deleted!", ConsoleColor.Red);
            ShowAllBuyer(0);
        }

        private static void ShowBuyerById()
        {
            WriteCentered("--- Search Buyer ---", ConsoleColor.Cyan);
            Console.Write("Enter Buyer Id: ");
            int id = Convert.ToInt32(Console.ReadLine());
            ShowAllBuyer(id);
        }

        private static void ShowAllBuyer(int id)
        {
            Console.WriteLine();
            string title = (id == 0) ? "--- Buyer List ---" : "--- Buyer Details ---";
            WriteCentered(title, ConsoleColor.Cyan);

            string top = "╔═════╦══════════╦═════════════════════════╦═══════════════╦══════════╦══════╦══════════╗";
            string head = "║ ID  ║   Name   ║          Email          ║     Type      ║  Total   ║ Disc ║ Net Pay  ║";
            string hr = "╠═════╬══════════╬═════════════════════════╬═══════════════╬══════════╬══════╬══════════╣";
            string bot = "╚═════╩══════════╩═════════════════════════╩═══════════════╩══════════╩══════╩══════════╝";

            WriteCentered(top, ConsoleColor.Gray);
            WriteCentered(head, ConsoleColor.Yellow);
            WriteCentered(hr, ConsoleColor.Gray);

            var list = (id > 0) ? repo.GetAllBuyer().Where(b => b.BuyerId == id).ToList() : repo.GetAllBuyer().ToList();

            if (list != null)
            {
                foreach (var item in list)
                {
                    string row = String.Format("║{0,5}║{1,-10}║{2,-25}║{3,-15}║{4,10:N0}║{5,5}%║{6,10:N0}║",
                        item.BuyerId,
                        item.BuyerName.Length > 10 ? item.BuyerName.Substring(0, 10) : item.BuyerName,
                        item.BuyerEmail.Length > 25 ? item.BuyerEmail.Substring(0, 25) : item.BuyerEmail,
                        item.ByrType, item.TotalAmount, item.DiscountPcnt, item.PayAmount);
                    WriteCentered(row, ConsoleColor.White);
                }
            }
            WriteCentered(bot, ConsoleColor.Gray);
        }

        static void DrawLine(ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(new string('═', Console.WindowWidth - 1));
            Console.ResetColor();
        }

        static void WriteCentered(string text, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            int width = Console.WindowWidth;
            if (width > 0 && text.Length < width)
                Console.WriteLine(text.PadLeft((width + text.Length) / 2));
            else Console.WriteLine(text);
            Console.ResetColor();
        }
    }

  
}
