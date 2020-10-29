using System;
using System.Collections.Generic;

namespace AlertToCare.DatabaseOperations
{
    public class BedLayoutDbOps: DbOps
    {
        public BedLayoutDbOps(string filePath) : base(filePath)
        {
        }

        public List<string> GetAllLayouts()
        {
            try
            {
                DbConnection.Open();
                var allLayouts = new List<string>();
                using var command = DbConnection.CreateCommand();
                command.CommandText = "Select * from IcuLayouts;";
                command.Prepare();
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    allLayouts.Add(result.GetString(0));
                }

                return allLayouts;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return null;
            }
            finally
            {
                CloseDb();
            }
        }
    }
}
