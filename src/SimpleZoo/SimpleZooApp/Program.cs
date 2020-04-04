using System;
using System.Collections.Generic;
using SimpleZoo.Animals;
using SimpleZoo.Intefaces;

namespace SimpleZooApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            List<Lion> lions = new List<Lion>
            {
                new Lion(name:"Simba", age:2, health:100, id:Guid.NewGuid()),
                new Lion(name:"Scar", age:8, health:45, id:Guid.NewGuid()),
                new Lion(name:"Mufase", age:8, health:20, id:Guid.NewGuid()),
            };


            Lion lion = new Lion(name: "Simba", age: 4, health: 100, id: Guid.NewGuid());
            lion.Hunger = 80;
            

            Antelope antelope = new Antelope(name: "Lulu", age: 2, health: 30, id: Guid.NewGuid());

            if (lion.isHungry())
                lion.Hunt(antelope);

            lion.isHungry();
        }
    }
}
