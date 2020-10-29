using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Net;
using AlertToCare.Models;

namespace AlertToCare.DatabaseOperations
{
    public class IcuDbOps: DbOps
    {
        public IcuDbOps(string filePath) : base(filePath)
        {
        }

        public object AddIcuToDb(IcuModel newIcu)
        {
            DbConnection.Open();
            using var command = DbConnection.CreateCommand();
            EnableForeignKey(command);
            try
            {
                command.CommandText =
                    @"INSERT INTO Icu(IcuId, BedCount)" +
                    "VALUES (@IcuId, @BedCount);";
                command.Parameters.AddWithValue(@"IcuId", newIcu.IcuId);
                command.Parameters.AddWithValue(@"BedCount", newIcu.BedCount);
                command.Prepare();
                command.ExecuteNonQuery();
                return HttpStatusCode.OK;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return HttpStatusCode.InternalServerError;
            }
            finally
            {
                CloseDb();
            }
        }

        private static void EnableForeignKey(IDbCommand sqlCommand)
        {
            sqlCommand.CommandText = "PRAGMA foreign_keys=ON";
            sqlCommand.ExecuteNonQuery();
        }

        public object DeleteIcuFromDb(string icuId)
        {
            try
            {
                DbConnection.Open();
                using var command = DbConnection.CreateCommand();
                EnableForeignKey(command);
                command.CommandText = $"DELETE FROM ICU WHERE IcuId = '{icuId}';";
                command.Prepare();
                command.ExecuteNonQuery();
                return HttpStatusCode.OK;
            }
            catch (SQLiteException e)
            {
                Console.WriteLine(e);
                return HttpStatusCode.InternalServerError;
            }

            finally
            {
                CloseDb();
            }

        }

        public Dictionary<string, IcuModel> GetAllIcuFromDb()
        {
            var allIcus = new Dictionary<string, IcuModel>();
            try
            {
                DbConnection.Open();
                using var command = DbConnection.CreateCommand();
                EnableForeignKey(command);
                command.CommandText = "Select * from Icu";
                command.Prepare();
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    var icu = new IcuModel()
                    {
                        IcuId = result.GetString(0),
                        BedCount = result.GetInt32(1)
                    };
                    allIcus.Add(icu.IcuId, icu);
                }
                return allIcus;
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
