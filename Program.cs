using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace _20241128_BinarySerizationDemo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Person p = new Person() { Id = 0xFFFF, Name = "Dmytro", Age = 18.5 };

            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (FileStream fsOut = new FileStream("person.bin", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fsOut, p);
            }

            using (FileStream fsIn = new FileStream("person.bin", FileMode.Open, FileAccess.Read))
            {
                Person pCopy = (Person)binaryFormatter.Deserialize(fsIn);
            }

            Person pCopy2 = (Person)p.Clone();

            Console.WriteLine("     p: {0}", p);
            Console.WriteLine("pCopy2: {0}", pCopy2);

            Console.ForegroundColor = ConsoleColor.Green;

            pCopy2.Id = 223;

            Console.WriteLine("     p: {0}", p);
            Console.WriteLine("pCopy2: {0}", pCopy2);

            Person[] people = new Person[] { p, pCopy2 };

            using (FileStream fsOut = new FileStream("people.bin", FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(fsOut, people);
            }

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("peopleCopy:");

            using (FileStream fsIn = new FileStream("people.bin", FileMode.Open, FileAccess.Read))
            {
                Person[] peopleCopy = (Person[])binaryFormatter.Deserialize(fsIn);
                for (int i = 0; i < peopleCopy.Length; i++)
                {
                    Console.WriteLine(peopleCopy[i]);
                }
            }

            Console.WriteLine("Press any key...");
            Console.ReadKey();
        }
    }
}
