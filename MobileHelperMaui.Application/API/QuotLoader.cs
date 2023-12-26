using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Constants;
using MobileHelperMaui.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MobileHelperMaui.Application.API
{
    public class QuotLoader : ILoader<Quot>
    {
        public async Task<Quot> Load()
        {
            HttpClient httpClient = new();

            HttpResponseMessage response = await httpClient.GetAsync(Constants.QuotApiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            string json = await response.Content.ReadAsStringAsync();

            QuotItem item = JsonSerializer.Deserialize<QuotItem>(json);

            Quot quot = new()
            {
                Text = item.quoteText,
                Author = !string.IsNullOrEmpty(item.quoteAuthor)
                ? item.quoteAuthor : "Народная мудрость"
            };

            return quot;
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
