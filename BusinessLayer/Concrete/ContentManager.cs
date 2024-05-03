using System;
using BusinessLayer.Abstrack;
using DataAccessLayer.Abstract;

using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
	public class ContentManager:IContentService
	{

        IContentDal contentDal;

        public ContentManager(IContentDal contentDal)
        {
            this.contentDal = contentDal;
        }

        public void ContentAdd(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentDelete(Content content)
        {
            throw new NotImplementedException();
        }

        public void ContentUpdate(Content content)
        {
            throw new NotImplementedException();
        }

        public Category GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Content> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Content> GetListByHeadingId(int id)
        {
            return contentDal.List(x => x.HeadingID == id);
        }
    }
}

