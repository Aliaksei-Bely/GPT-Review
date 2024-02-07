using DIContainer;
using Entities.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.BLL
{
	public class CustomerBLL
	{
		[Import]
		public Logger Logger { get; set; }

		[Import]
		public Logger2 Logger2 { get; set; }

		[Import]
		public ICustomerDAL CustomerDAL { get; set; }
	}

	[ImportConstructor]
	public class CustomerBLL2
	{
		public Logger Logger { get; }
		public Logger2 Logger2 { get; }
		public ICustomerDAL CustomerDAL { get; }

		public CustomerBLL2(Logger logger, Logger2 logger2, ICustomerDAL customerDAL)
		{
			this.Logger = logger;
			this.Logger2 = logger2;
			this.CustomerDAL = customerDAL;
		}
	}
}
