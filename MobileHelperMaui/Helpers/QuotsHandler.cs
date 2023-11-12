using MobileHelper.Models.Items;
using MobileHelper.Models.Tables;
using MobileHelperMaui.Services.DataBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileHelper.Helpers
{
    public static class QuotsHandler
    {
        private static readonly string api_url = "http://api.forismatic.com/api/1.0/?method=getQuote&lang=ru&format=json";

        public static async Task<Quots> GetQuot()
        {
            try
            {
                HttpClient httpClient = new HttpClient();

                HttpResponseMessage response = await httpClient.GetAsync(api_url);

                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }

                string json = await response.Content.ReadAsStringAsync();

                QuotItem item = JsonSerializer.Deserialize<QuotItem>(json);

                Quots quot = new Quots
                {
                    Text = item.quoteText,
                    Author = !string.IsNullOrEmpty(item.quoteAuthor)
                    ? item.quoteAuthor : "Народная мудрость"
                };

                return quot;
            }

            catch (IOException ioe)
            {
                Console.WriteLine(ioe.Message);
                return null;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public static async Task<IList<Quots>> GetQuots(int count)
        {
            IList<Quots> quots = new List<Quots>();

            for (int i = 0; i < count; i++)
            {
                Quots quot = await GetQuot();

                if (quot == null)
                {
                    continue;
                }

                quots.Add(quot);
            }

            return quots;
        }

        public static bool SaveQuots(IList<Quots> quots)
        {
            IList<QuotDB> list = new List<QuotDB>();

            foreach (Quots quot in quots)
            {
                QuotDB quotDB = new QuotDB
                {
                    Author = quot.Author,
                    Text = quot.Text
                };

                list.Add(quotDB);
            }

            bool result = DBRepository.AddQuots(list);

            return result;
        }

        public static IList<Quots> ParseQuots(IList<QuotDB> list)
        {
            IList<Quots> quots = new List<Quots>();

            foreach (QuotDB quotDB  in list)
            {
                Quots quot = new Quots
                {
                    Author = quotDB.Author,
                    Text = quotDB.Text
                };

                quots.Add(quot);
            }

            return quots;
        }

        public static async Task InitQuotsAsync(int count)
        {
            IList<Quots> elems = await GetQuots(count);

            _ = SaveQuots(elems);
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
