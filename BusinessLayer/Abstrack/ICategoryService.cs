using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstrack
{
	public interface ICategoryService
	{
		List<Category> GetList();
		void CategoryAdd(Category category);
		Category GetByID(int id);
		void CategoryDelete(Category category);
		void CategoryUpdate(Category category);
	}
}

