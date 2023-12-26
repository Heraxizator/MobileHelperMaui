using MobileHelper.Models.Items;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHelperMaui.Services.DataStores
{
    public static class QuotsDataStore
    {
        public static IEnumerable<Quots> GetStaticQuots()
        {
            IList<Quots> list = new List<Quots>()
            {
                new Quots()
                {
                    Author = "Михаил Булгаков",
                    Text = "Что нужно для счастья? Только два, господа, только два: здоровое тело и спокойная душа."
                },

                new Quots()
                {
                    Author = "Карлос Кастанеда",
                    Text = "Когда воина одолевают страхи и сомнения, он начинается думать о смерти. Мысли о смерти - это верный способ закалить дух."
                },

                new Quots()
                {
                    Author = "Фридрих Ницше",
                    Text = "Не нужно додумывать слишком много. Это может привести к проблемам, которых раньше не было."
                },

                new Quots()
                {
                    Author = "Народная мудрость",
                    Text = "Лучше смерть, чем бесчестие."
                },

                new Quots()
                {
                    Author = "Конфуций",
                    Text = "Если тебе плюют в спину, значит, ты впереди."
                },

                new Quots()
                {
                    Author = "Лучше отпустить преступника, чем наказать невиновного.",
                    Text = "Юстиниан Первый"
                }
            };

            return list;
        }
    }
}
