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


                 


                    Console.WriteLine("Give a name for Trainer 1 : ");
                    string trainer1Name = Console.ReadLine();

                    Console.WriteLine("Give a name for Trainer 2: ");
                    string trainer2Name = Console.ReadLine();

                    Arena arena = new Arena(trainer1Name, trainer2Name);
                    

                    

                     

 
 

                    answer = Console.ReadLine();




            }
        }

       

        class Pokeball
        {
            public bool isEmpety;
            public string pokemoneType; 
            public Charmander charmander;
            public Squirtle squirtle;
            public Bulbasaur bulbasaur;



            public Pokeball(bool isEmpety, string name,   string pokemone)
            {
                this.isEmpety = isEmpety;

                if (this.isEmpety == true)
                {


                    switch (pokemone)
                    {

                        case "charmendar":

                            this.charmander = new Charmander(name );
                            this.pokemoneType = "charmendar";
                            break;

                        case "squirtle":

                            this.squirtle = new Squirtle(name );
                            this.pokemoneType = "squirtle";
                            break;

                        case "bulbasaur":

                            this.bulbasaur = new Bulbasaur(name );
                            this.pokemoneType = "bulbasaur";
                            break;

                    } 
                    

                }
            }

            public string releasPokemone()
            {

                if (this.pokemoneType == "charmendar")
                {
                    return this.charmander.battleCry();
                }

                
                else if (this.pokemoneType == "squirtle")
                {
                    return this.squirtle.battleCry();
                }

                return this.bulbasaur.battleCry();
              
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
            public List<Pokeball> belt = new List<Pokeball>();
             




            public Trainer(string name)
            {

                this.name = name;
                this.addtoBelt();
            }

            
            public void addtoBelt()
            {
  
                for (int i = 0; i < 1 ; i++ ) 
                {


                    pokeball = new Pokeball(true, "charmendar", "charmendar");
                    belt.Add(pokeball);


                    pokeball = new Pokeball(true, "squirtle", "squirtle");
                    belt.Add(pokeball);


                    pokeball = new Pokeball(true, "bulbasaur", "bulbasaur");
                    belt.Add(pokeball);

                }
                    

            }

            public void clearArray()
            {
                belt.Clear();
            }

            public Pokemone pickPokebal()
            {

                
          
                    this.pokemoneIndex = rnd.Next(0, belt.Count);
                    return belt[this.pokemoneIndex].returnPokemoneObject();
 
            
             




            }
            public string throwPokeball()
            {

                return belt[this.pokemoneIndex].releasPokemone();



            }

            public int beltCount()
            {
                return belt.Count;
            }

            public string howManyPokball()
            {
                return $"{this.beltCount()} Pokemone left in {this.name} belt";
            }


            public void returnPokeball()
            {
                belt[this.pokemoneIndex].closePokeball();

            }

            public void delteFromBelt()
            {
                belt.RemoveAt(this.pokemoneIndex);
            }
        }


        abstract class Pokemone 
        {
            public string name;
            public   string strength;
            public string weakness;

            public Pokemone(string name)
            {
                this.name = name;
                 
            }

            public abstract string battleCry();
             

        }

        class Squirtle : Pokemone
        {
 
            public Squirtle(string name ) : base(name) { 

                this.strength = "water";
                this.weakness = "leaf";

            }

            public override string battleCry()
            {
                return this.name + "!!!";

            }


        }


        class Bulbasaur : Pokemone
        {
            

            public Bulbasaur(string name ) : base(name )
            {
                this.strength = "leaf";
                this.weakness = "fire";
            }

            public override string battleCry()
            {
                return this.name + "!!!";

            }


        }


        class Charmander : Pokemone
        {
            public Charmander(string name ) : base(name )
            {
                  this.strength = "fire";
                  this.weakness = "water";
            }

            public override string battleCry()
            {
                return this.name + "!!!";
            }
        }


        class Battle
        {


            public int round = 1;


            public void battle(Trainer trainer1, Trainer trainer2)
            {

                trainer1.clearArray();
                trainer2.clearArray();

                trainer1.addtoBelt();
                trainer2.addtoBelt();

                int whoWon;

                while (trainer1.beltCount() > 0 && trainer2.beltCount() > 0)
                {

                    


                   



                    

                    whoWon = whoWin(trainer1.pickPokebal() , trainer2.pickPokebal());




                    if (

                        trainer1.beltCount() == 1 & trainer2.beltCount() == 1

                        &&
                        
                        trainer1.belt[0].pokemoneType == trainer2.belt[0].pokemoneType)

                    {

                        Console.WriteLine("The battle is draw!");
                        break;

                    }


                    else
                    {
                        Console.WriteLine(trainer1.throwPokeball());
                        Console.WriteLine(trainer2.throwPokeball());
                         
                        Console.WriteLine( winner(whoWon, trainer1, trainer2));

                        Console.WriteLine(trainer1.belt.Count);
                        Console.WriteLine(trainer2.belt.Count);



                    }


                    
                }

            }







            public string winner(int winner, Trainer trainer1, Trainer trainer2)
            {
                if (winner == 1)
                {
                    trainer2.delteFromBelt();
                    return $"{trainer1.name} won the battle !! ";
                }


                else if (winner == 2)
                {
                    trainer1.delteFromBelt();
                    return $"{trainer2.name} won the battle !! ";
                }

                return "Its draw !";





            }

            public int whoWin(Pokemone pokemone1, Pokemone pokemone2)
            {


                if (pokemone1.strength == pokemone2.weakness)
                {

                    return 1;

                }

                else if (pokemone2.strength == pokemone1.weakness)
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
            public Battle battle;
            public static int howManybattles = 0;
            public static int rounds = 0;


            public Arena(string trainer1, string trainer2)
            {
                this.trainer1 = new Trainer(trainer1);
                this.trainer2 = new Trainer(trainer2);

                


                while (true)
                {

                    this.battle = new Battle();

                    battle.battle(this.trainer1, this.trainer2);

                    rounds = battle.round;
                    howManybattles++;

             
                    Console.WriteLine("Do you want to fight again ? ");
                    string answer = Console.ReadLine();

                    


                    if (answer == "no" || answer == "No")
                    {

                        Console.WriteLine($"Tottal rounds are {rounds} and tottal battles are {howManybattles}");
                        break;

                    }

                    


                }
            }
        }
    }
}

