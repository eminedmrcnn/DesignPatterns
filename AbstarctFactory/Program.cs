using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctFactory
{
	class Program
	{
		static void Main(string[] args)
		{
			Customer customer = new Customer
			{
				FirstName = "Emine",
				LastName = "Demircan",
				City = "İstanbul",
				Id = 1
			};

			var customer1 = (Customer)customer.Clone();
			customer1.FirstName = "Esra";
			Console.WriteLine(customer.FirstName);
			Console.WriteLine(customer1.FirstName);

			Console.ReadLine();


		}
	}
	public abstract class Person
	{
		//Prototype deseninde şöyle bi durum söz konusu temel nesneyi prototype haline getirebilmek için onun soyut bir clone metodunu oluşturucaz.
		public abstract Person Clone();
		public int Id { get; set; }
		public string FirstName { get; set; }
		public string LastName { get; set; }

	}
	public class Customer:Person
	{
		public  string City { get; set; }

		public override Person Clone()
		{
			return (Person)MemberwiseClone();
		}
	}

	public class Employee : Person
	{
		public decimal Salary { get; set; }

		public override Person Clone()
		{
			return (Person)MemberwiseClone();
		}
	}

}
