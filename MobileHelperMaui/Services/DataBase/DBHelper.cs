using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MobileHelper.Models.Tables;
using System;
using System.Collections.Generic;
using System.Text;

namespace MobileHelperMaui.Services.DataBase
{
    public static class DBHelper
    {
        private static readonly SQLiteDB db = new SQLiteDB();
        public static void Init()
        {
            CreateTables();
        }

        public static void CreateTables()
        {
            try
            {
                RelationalDatabaseCreator databaseCreator = (RelationalDatabaseCreator)db.Database.GetService<IDatabaseCreator>();
                databaseCreator.CreateTables();
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
