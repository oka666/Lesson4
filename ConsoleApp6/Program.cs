using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please select the program you want to execute:");

            while (true)
            {
                Console.WriteLine("");
                Console.WriteLine("Press '1' if you want to run program 'DaysInMonths'");
                Console.WriteLine("Press '2' if you want to run program 'ArrayInArray'");
                Console.WriteLine("Press '3' if you want to run program 'TryYourLuck'");
                Console.WriteLine("Press '4' to close the application");

                var selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        DaysInMonths();
                        break;
                    case "2":
                        ArrayInArray();
                        break;
                    case "3":
                        TryYourLuck();
                        break;
                    case "4":
                        Environment.Exit(-1);
                        break;
                    default:
                        Console.WriteLine("Please make your choice");
                        break;
                }

            }
        }

        public static void DaysInMonths()
        {
            int[] months = new int[12];
            int j = 1;
            for (int i = 0; i < months.Length; i++)
            {
                if ((j % 2 == 0 && j < 8 && j != 2) || (j >= 8 && j % 2 != 0))
                    months[i] = 30;
                else
                    months[i] = j == 2 ? 28 : 31;

                Console.WriteLine($"Month{j} has {months[i]} months");
                j++;
            }
            Console.ReadKey();
        }

        public static void ArrayInArray()
        {
            Console.WriteLine("Enter length of first massive::");
            int[] mas1 = new int[Convert.ToInt32(Console.ReadLine())];
            Console.WriteLine("Enter length of second massive::");
            int[] mas2 = new int[Convert.ToInt32(Console.ReadLine())];

            if (mas2.Length < mas1.Length)
                Array.Resize<int>(ref mas2, mas1.Length);

            var ran = new Random();

            Console.WriteLine("Mas1::");
            for (int i = 0; i < mas1.Length; i++)
            {
                mas1[i] = ran.Next(0, 10);
                Console.Write(mas1[i] + " ");
            }

            Console.WriteLine("");
            Console.WriteLine("Mas2::");
            for (int i = 0; i < mas2.Length; i++)
            {
                mas2[i] = ran.Next(0, 10);
                Console.Write(mas2[i] + " ");
            }

            Array.Copy(mas1, 0, mas2, (mas2.Length - mas1.Length) / 2, mas1.Length);

            Console.WriteLine("");
            Console.WriteLine("Mas2Updated::");
            for (int i = 0; i < mas2.Length; i++)
            {
                Console.Write(mas2[i] + " ");
            }

            Console.ReadKey();
        }

        public static void TryYourLuck()
        {
            Console.WriteLine("The program is started:");
            Console.WriteLine("");

            char[] steps = new char[10];
            steps[0] = '@';
            for (int i = 1; i < steps.Length; i++)
            {
                steps[i] = '_';
            }
            for (int i = 0; i < steps.Length; i++)
            {
                Console.Write(steps[i] + " ");
            }

            Console.WriteLine("");

            var health = 100;
            var mouse = 0;
            var flag = true;
            var ran = new Random();
            var bombType = ran.Next(0, 2);
            var hpMedicine = 0;
            var hpBomb = 0;
            var bType = "small";
            var mType = "small";


            switch (bombType)
            {
                case 0:
                    hpMedicine = 20;
                    break;
                case 1:
                    hpMedicine = 40;
                    bType = "big";
                    break;
            }

            var medicineType = ran.Next(0, 2);

            switch (medicineType)
            {
                case 0:
                    hpBomb = 20;
                    break;
                case 1:
                    hpBomb = 40;
                    mType = "big";

                    break;
            }

            var bomb = ran.Next(0, 11);
            var medicine = ran.Next(0, 11);
            ConsoleKeyInfo key;
            do
            {
                do
                {
                    Console.WriteLine("");
                    Console.WriteLine("#################################");
                    Console.WriteLine("Please press 'd' - to move right OR press 'a' - to move left");
                    key = Console.ReadKey();
                    Console.WriteLine("");
                    Console.WriteLine("Your health is " + health);
                    Console.WriteLine("");
                    if (key.KeyChar == 'a')
                    {
                        if (mouse == 0) steps[0] = '@';
                        else
                        {
                            steps[mouse] = '_';
                            steps[mouse - 1] = '@';
                            mouse--;
                        }
                    }

                    if (key.KeyChar == 'd')
                    {
                        steps[mouse] = '_';
                        steps[mouse + 1] = '@';
                        mouse++;
                    }
                } while (key.KeyChar != 'd' && key.KeyChar != 'a');

                if (mouse == bomb)
                {
                    Console.WriteLine($"You got {bType} a bomb");
                    Console.WriteLine("");
                    health = (health - hpBomb) < 0 ? 0 : health - hpBomb;
                    bomb = -1;
                }


                if (mouse == medicine)
                {
                    Console.WriteLine($"You got a {mType} medicine");
                    Console.WriteLine("");
                    health = (health + hpMedicine) > 100 ? 100 : health + hpMedicine;
                    medicine = -1;
                }


                health = health - 5;

                for (int i = 0; i < steps.Length; i++)
                {
                    Console.Write(steps[i] + " ");
                }

                Console.WriteLine();
                Console.WriteLine("Your health after one more time is " + health);


                if (mouse == steps.Length - 1)
                {
                    flag = false;
                    Console.WriteLine("You win the game");
                    break;
                }

            } while (health > 0);

            if (flag)
                Console.WriteLine("You lost the game");

            Console.ReadKey();
        }
    }
}
