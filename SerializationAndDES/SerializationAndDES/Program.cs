using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using EmployeeLib;

namespace SerializationAndDES
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employee employee = new Employee();
            Console.Write("Enter Emp Id: ");
            employee.Id = int.Parse(Console.ReadLine());
            Console.Write("Enter Emp First name: ");
            employee.FirstName = Console.ReadLine();
            Console.WriteLine("Enter Emp Last Name: ");
            employee.LastName = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary: ");
            employee.Salary = double.Parse(Console.ReadLine());

            // Binary Serialization
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("M:\\Simplilearn\\mphasis\\day21\\Assign24\\employee.bin", FileMode.Create))
            {
                formatter.Serialize(fs, employee);
            }
            Console.WriteLine("File created object is Serialized");

            // XML Serialization
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextWriter writer = new StreamWriter("M:\\Simplilearn\\mphasis\\day21\\Assign24\\employee.Xml"))
            {
                serializer.Serialize(writer, employee);
            }
            Console.WriteLine("XML Created");

            // User choice for deserialization format
            Console.WriteLine("Choose deserialization format:");
            Console.WriteLine("1. Binary Deserialization");
            Console.WriteLine("2. XML Deserialization");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DeserializeBinary();
                    break;
                case 2:
                    DeserializeXML();
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            Console.ReadKey();
        }

        static void DeserializeBinary()
        {
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("M:\\Simplilearn\\mphasis\\day21\\Assign24\\employee.bin", FileMode.Open))
            {
                Employee emp = (Employee)formatter.Deserialize(fs);
                Console.WriteLine("Emp Id : " + emp.Id);
                Console.WriteLine("Emp Name : " + emp.FirstName + " " + emp.LastName);
                Console.WriteLine("Emp Salary : " + emp.Salary);
            }
            Console.WriteLine("Readout & Deserialized");
        }

        static void DeserializeXML()
        {
            XmlSerializer serializer = new XmlSerializer(typeof(Employee));
            using (TextReader reader = new StreamReader("M:\\Simplilearn\\mphasis\\day21\\Assign24\\employee.Xml"))
            {
                Employee emp = (Employee)serializer.Deserialize(reader);
                Console.WriteLine($"ID = {emp.Id} , FirstName = {emp.FirstName} ,LastName = {emp.LastName},Salary = {emp.Salary}");
            }
            Console.WriteLine("Readout & Deserialized");
        }


    }
}
    

