using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
	internal class TypeWrapper
	{
		public TypeWrapper(Type type, Type baseType = null)
		{
			Type = type;
			BaseType = baseType;
		}

		public Type Type { get; set; }
		public Type BaseType { get; set; }


		//Equals & GetHashCode generated with VS
		//https://docs.microsoft.com/en-us/visualstudio/ide/reference/generate-equals-gethashcode-methods?view=vs-2017
		public override bool Equals(object obj)
		{
			var wrapper = obj as TypeWrapper;
			return wrapper != null &&
				   EqualityComparer<Type>.Default.Equals(Type, wrapper.Type) &&
				   EqualityComparer<Type>.Default.Equals(BaseType, wrapper.BaseType);
		}

		public override int GetHashCode()
		{
			var hashCode = -1095222907;
			hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(Type);
			hashCode = hashCode * -1521134295 + EqualityComparer<Type>.Default.GetHashCode(BaseType);
			return hashCode;
		}
	}
}
