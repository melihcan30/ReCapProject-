using Core.Entities.Concrete.Fake;
using Core.Utilities.Results;
using Core.Utilities.Results.Abstract;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult MakePayment(IPaymentModel paymentModel);
    }
}