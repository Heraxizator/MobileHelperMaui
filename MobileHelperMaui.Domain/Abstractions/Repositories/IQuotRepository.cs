using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Repositories
{
    public interface IQuotRepository
    {
        /// <summary>
        /// Inserts a quot
        /// </summary>
        /// <param name="quot">The quot entity</param>
        void Insert(Quot quot);

        /// <summary>
        /// A method to get quots
        /// </summary>
        /// <returns>Returns quots</returns>
        Task<IList<Quot>> GetAll();

        /// <summary>
        /// A method to get quot by identifier
        /// </summary>
        /// <returns>Returns quot</returns>
        Task<Quot> GetById(int id);

        /// <summary>
        /// Deletes quot
        /// </summary>
        /// <param name="quot">The quot entity</param>
        void Delete(Quot quot);

    }
}
