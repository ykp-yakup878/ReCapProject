using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IRentalService
    {
        IDataResult<List<Rental>> GetAll();
        IDataResult<List<RentalDetailDto>> GetRentalDetails();
        IDataResult<Rental> GetById(int id);
        //IDataResult<Rental> GetAllByCarId(int id);
        IResult Add(Rental rental, int day,int paymentId);
        IResult Update(Rental rental);
        IResult Delete(Rental rental);
    }
}
