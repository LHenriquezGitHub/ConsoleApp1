using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    static class Util
    {
        public static void SayHello()
        {
            Console.WriteLine($"Hello!");
        }


        #region Get int
        public static T Get<T>(T one)
        {
            return one;
        }

        public static int Get(int one)
        {
            return one;
        }

        public static object Get(object one)
        {
            return one;
        }
        #endregion
    }

    public abstract class Animal
    {
        public string greetings = "Hello";
        
        public virtual void WhatDoYouSay()
        {
            Console.WriteLine("growl!");
        }

        public virtual void WhatDoYouEat()
        {
            Console.WriteLine("food");
        }

    }

    public class Cat : Animal
    {
        
        public override void WhatDoYouSay()
        {
            Console.WriteLine("meow!");
        }
    }
    public class Dog : Animal
    {
        public override void WhatDoYouSay()
        {
            Console.WriteLine("ruff-ruff!");
        }
    }

    public class Unknown : Animal
    {
        public override void WhatDoYouSay()
        {
            Console.WriteLine("unknown!");
        }
    }

    public class NoAnimal : Animal
    {
        public override void WhatDoYouSay()
        {

        }
    }

}
