using System;
using BusinessLayer.Abstrack;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            this.writerDal = writerDal;
        }

        public Writer GetByID(int id)   
        {
            return writerDal.Get(x => x.WriterID == id);
        }

        public List<Writer> Getlist()
        {
            return writerDal.List();
        }

        public void WriterAdd(Writer writer)
        {
             writerDal.Insert(writer);
        }

        public void WriterDelete(Writer writer)
        {
            writerDal.Delete(writer);
        }

        public void WriterUpdate(Writer writer)
        {
            writerDal.Update(writer);
        }
    }
}

