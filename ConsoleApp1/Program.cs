using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemone
{
    internal class Program
    {
        static void Main(string[] args)
        {


            Console.WriteLine("Do you want to play ? ( yes / no ) ");

            string answer = Console.ReadLine();

            if (answer == "yes" || answer == "Yes")
            {


                bool quite = false;

                while (quite == false)
                {
                    string newNameAnswer = "yes";
                    string name = "";

                    if (newNameAnswer == "yes" || newNameAnswer == "Yes")
                    {
                        Console.WriteLine("Give a name for your Charmender : ");
                        name = Console.ReadLine();

                    }


                    Charmander chamerendar = new Charmander(name, "fire", "water ");

                    for (int i = 0; i < 10; i++)
                    {
                        chamerendar.battleCry();

                    }

                    Console.WriteLine("Do you want to stop ? : ( yse/no ) ");
                    string quitAnswer = Console.ReadLine();
                    if (quitAnswer == "yes" || quitAnswer == "Yes")
                    {
                        quite = true;
                        break;
                    }

                    Console.WriteLine("Do you want to give your Charmender a new name ? : ( yse/no ) ");
                    newNameAnswer = Console.ReadLine();


                }


            }




        }

        class Charmander
        {

            public string name;
            public string strnegth;
            public string weakness;

            public Charmander(string name, string strength, string weakness)
            {
                this.name = name;
                this.strnegth = strength;
                this.weakness = weakness;
            }

            public void battleCry()
            {
                Console.WriteLine(this.name + "!!!");
            }
        }

    }
}

