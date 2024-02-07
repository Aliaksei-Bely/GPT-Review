using DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DAL
{
	public interface ICustomerDAL
	{
		string CusotmerMessage { get; set; }
	}

	[Export(typeof(ICustomerDAL))]
	public class CustomerDAL : ICustomerDAL
	{
		public string CusotmerMessage { get; set; } = "CustomerDAL";
	}
}
