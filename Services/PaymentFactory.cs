using Microsoft.Extensions.DependencyInjection;
using ProvaPub.Interfaces;
using System;

namespace ProvaPub.Services
{
    public class PaymentFactory : IPaymentFactory
    {
        private readonly Dictionary<string, Type> _paymentMethodMappings;

        public PaymentFactory()
        {
            _paymentMethodMappings = CreateMappings();
        }

        public IPaymentStrategy CreatePaymentStrategy(string paymentMethod)
        {
            if (_paymentMethodMappings.TryGetValue(paymentMethod, out Type strategyType))
            {
                return CreateInstanceMock<IPaymentStrategy>(strategyType);
            }

            throw new ArgumentException("Método de pagamento inválido");
        }

        private static T CreateInstanceMock<T>(Type type)
            => (T)Activator.CreateInstance(type);

        private static Dictionary<string, Type> CreateMappings() => new ()
        {
            { "pix", typeof(PixPaymentStrategy) },
            { "creditcard", typeof(CreditCardPaymentStrategy) },
            { "paypal", typeof(PaypalPaymentStrategy) }
        };
    }
}
