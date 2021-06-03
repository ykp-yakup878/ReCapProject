using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPaymentService
    {
        IResult Add(Payment payment);
        IResult Delete(Payment payment);
        IResult Update(Payment payment);
        IDataResult<List<Payment>> GetAll();
        IDataResult<Payment> GetById(int paymentId);
        IDataResult<List<Payment>> GetByCardNumber(string cardNumber);
        IResult IsCardExist(Payment fakeCard);
    }
}
