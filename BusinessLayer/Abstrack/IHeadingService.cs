using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstrack
{
	public interface IHeadingService
	{

        List<Heading> GetList();
        void HeadingAdd(Heading heading);
        Heading GetByID(int id);
        void HeadingDelete(Heading heading);
        void HeadingUpdate(Heading heading);
    }
}

