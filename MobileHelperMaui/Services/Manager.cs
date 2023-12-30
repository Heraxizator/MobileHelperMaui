using AutoMapper;
using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Application.Quots.CreateQuot;
using MobileHelperMaui.Application.Quots.Get;
using MobileHelperMaui.Application.Share;
using MobileHelperMaui.Domain.Abstractions.Mappers;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Infrastructure.Repositories;

namespace MobileHelperMaui.Services
{
    public class Manager
    {
        private static readonly IDataRepository dataRepository = new DataRepository();

        #region Repositories

        private static readonly IRepository<Quot> quotsRepository = dataRepository.GetQuotRepository();

        private static readonly IRepository<Technique> techniquesRepository = dataRepository.GetTechniqueRepository();

        #endregion

        #region Handlers

        private static readonly CreateQuotHandler createQuotHandler = new();

        private static readonly GetQuotHandler getQuotHandler = new();

        #endregion

        #region Commands

        private static readonly CreateQuotCommand createQuotCommand = new(createQuotHandler, quotsRepository);

        private static readonly GetQuotQuery getQuotQuery = new(getQuotHandler, quotsRepository);

        #endregion

        #region Invokers

        private readonly CommandInvoker<bool> createQuotInvoker = new();

        private readonly QueryInvoker<Quot> getQuotInvoker = new();

        #endregion

        public Manager()
        {
            this.createQuotInvoker.SetCommand(createQuotCommand);

            this.getQuotInvoker.SetQuery(getQuotQuery);
        }

        #region Techniques methods

        // The Technique Repository From Abstract Factory
        private static readonly IRepository<Technique> techniqueRepository = dataRepository.GetTechniqueRepository();

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
        //private static readonly IRepository<Quot> quotsRepository = dataRepository.GetQuotRepository();

        // From the Quot type to the QuotDB type Mapper
        private static readonly Mapper quotsMapperA = AbstractMapper<Quot, QuotDB>.MapperA;

        // From the QuotDB type to the Quot type Mapper
        private static readonly Mapper quotsMapperB = AbstractMapper<Quot, QuotDB>.MapperB;

        public static async Task<IList<QuotDB>> GetQuots()
        {
            IList<Quot> quots = await getQuotQuery.Select();

            IList<QuotDB> quotDBs = quotsMapperA.Map<IList<QuotDB>>(quots);

            return quotDBs;
        }

        public static bool AddQuot()
        {
            _ = createQuotCommand.Execute();

            return true;
        }

        public static IList<Quots> Parse(IList<QuotDB> list)
        {
            Mapper mapper = AbstractMapper<QuotDB, Quots>.MapperA;

            IList<Quots> quots = mapper.Map<IList<Quots>>(list);

            return quots;
        }

        #endregion
    }
}