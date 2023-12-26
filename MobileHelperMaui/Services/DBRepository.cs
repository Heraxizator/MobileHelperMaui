using AutoMapper;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Domain.Abstractions.Mappers;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Infrastructure.Repositories;

namespace MobileHelperMaui.Services
{
    public class DBRepository
    {
        private static readonly IDataRepository dataRepository = new DataRepository();

        #region Techniques methods

        // The Technique Repository From Abstract Factory
        private static readonly ITechniqueRepository techniqueRepository = dataRepository.GetTechniqueRepository();

        // From the Technique type to the TechniqueDB type Mapper
        private static readonly Mapper techniquesMapperA = AbstractMapper<Technique, TechniqueDB>.MapperA;

        // From the TechniqueDB type to the Technique type Mapper
        private static readonly Mapper techniquesMapperB = AbstractMapper<Technique, TechniqueDB>.MapperB;

        public static async Task<IList<TechniqueDB>> GetTechniques()
        {
            IList<Technique> list = await techniqueRepository.GetAll();

            IList<TechniqueDB> items = techniquesMapperA.Map<List<TechniqueDB>>(list);

            return items;
        }

        public static async Task<int> CountTechniques()
        {
            IList<Technique> list = await techniqueRepository.GetAll();

            return list.Count;
        }

        public static bool AddTechnique(TechniqueDB technique)
        {
            Technique item = techniquesMapperB.Map<Technique>(technique);

            techniqueRepository.Insert(item);

            return true;
        }

        public static bool RemoveTechnique(TechniqueDB technique)
        {
            Technique item = techniquesMapperB.Map<Technique>(technique);

            techniqueRepository.Delete(item);

            return true;
        }

        public static bool UpdateTechnique(TechniqueDB technique)
        {
            Technique item = techniquesMapperA.Map<Technique>(technique);

            techniqueRepository.Update(item);

            return true;
        }

        public static async Task<TechniqueDB> GetTechniqueById(int id)
        {
            Technique technique = await techniqueRepository.GetById(id);

            TechniqueDB techniqueDB = techniquesMapperA.Map<TechniqueDB>(technique);

            return techniqueDB;
        }

        #endregion

        #region Quots methods

        // The Quot Repository From Abstract Factory
        private static readonly IQuotRepository quotsRepository = dataRepository.GetQuotRepository();

        // From the Quot type to the QuotDB type Mapper
        private static readonly Mapper quotsMapperA = AbstractMapper<Quot, QuotDB>.MapperA;

        // From the QuotDB type to the Quot type Mapper
        private static readonly Mapper quotsMapperB = AbstractMapper<Quot, QuotDB>.MapperB;

        public static async Task<IList<QuotDB>> GetQuots()
        {
            IList<Quot> quots = await quotsRepository.GetAll();

            IList<QuotDB> quotDBs = quotsMapperA.Map<IList<QuotDB>>(quots);

            return quotDBs;
        }

        public static bool AddQuot(QuotDB quotDB)
        {
            Quot quot = quotsMapperB.Map<Quot>(quotDB); 

            quotsRepository.Insert(quot);

            return true;
        }

        #endregion
    }
}