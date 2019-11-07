using System;
using System.Collections.Generic;
using System.Text;

namespace BibliotecaApp.Repository
{
    interface IRepository<T>
    {
        /// <summary>
        /// Metodos de un crud
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T getByID(int id);
        List<T> getAll();
        bool Create(T item);
        bool Delete(int id);
        bool Update(int id,T item);

    }
}
