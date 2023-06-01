using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Pokemone
{

    internal class Program
    {

        static Random rnd = new Random();

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

                     

                     

                    Battle battle = new Battle();

                    Console.WriteLine(battle.whoWin(trainer1.throwPokeball(), trainer2.throwPokeball()));






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
            private string pokemoneType; 
            public Charmander charmander;
            public Squirtle squirtle;
            public Bulbasaur bulbasaur;



            public Pokeball(bool isEmpety, string name, string strength, string weakness , string pokemone)
            {
                this.isEmpety = isEmpety;

                if (this.isEmpety == true)
                {


                    switch (pokemone)
                    {

                        case "charmendar":

                            this.charmander = new Charmander(name, strength, weakness);
                            this.pokemoneType = "charmendar";
                            break;

                        case "squirtle":

                            this.squirtle = new Squirtle(name, strength, weakness);
                            this.pokemoneType = "squirtle";
                            break;

                        case "bulbasaur":

                            this.bulbasaur = new Bulbasaur(name, strength, weakness);
                            this.pokemoneType = "bulbasaur";
                            break;

                    } 
                    

                }
            }

            public void releasCharmander()
            {

                switch (this.pokemoneType)
                {
                    case "charmendar":

                        this.charmander.battleCry();
                        break;

                    case "squirtle":

                        this.squirtle.battleCry();
                        break;

                    case "bulbasaur":

                        this.bulbasaur.battleCry();
                        break;

                }
                
            }

            public void closePokeball()
            {
                

                switch (this.pokemoneType)
                {
                    case "charmendar":

                        Console.WriteLine(this.charmander.name + "  is back his Pokeball !");
                        break;

                    case "squirtle":

                        Console.WriteLine(this.squirtle.name + "  is back his Pokeball !");
                        break;

                    case "bulbasaur":

                        Console.WriteLine(this.bulbasaur.name + "  is back his Pokeball !");
                        break;

                }
            }

            public Pokemone returnPokemoneObject()
            {

                if (this.pokemoneType == "charmendar")
                {
                    return this.charmander;
                }

                else if (this.pokemoneType == "squirtle")
                {
                    return this.squirtle;
                }

                else 
                {
                    return this.bulbasaur;
                }
                
            }
        }

        class Trainer
        {

            public string name;
            public int score;
            public int pokemoneIndex;
            public Pokeball pokeball;
            List<Pokeball> belt = new List<Pokeball>();
 


            public Trainer(string name)
            {

                this.name = name;
                this.addtoBelt();
            }

            
            public void addtoBelt()
            {

                for (int i = 0; i <= 2; i++)
                {
                    pokeball = new Pokeball(true, "charmendar", "fire", "water " , "charmendar");
                    belt.Add(pokeball);
                  

                    pokeball = new Pokeball(true, "Squirtle", "water", "grass", "squirtle"  );
                    belt.Add(pokeball);
                    

                    pokeball = new Pokeball(true, "Bulbasaur", "grass", "fire" , "bulbasaur");
                    belt.Add(pokeball);
                    

                }
       


            }


            public Pokemone throwPokeball()
            {

                this.pokemoneIndex = rnd.Next(this.belt.Count);
                belt[this.pokemoneIndex].releasCharmander();


                return belt[this.pokemoneIndex].returnPokemoneObject();




            }

            public void returnPokeball()
            {
                belt[this.pokemoneIndex].closePokeball();

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


        class Battle
        {


            private string pokemone1;

            public string round(string pokemone1, string pokemone2)
            {
                

                return "s";
            }
            public int whoWin(Pokemone pokemone1, Pokemone pokemone2)
            {


                if (pokemone1.strnegth == pokemone2.weakness)
                {

                    return 1;
                    
                }

                else if(pokemone2.strnegth == pokemone1.weakness)
                {
                    return 2;
                }

                return 0;

            }

             
        }


        class Arena
        {
            public Trainer trainer1;
            public Trainer trainer2;
            public int round;


            public Arena(string trainer1, string trainer2)
            {
                this.trainer1.name = trainer1;
                this.trainer2.name = trainer2;
            }
        }
    }
}

