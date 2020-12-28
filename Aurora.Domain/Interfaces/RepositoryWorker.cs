using System.Collections.Generic;
using Aurora.Domain.Entities;

namespace Aurora.Domain.Interfaces
{
    public interface RepositoryWorker
    {
        void Save(Worker obj);

        void Remove(int id);

        Worker GetById(int id);

        IList<Worker> GetAll();
    }
}

