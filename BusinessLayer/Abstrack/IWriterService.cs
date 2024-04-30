using System;
using EntityLayer.Concrete;

namespace BusinessLayer.Abstrack
{
	public interface IWriterService
	{
		List<Writer> Getlist();
		void WriterAdd(Writer writer);
		void WriterDelete(Writer writer);
		void WriterUpdate(Writer writer);
		Writer GetByID(int id);
	}
}

