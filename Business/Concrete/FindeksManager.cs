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
    public class FindeksManager : IFindeksService
    {
        IFindeksDal _findeksDal;
        public FindeksManager(IFindeksDal findeksDal)
        {
            _findeksDal = findeksDal;
        }
        public IResult Add(Findeks findeks)
        {
            _findeksDal.Add(findeks);
            return new SuccessResult();
        }

        public IResult Delete(Findeks findeks)
        {
            _findeksDal.Delete(findeks);
            return new SuccessResult();
        }

        public IDataResult<List<Findeks>> GetAll()
        {
            var result = _findeksDal.GetAll();
            return new SuccessDataResult<List<Findeks>>(result);
        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetail()
        {
            var result = _findeksDal.GetFindeksDetail();
            return new SuccessDataResult<List<FindeksDetailDto>>(result);
        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetailByFindeksId(int findeksId)
        {
            List<FindeksDetailDto> result = _findeksDal.GetFindeksDetail(f=>f.FindeksId==findeksId);
            return new SuccessDataResult<List<FindeksDetailDto>>(result);
        }

        public IDataResult<List<FindeksDetailDto>> GetFindeksDetailByUserId(int userId)
        {
            List<FindeksDetailDto> result = _findeksDal.GetFindeksDetail(f=>f.UserId==userId);
            return new SuccessDataResult<List<FindeksDetailDto>>(result);
        }

        public IResult Update(Findeks findeks)
        {
            _findeksDal.Update(findeks);
            return new SuccessResult();
        }
    }
}
