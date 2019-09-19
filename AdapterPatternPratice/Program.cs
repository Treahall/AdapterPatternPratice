using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdapterPatternPratice
{
    class Program
    {
        static void Main(string[] args)
        {
            Bear grizzly = new Grizzly();
            ToyBear teddy = new TeddyBear();
            ToyBear adapterBear = new BearAdapter(new Grizzly());

            Console.WriteLine("Grizzly functions:");
            grizzly.Maul();
            grizzly.Hibernate();
            Console.WriteLine();

            Console.WriteLine("TeddyBear functions:");
            teddy.Hug();
            Console.WriteLine();

            Console.WriteLine("BearAdapter ToyBear functions:");
            adapterBear.Hug();

            Console.ReadLine();
        }

        interface Bear
        {
            void Maul();
            void Hibernate();
        }

        interface ToyBear
        {
            void Hug();
        }

        class TeddyBear : ToyBear
        {
            public void Hug()
            {
                Console.WriteLine("The bear gives hugs.");
            }
        }

        class Grizzly : Bear
        {
            public void Hibernate()
            {
                Console.WriteLine("The bear went into hibernation.");
            }

            public void Maul()
            {
                Console.WriteLine("The bear is mauling everyone.");
            }
        }

        class BearAdapter : ToyBear
        {
            Bear bear;
            public BearAdapter (Bear b)
            {
                bear = b;
            }
            public void Hug()
            {
                bear.Maul();
            }
        }
    }
}
