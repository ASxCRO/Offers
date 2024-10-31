using FluentValidation;
using System.Reflection;

namespace Offers.API.Utils
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddFluentValidationFromAssembly(this IServiceCollection services, Assembly assembly)
        {
            var validatorTypes = assembly.GetTypes()
                .Where(t => t.IsClass && !t.IsAbstract && t.GetInterfaces().Any(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>)));

            foreach (var validatorType in validatorTypes)
            {
                var genericArgument = validatorType.GetInterfaces()
                    .First(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IValidator<>))
                    .GetGenericArguments()[0];

                services.AddTransient(typeof(IValidator<>).MakeGenericType(genericArgument), validatorType);
            }

            return services;
        }
    }
}
