using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarFindeksManager : ICarFindeksService
    {
        ICarFindeksDal _carFindeksDal;
        public CarFindeksManager(ICarFindeksDal carFindeksDal)
        {
            _carFindeksDal = carFindeksDal;
        }
        public IResult Add(CarFindeks carFindeks)
        {
            _carFindeksDal.Add(carFindeks);
            return new SuccessResult();
        }

        public IResult Delete(CarFindeks carFindeks)
        {
            _carFindeksDal.Delete(carFindeks);
            return new SuccessResult();
        }

        public IDataResult<List<CarFindeks>> GetAll()
        {
            var result = _carFindeksDal.GetAll();
            return new SuccessDataResult<List<CarFindeks>>(result);
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetail()
        {
            var result = _carFindeksDal.GetFindeksDetail();
            return new SuccessDataResult<List<CarFindeksDetailDto>>(result);
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailByCarId(int carId)
        {
            List<CarFindeksDetailDto> carFindeksDetails = _carFindeksDal.GetFindeksDetail(x => x.CarId == carId);
            return new SuccessDataResult<List<CarFindeksDetailDto>>(carFindeksDetails);
        }

        public IDataResult<List<CarFindeksDetailDto>> GetCarFindeksDetailById(int findeksId)
        {
            List<CarFindeksDetailDto> carFindeksDetails = _carFindeksDal.GetFindeksDetail(x => x.FindeksId == findeksId);
            return new SuccessDataResult<List<CarFindeksDetailDto>>(carFindeksDetails);
        }

        public IResult Update(CarFindeks carFindeks)
        {
            _carFindeksDal.Update(carFindeks);
            return new SuccessResult();
        }
    }
}
