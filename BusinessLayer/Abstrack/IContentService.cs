using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstrack
{
	public interface IContentService
	{
        List<Content> GetList();
        List<Content> GetListByHeadingId(int id);
        void ContentAdd(Content content);
        Category GetByID(int id);
        void ContentDelete(Content content);
        void ContentUpdate(Content content);
    }
}

