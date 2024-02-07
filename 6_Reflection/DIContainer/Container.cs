using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DIContainer
{
	public class Container
	{
		private HashSet<TypeWrapper> registeredTypes = new HashSet<TypeWrapper>();

		private IEnumerable<TypeWrapper> ExportedTypes => registeredTypes.Where(t => t.Type.GetCustomAttribute<ExportAttribute>() != null);

		public void AddType(Type type, Type baseType = null)
		{
			registeredTypes.Add(new TypeWrapper(type, baseType ?? typeof(object)));
		}

		public void AddAssembly(Assembly assembly)
		{
			var types = assembly.GetTypes().Where(t => t.GetCustomAttribute<ContainerAttribute>() != null);
			foreach (var type in types)
			{
				registeredTypes.Add(new TypeWrapper(type, type.BaseType));
			}
		}

		public object CreateInstance(Type type)
		{
			var instance = InitializeViaConstructor(type) ?? InitializeViaProperties(type);

			return instance;
		}

		public T CreateInstance<T>()
		{
			return (T)CreateInstance(typeof(T));
		}

		private object InitializeViaProperties(Type type)
		{
			var importProperties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public).Where(prop => prop.GetCustomAttribute(typeof(ImportAttribute)) != null);
			var instance = Activator.CreateInstance(type);
			foreach (var property in importProperties)
			{
				var exportedType = GetExportedType(property.PropertyType);
				instance.GetType().GetProperty(property.Name).SetValue(instance, Activator.CreateInstance(exportedType));
			}
			return instance;
		}

		private object InitializeViaConstructor(Type type)
		{
			if (type.GetCustomAttribute<ImportConstructorAttribute>() == null)
			{
				return null;
			}

			var publicCtor = type.GetConstructors(BindingFlags.Instance | BindingFlags.Public).SingleOrDefault();
			var parameters = publicCtor.GetParameters();
			var paramsArray = new object[parameters.Length];
			for (int i = 0; i < parameters.Length; i++)
			{
				var parameter = parameters[i];
				var parameterExportedType = GetExportedType(parameter.ParameterType);
				paramsArray[i] = Activator.CreateInstance(parameterExportedType);
			}

			var instance = Activator.CreateInstance(type, paramsArray);
			return instance;
		}

		private Type GetExportedType(Type type)
		{
			return ExportedTypes.SingleOrDefault(t => t.Type.Equals(type))?.Type
					?? ExportedTypes.SingleOrDefault(t => t.Type.GetCustomAttribute<ExportAttribute>().Contract?.Equals(type) ?? false).Type;
		}
	}
}
