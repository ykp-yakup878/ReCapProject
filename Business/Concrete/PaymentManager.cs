using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class PaymentManager : IPaymentService
    {
        IFakeCardDal _fakeCardDal;
        public PaymentManager(IFakeCardDal fakeCardDal)
        {
            _fakeCardDal = fakeCardDal;
        }
        public IResult Add(Payment payment)
        {
            _fakeCardDal.Add(payment);
            return new SuccessResult();
        }

        public IResult Delete(Payment payment)
        {
            _fakeCardDal.Delete(payment);
            return new SuccessResult();
        }

        public IDataResult<List<Payment>> GetAll()
        {
            var result = _fakeCardDal.GetAll();
            return new SuccessDataResult<List<Payment>>(result);
        }

        public IDataResult<List<Payment>> GetByCardNumber(string cardNumber)
        {
            var result = _fakeCardDal.GetAll(p => p.CardNumber == cardNumber);
            return new SuccessDataResult<List<Payment>>(result);
        }

        public IDataResult<Payment> GetById(int paymentId)
        {
            var result = _fakeCardDal.Get(p => p.Id == paymentId);
            return new SuccessDataResult<Payment>(result);
        }

        public IResult IsCardExist(Payment fakeCard)
        {
            var result = _fakeCardDal.Get(p => p.NameOnTheCard == fakeCard.NameOnTheCard && 
            p.CardNumber == fakeCard.CardNumber && p.CardCvv == fakeCard.CardCvv);
            if (result!=null)
            {
                return new SuccessResult();
            }
            return new ErrorResult();
        }

        public IResult Update(Payment payment)
        {
            _fakeCardDal.Update(payment);
            return new SuccessResult();
        }
    }
}
