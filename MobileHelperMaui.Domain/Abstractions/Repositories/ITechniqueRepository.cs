using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MobileHelperMaui.Domain.Abstractions.Repositories
{
    public interface ITechniqueRepository
    {
        /// <summary>
        /// A method to get techniques
        /// </summary>
        /// <returns>Returns techniques</returns>
        Task<IList<Technique>> GetAll();

        /// <summary>
        /// A method to get technique by identifier
        /// </summary>
        /// <returns>Returns technique by identifier</returns>
        Task<Technique> GetById(int id);

        /// <summary>
        /// A method to insert technique
        /// </summary>
        void Insert(Technique technique);

        /// <summary>
        /// A method to update the technique
        /// </summary>
        void Update(Technique technique);

        /// <summary>
        /// A method to deletere the technique
        /// </summary>
        void Delete(Technique technique);
    }
}
