﻿using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using Core.Utilities.Business;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;
        IPaymentService _paymentService;
        ICarService _carService;

        public RentalManager(IRentalDal rentalDal, IPaymentService paymentService, ICarService carService)
        {
            _rentalDal = rentalDal;
            _paymentService = paymentService;
            _carService = carService;
        }

        public IResult Add(Rental rental, int day, int paymentId)
        {
            rental.ReturnDate = rental.RentDate.AddDays(day);
            var result = BusinessRules.Run(IsRentable(rental),
                Payment(paymentId, rental.CarId));
            if (result != null)
            {
                return new ErrorResult(result.Message);
            }

            _rentalDal.Add(rental);
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Delete(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.DeleteRental);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IDataResult<Rental> GetById(int id)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(p => p.Id == id));
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        //Business Ruless
        public IResult IsRentable(Rental rental)
        {
            var results = _rentalDal.GetAll(r => r.CarId == rental.CarId && rental.ReturnDate > DateTime.Now);

            foreach (var result in results)
            {
                if (result == null || result.ReturnDate > DateTime.Now)
                {
                    if (result.ReturnDate < DateTime.Now)
                    {
                        return new SuccessResult();
                    }
                    else
                    {
                        var rDate = result.ReturnDate.Value.ToLongDateString();
                        return new ErrorResult(Messages.CannotBeRented + " " + rDate + " " + "Tarihinden sonra kiralama mevcut olur");
                    }
                }
            }
            return new SuccessResult();
        }
        public IResult Payment(int paymentId, int carId)
        {
            var carPrice = _carService.GetById(carId).Data.DailyPrice;
            var payment = _paymentService.GetById(paymentId);
            if (carPrice < payment.Data.MoneyInTheCard)
            {
                return new SuccessResult();
            }
            return new ErrorResult(Messages.InsufficientCredit + " " + "Krediniz:" + " " + payment.Data.MoneyInTheCard);
        }

    }
}
