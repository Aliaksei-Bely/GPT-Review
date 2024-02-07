using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Property)]
	public abstract class ContainerAttribute : Attribute
	{
	}

	[AttributeUsage(AttributeTargets.Property)]
	public class ImportAttribute : ContainerAttribute
	{
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class ImportConstructorAttribute : ContainerAttribute
	{
	}

	[AttributeUsage(AttributeTargets.Class)]
	public class ExportAttribute : ContainerAttribute
	{
		public Type Contract { get; private set; }

		public ExportAttribute(Type contract = null)
		{
			Contract = contract;
		}
	}
}
