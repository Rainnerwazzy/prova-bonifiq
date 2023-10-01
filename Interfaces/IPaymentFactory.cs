namespace ProvaPub.Interfaces
{
    public interface IPaymentFactory
    {
        public IPaymentStrategy CreatePaymentStrategy(string paymentMethod);
    }
}
