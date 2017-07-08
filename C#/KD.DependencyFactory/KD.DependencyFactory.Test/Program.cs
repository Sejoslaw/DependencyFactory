using System;

namespace KD.DependencyFactory.Test
{
    class Program
    {
        static void Main(string[] args)
        {
            // Register new type
            DependencyFactory.Register<IClass1, Class1>();
            // Get saved type
            IClass1 cl1Object = DependencyFactory.Resolve<IClass1>();
            // Test the result
            Console.WriteLine(cl1Object.ToString());

            Console.ReadLine();
        }
    }
}
