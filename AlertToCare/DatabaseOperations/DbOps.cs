using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Reflection;

namespace AlertToCare.DatabaseOperations
{
   
    public abstract class DbOps
    {
        protected readonly SQLiteConnection DbConnection;

        protected DbOps(string filePath)
        {
            var connectionPath = @"URI=file:" + filePath;
            try
            {
                DbConnection = new SQLiteConnection(connectionPath);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public static string GetDbPath()
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var dbPath = Path.GetFullPath(Path.Combine(path ?? string.Empty, @"..\..\..\..\Hospital.db"));
            return dbPath;
        }

        protected void CloseDb()
        {
            DbConnection.Close();
        }
        protected static void EnableForeignKey(IDbCommand sqlCommand)
        {
            sqlCommand.CommandText = "PRAGMA foreign_keys=ON";
            sqlCommand.ExecuteNonQuery();
        }
    }
}
