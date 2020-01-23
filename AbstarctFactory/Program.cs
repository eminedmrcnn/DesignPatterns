using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstarctFactory
{
	//Toplu nesne kullanımı ihtiyacında nesnenin kullanımını kolaylaştırmak hem de özellikle standart nesnelere ihtiyac duyuyorsak onlar için mantık oluşturmak ve o mantığa göre nesne oluşturmak
	//Özellikle iş katmanında kullandığımız yöntemdir..
	class Program
	{
		static void Main(string[] args)
		{
			ProductManager productManager = new ProductManager(new Factory());
			productManager.GetAll();
			Console.ReadLine();
		}
	}

	//Biz Logging ve Caching olarak 2 tane temel nesne (soyut nesne) oluşturduk.. bunun üzerine istediğimiz tonlarca nesne oluşturabiliriz..
	public abstract class Logging
	{
		public abstract void Log(string message);
	}
	public class Log4NetLogger:Logging
	{
		public override void Log(string message)
		{
			Console.WriteLine("Logged with log4net");
		}
	}
	public class NLogger:Logging
	{
		public override void Log(string message)
		{
			Console.WriteLine("Logged with message");
		}
	}
	public abstract class Caching
	{
		public abstract void Cache(string data);
	}

	public class MemCache:Caching
	{
		public override void Cache(string data)
		{
			Console.WriteLine("Cache with MemCache");
		}
	}
		
	public abstract class CrossCuttingCooncernsFactory
	{
		public abstract Logging CreateLogger();
		public abstract Caching CreateCaching();
	}

	public class Factory : CrossCuttingCooncernsFactory
		//Bu fabrika istediğimiz dizaynları yapabilirim..

	{
		public override Caching CreateCaching()
		{
			return new MemCache();
		}

		public override Logging CreateLogger()
		{
			return new Log4NetLogger(); 
		}
	}
	public class ProductManager
	{
		private CrossCuttingCooncernsFactory _crossCuttingCooncernsFactory;
		private Logging _logging;
		private Caching _caching;
		public ProductManager(CrossCuttingCooncernsFactory crossCuttingCooncernsFactory)
		{
			_crossCuttingCooncernsFactory = crossCuttingCooncernsFactory;
			_logging = _crossCuttingCooncernsFactory.CreateLogger();
			_caching = _crossCuttingCooncernsFactory.CreateCaching();
		}
		public void GetAll()
		{
			_logging.Log("Logged");
			_caching.Cache("Data");
			//_crossCuttingCooncernsFactory.CreateLogger().Log();
			Console.WriteLine("Product listed");
		}
	}


}
