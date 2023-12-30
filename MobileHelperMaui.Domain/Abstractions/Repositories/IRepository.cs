using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Repositories
{
    public interface IRepository<T>
    {
        /// <summary>
        /// Inserts an object of type T
        /// </summary>
        /// <param name="item">The T entity</param>
        void Insert(T item);

        /// <summary>
        /// A method to get objects of type T
        /// </summary>
        /// <returns>Returns quots</returns>
        Task<IList<T>> GetAll();

        /// <summary>
        /// A method to get object of type T by identifier
        /// </summary>
        /// <returns>Returns quot</returns>
        Task<T> GetById(int id);

        /// <summary>
        /// Deletes an object of type T
        /// </summary>
        /// <param name="item">The T entity</param>
        void Delete(T item);

        /// <summary>
        /// Updates an object of type T
        /// </summary>
        /// <param name="item">The T entity</param>
        void Update(T item);
    }
}
