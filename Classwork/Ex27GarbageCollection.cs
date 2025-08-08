using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleConApp
{
    class SimpleObject : IDisposable
    {
        private int _id;
        public SimpleObject(int id)
        {
            _id = id;
            Console.WriteLine($"{_id} object is created");
        }
        ~SimpleObject()
        {
            Console.WriteLine($"{_id} object is Destroyed");
        }

        public void Dispose()
        {
            Console.WriteLine($"{_id} is destroy");
            GC.SuppressFinalize( this );
        }
    }
    internal class Ex27GarbageCollection
    {
        static void CreateAndDestroyObjects()
        {
            for(int i=0; i<10; i++)
            {
                GC.Collect(); //Runs the GC as background thread
                GC.WaitForPendingFinalizers();//When the GC is in action, the main 
                //SimpleObject obj = new SimpleObject(i);
                //obj.Dispose();
                using (SimpleObject obj = new SimpleObject(i))
                {

                }
                //Console.WriteLine("The Id of the object is"+ obj.GetHashCode()); //Know whether obj is created or not
            }
        }
        static void Main(string[] args)
        {
            CreateAndDestroyObjects();   
        }
    }
}
