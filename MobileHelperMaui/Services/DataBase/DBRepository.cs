using Microsoft.EntityFrameworkCore;
using MobileHelper.Models.Tables;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MobileHelperMaui.Services.DataBase
{
    public class DBRepository
    {
        #region Techniques methods
        public static IList<TechniqueDB> GetTechniques()
        {
            SQLiteDB db = new SQLiteDB();

            List<TechniqueDB> list = db.Techniques.Where(x => x.Removed == false).ToList();

            return list;
        }

        public static int CountTechniques()
        {
            SQLiteDB db = new SQLiteDB();

            IList<TechniqueDB> items = GetTechniques();

            int count = items.Count;

            return count;
        }

        public static bool AddTechnique(TechniqueDB technique)
        {
            SQLiteDB db = new SQLiteDB();

            try
            {
                _ = db.Add(technique);

                _ = db.SaveChanges();

                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static bool RemoveTechnique(TechniqueDB technique)
        {
            SQLiteDB db = new SQLiteDB();

            try
            {
                _ = db.Remove(technique);

                _ = db.SaveChanges();

                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static bool RemoveTechniqueById(int id)
        {
            SQLiteDB db = new SQLiteDB();

            try
            {
                TechniqueDB item = db.Techniques.FirstOrDefault(x => x.Id == id);

                RemoveTechnique(item);

                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static bool UpdateTechnique(TechniqueDB technique)
        {
            try
            {
                RemoveTechnique(technique);

                AddTechnique(technique);

                return true;
            }

            catch (Exception e)
            {
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static TechniqueDB GetTechniqueById(int id)
        {
            SQLiteDB db = new SQLiteDB();

            DbSet<TechniqueDB> items = db.Techniques;

            TechniqueDB item = items.FirstOrDefault(x => x.Id == id && x.Removed == false);

            return item;
        }

        #endregion

        #region Quots methods

        public static IList<QuotDB> GetQuots()
        {
            SQLiteDB db = new SQLiteDB();

            IList<QuotDB> list = db.Quots.
                Where(x => x.Removed == false).ToList();

            return list;
        }

        public static bool AddQuots(IList<QuotDB> list)
        {
            try
            {
                SQLiteDB db = new SQLiteDB();

                db.AddRange(list);

                db.SaveChanges();

                return true;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
