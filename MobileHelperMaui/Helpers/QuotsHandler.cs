using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Application.Handlers;
using MobileHelperMaui.Domain.Abstractions.Mappers;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Services;
using System.Text.Json;

namespace MobileHelperMaui.Helpers
{
    public static class QuotsHandler
    {
        public static async Task<Quots> GetQuot()
        {
            IHandler<Quot> handler = new QuotHandler();

            Quot quot = await handler.Handle();

            Quots quots = AbstractMapper<Quot, Quots>.MapperA.Map<Quots>(quot);

            return quots;
        }

        public static async Task<bool> SaveQuot(Quots quot)
        {
            int count = (await DBRepository.GetQuots()).Count;

            QuotDB quotDB = new()
            {
                Id = count + 1,
                Author = quot.Author,
                Text = quot.Text
            };

            bool result = DBRepository.AddQuot(quotDB);

            return result;
        }

        public static IList<Quots> ParseQuots(IList<QuotDB> list)
        {
            IList<Quots> quots = new List<Quots>();

            foreach (QuotDB quotDB in list)
            {
                Quots quot = new()
                {
                    Author = quotDB.Author,
                    Text = quotDB.Text
                };

                quots.Add(quot);
            }

            return quots;
        }

        public static async Task InitQuotsAsync()
        {
            Quots elem = await GetQuot();

            _ = SaveQuot(elem);
        }

        public class QuotItem
        {
            public string quoteText { get; set; }
            public string quoteAuthor { get; set; }
            public string senderName { get; set; }
            public string senderLink { get; set; }
            public string quoteLink { get; set; }
        }
    }
}
