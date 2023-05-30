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
                    trainer1.addtoBelt();
 
                    Trainer trainer2 = new Trainer(trainer2Name);
                    trainer2.addtoBelt();

                    int x = 0;

                    for (int i = 0; i < 6 ; i++)
                    {

                        int beltindex;

                        if(i <  3 )
                        {
                            beltindex = i;
                        }

                        else
                        {
                            
                            beltindex = x;
                            x++;


                        }



                        Console.WriteLine(trainer1.name + " turn : ");
                        trainer1.throwPokeball(beltindex);

                        Console.WriteLine(trainer2.name + " turn : ");
                        trainer2.throwPokeball(beltindex);

                        Console.WriteLine(trainer1.name + "  : ");
                        trainer1.returnPokeball();

                        Console.WriteLine(trainer2.name + "   : ");
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

       

        class Pokeball
        {
            public bool isEmpety;
            public Charmander charmander;


            public Pokeball(bool isEmpety, string name, string strength, string weakness)
            {
                this.isEmpety = isEmpety;

                if (this.isEmpety == true)
                {
                    this.charmander = new Charmander(name, strength, weakness);

                }
            }

            public void releasCharmander()
            {
                this.charmander.battleCry();
            }

            public void closePokeball()
            {
                Console.WriteLine( this.charmander.name + "  is back his Pokeball !");
            }
        }

        class Trainer
        {

            public string name;
            public int pokeBallnum;
            public Pokeball pokeball;
            List<Pokeball> belt1 = new List<Pokeball>();
            List<Pokeball> belt2 = new List<Pokeball>();



            public Trainer(string name)
            {

                this.name = name;
                this.addtoBelt();
            }

            public void num()
            {
                Console.WriteLine(belt1.Count);
                Console.WriteLine(belt2.Count);
            }
            public void addtoBelt()
            {

                for (int i = 0; i <= 3; i++)
                {
                    pokeball = new Pokeball(true, "charmendar", "fire", "water ");
                    belt1.Add(pokeball);
                    belt2.Add(pokeball);

                    pokeball = new Pokeball(true, "Squirtle", "water", "leaf");
                    belt1.Add(pokeball);
                    belt2.Add(pokeball);

                    pokeball = new Pokeball(true, "Bulbasaur", "grass", "fire");
                    belt1.Add(pokeball);
                    belt2.Add(pokeball);

                }

             


            }


            public void throwPokeball(int pokeBallnum)
            {

                this.pokeBallnum = pokeBallnum;

                if(this.pokeBallnum  < 3)
                {
                    belt1[pokeBallnum].releasCharmander();

                }
                else
                {
                    belt2[pokeBallnum].releasCharmander();
                }





            }

            public void returnPokeball()
            {
                belt1[pokeBallnum].closePokeball();



            }
        }


        abstract class Pokemone 
        {
            public string name;
            public string strnegth;
            public string weakness;

            public Pokemone(string name, string strength, string weakness)
            {
                this.name = name;
                this.strnegth = strength;
                this.weakness = weakness;
            }

            public abstract void battleCry();
             

        }

        class Squirtle : Pokemone
        {

            public Squirtle(string name, string strength, string weakness) : base(name, strength, weakness) { 

            }

            public override void battleCry()
            {
                Console.WriteLine(this.name + "!!!");

            }


        }

        class Bulbasaur : Pokemone
        {

            public Bulbasaur(string name, string strength, string weakness) : base(name, strength, weakness)
            {

            }

            public override void battleCry()
            {
                Console.WriteLine(this.name + "!!!");

            }


        }

        class Charmander : Pokemone
        {

            public Charmander(string name, string strength, string weakness) : base(name, strength, weakness)
            {

            }



            public override void battleCry()
            {
                Console.WriteLine(this.name + "!!!");
            }
        }

    }
}

