using BibliotecaApp.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BibliotecaApp.Repository
{
    public class RBook : IRepository<Book>
    {
        /// <summary>
        /// Datros estaticos para dar permanencia en la sesion
        /// </summary>
        private static int CantRegistros;
        private static List<Book> Books;

        #region Contructor
        public RBook()
        {
            if (Books == null)///Si no hay instancia previa creo los datos
            {
                Books = new List<Book>
                {
                    new Book{ID=1,Author="Ronald Ris", BookName="El credo Maldito I"},
                    new Book{ID=2,Author="Ronald Ris", BookName="El credo Maldito II"},
                    new Book{ID=3,Author="Ronald Ris", BookName="El credo Maldito III"},
                    new Book{ID=4,Author="Ronald Ris", BookName="El credo Maldito IV"}
                };
                CantRegistros = 5;
            }

        }
        #endregion


        #region Interfaz
        /// <summary>
        /// Aca lo importante es que si el registro se agrega exitosamente, se agrega uno al contador ya que estamos trabajando con un ID
        /// Lo importante es retornar true o false segun se agregue o no
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Create(Book item)
        {
            try
            {
                item.ID = CantRegistros;
                Books.Add(item);
                CantRegistros++;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// ELIMINO el dato donde el ID coincide, en caso que no exista el id, da error y no eliminar porque no encuentra el objeto
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public bool Delete(int id)
        {
            try
            {
                Books.RemoveAt(Books.FindIndex(p => p.ID == id));
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        /// <summary>
        /// Retorno todos los libros
        /// </summary>
        /// <returns></returns>
        public List<Book> getAll()
        {
            return Books;
        }
        /// <summary>
        /// Busco un libro y lo retorno segun su ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Book getByID(int id)
        {
            return Books.Find(p => p.ID == id);
        }

        /// <summary>
        /// Busco el objeto segun el ID, luego al objeto lo inserto directamente en la posicion donde estaba el anterior con los nuevos datos
        /// </summary>
        /// <param name="id">del antiguo registro</param>
        /// <param name="item">el nuevo registro a actualizar</param>
        /// <returns></returns>

        public bool Update(int id, Book item)
        {
            try
            {
                int index = Books.FindIndex(p => p.ID == id);
                item.ID = id;
                Books[index] = item;
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
