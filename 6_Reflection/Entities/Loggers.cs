using DIContainer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
	[Export]
	public class Logger
	{
		public string LoggerMessage = "Logger";
	}

	[Export]
	public class Logger2
	{
		public string LoggerMessage = "Logger2";
	}
}
