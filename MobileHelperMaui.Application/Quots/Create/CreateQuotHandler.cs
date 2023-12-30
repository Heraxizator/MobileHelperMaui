using MobileHelperMaui.Application.Share.Result;
using MobileHelperMaui.Domain.Abstractions.Database;
using MobileHelperMaui.Domain.Abstractions.Repositories;
using MobileHelperMaui.Domain.Abstractions.Services;
using MobileHelperMaui.Domain.Constants;
using MobileHelperMaui.Domain.Entities;
using MobileHelperMaui.Domain.Exceptions;
using System.Text.Json;

namespace MobileHelperMaui.Application.Quots.CreateQuot
{
    public class CreateQuotHandler : IHandler<Quot, Result>
    {
        public async Task<Result> Handle(IRepository<Quot> repository)
        {
            HttpClient httpClient = new();

            HttpResponseMessage response = await httpClient.GetAsync(Constants.QuotApiUrl);

            if (!response.IsSuccessStatusCode)
            {
                return Result.Failure(QuotErrors.CanNotLoad);
                //throw new QuotLoadException("Can not load Quot object from Api");
            }

            string json = await response.Content.ReadAsStringAsync();

            QuotItem item = JsonSerializer.Deserialize<QuotItem>(json);

            IList<Quot> list = await repository.GetAll();

            int nextId = list.Max(x => x.Id);

            Quot quot = new()
            {
                Id = nextId + 1,
                Text = item.quoteText,
                Author = item.quoteAuthor
            };

            CreateQuotValidator validator = new();

            bool result = validator.IsValid(quot);

            if (result is false)
            {
                return Result.Failure(QuotErrors.BadQuot);
                //throw new BadQuotException("The quot does not satisfies one or more requirements");
            }

            repository.Insert(quot);

            return Result.Success();
        }

        private class QuotItem
        {
            public string quoteText { get; set; }
            public string quoteAuthor { get; set; }
            public string senderName { get; set; }
            public string senderLink { get; set; }
            public string quoteLink { get; set; }
        }
    }
}
