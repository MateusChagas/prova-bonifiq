using ProvaPub.Models;

namespace ProvaPub.Services
{
    public class OrderService
    {

        public async Task<Order> PayOrder(EnumPayment EnumPayment, decimal paymentValue, int customerId)
        {

            switch (EnumPayment)
            {
                case EnumPayment.pix:
                    {
                        //Faz pagamento...
                        break;
                    }
                case EnumPayment.creditcard:
                    {
                        //Faz pagamento...
                        break;
                    }
                case EnumPayment.paypal:
                    {
                        //Faz pagamento...
                        break;
                    }
                default:
                    {
                        break;
                    }


            }


            return await Task.FromResult(new Order()
            {
                Value = paymentValue,

            });
        }
    }
}
