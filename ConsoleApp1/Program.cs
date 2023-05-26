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


                    Console.WriteLine("Give a name for Trainer 1 : ");
                    string trainer1Name = Console.ReadLine();

                    Console.WriteLine("Give a name for Trainer 2: ");
                    string trainer2Name = Console.ReadLine();


                    Trainer trainer1 = new Trainer(trainer1Name);
                    Trainer trainer2 = new Trainer(trainer2Name);
                     

                    for (int i = 0; i < 6 ; i++)
                    {

                        Console.WriteLine(trainer1.name + " turn : ");
                        trainer1.throwPokeball(i);

                        Console.WriteLine(trainer2.name +  " turn : ");
                        trainer2.throwPokeball(i);

                        Console.WriteLine(trainer1.name + "  : " );
                        trainer1.returnPokeball();

                        Console.WriteLine(trainer2.name +  "   : ");
                        trainer2.returnPokeball();

                    }

                    Console.WriteLine("Do you want to rstart ? : ( yse/no ) ");
                    string quitAnswer = Console.ReadLine();
                    if (quitAnswer == "no" || quitAnswer == "No")
                    {
                        quite = true;
                        break;
                    }
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


        class Pokeball
        {
            public bool isEmpety;
            public Charmander charmander;


            public Pokeball(bool isEmpety, string name, string strength, string weakness)
            {
                this.isEmpety = isEmpety;

                if (this.isEmpety == true)
                {
                    this.charmander = new Charmander (name, strength , weakness );
 
                }
            }

            public void releasCharmander()
            {
                this.charmander.battleCry();
            }

            public void closePokeball()
            {
                Console.WriteLine(" Charmendar is back his Pokeball !");
            }
        }

        class Trainer
        {
             
            public string name;
            public int pokeBallnum;
            public Pokeball pokeball;
            List<Pokeball> belt = new List<Pokeball>();
            


            public Trainer( string name)
            {

                this.name = name;
                this.addtoBelt();
            }

            public void addtoBelt()
            {

                for (int i = 0; belt.Count < 6; i++)
                {
                    pokeball = new Pokeball (true , "charmendar" , "fire", "water ");
                    belt.Add(pokeball);

                }

            }
            

            public void throwPokeball(int pokeBallnum)
            {

                this.pokeBallnum = pokeBallnum;
                belt[pokeBallnum].releasCharmander();

            }

            public void returnPokeball()
            {

                pokeball.closePokeball();
                Console.WriteLine(" Pokeball back to  belt ");



            }
        }
    }
}

