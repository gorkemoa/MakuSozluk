using System;
using BusinessLayer.Abstrack;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            this.headingDal = headingDal;
        }

        public Heading GetByID(int id)
        {
            return headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetList()
        {
            return headingDal.List();
        }

        public void HeadingAdd(Heading heading)
        {
            headingDal.Insert(heading);
        }

        public void HeadingDelete(Heading heading)
        {
            headingDal.Delete(heading);
        }

        public void HeadingUpdate(Heading heading)
        {
            headingDal.Update(heading);
        }
    }
}

