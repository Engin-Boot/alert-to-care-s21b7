using System;
using System.Collections.Generic;
using System.Net;
using AlertToCare.Models;

namespace AlertToCare.DatabaseOperations
{
    public class BedDbOps : DbOps
    {
        public BedDbOps(string filePath) : base(filePath)
        {
        }

        public object AddBedToDb(BedModel newBed)
        {
            
            try
            {
                DbConnection.Open();
                using var command = DbConnection.CreateCommand();
                command.CommandText =
                    @"INSERT INTO BEDS(IcuId, BedLayout, BedNo)" +
                    "VALUES (@IcuId, @BedLayout, @BedNo);";
                command.Parameters.AddWithValue(@"IcuId", newBed.IcuId);
                command.Parameters.AddWithValue(@"BedLayout", newBed.BedLayout);
                command.Parameters.AddWithValue(@"BedNo", newBed.BedNumber);
                command.Prepare();
                command.ExecuteNonQuery();
                return AddBedStatusWhenBedAdded();
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

        private object AddBedStatusWhenBedAdded()
        {
            var command = DbConnection.CreateCommand();
            command.CommandText = @"INSERT INTO BEDSTATUS(OCCUPIED) VALUES ( @OCCUPIED);";
            command.Parameters.AddWithValue(@"OCCUPIED", bool.Parse("false"));
            command.Prepare();
            command.ExecuteNonQuery();
            return HttpStatusCode.OK;

        }

        public object DeleteBedFromDb(int bedId)
        {
            DbConnection.Open();
            using var command = DbConnection.CreateCommand();
            DeleteBedStatus(bedId);
            command.CommandText = $"Delete FROM Beds WHERE BEDID = {bedId}";
            command.Prepare();
            command.ExecuteNonQuery();
            CloseDb();
            return HttpStatusCode.OK;
        }

        public object ChangeBedStatusToVacant(int bedId)
        {
            try
            {
                DbConnection.Open();
                DeleteBedStatus(bedId);
                var command = DbConnection.CreateCommand();
                command.CommandText = @"INSERT INTO BEDSTATUS(BEDID, OCCUPIED) VALUES (@BEDID , @OCCUPIED);";
                command.Parameters.AddWithValue(@"BEDID", bedId);
                command.Parameters.AddWithValue(@"OCCUPIED", bool.Parse("false"));
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

        public Dictionary<int, BedModel> GetAllBedsFromDb()
        {
            
            var allBeds = new Dictionary<int, BedModel>();
            
            try
            {
                DbConnection.Open();
                using var command = DbConnection.CreateCommand();
                command.CommandText = "SELECT BedId, IcuId, BedLayout, BedNo, Occupied from Beds NATURAL JOIN Bedstatus;";
                command.Prepare();
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    var bed = new BedModel
                    {
                        BedId = result.GetInt32(0),
                        IcuId = result.GetString(1),
                        BedLayout = result.GetString(2),
                        BedNumber = result.GetString(3),
                        BedStatus = result.GetBoolean(4).ToString()
                    };

                    allBeds.Add(bed.BedId, bed);
                }
                return allBeds;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                return null;
            }
            finally
            {
                CloseDb();
            }

        }

        private void DeleteBedStatus(int bedId)
        {
            var command = DbConnection.CreateCommand();
            command.CommandText = $"Delete from Bedstatus where BedId = {bedId}";
            command.Prepare();
            command.ExecuteNonQuery();
        }

        public object ChangeBedStatusToOccupied(int bedId)
        {
            
            try
            {
                DbConnection.Open();
                DeleteBedStatus(bedId);
                var command = DbConnection.CreateCommand();
                command.CommandText = "INSERT INTO BEDSTATUS VALUES (@BEDID, @OCCUPIED)";
                command.Parameters.AddWithValue(@"BEDID", bedId);
                command.Parameters.AddWithValue(@"OCCUPIED", bool.Parse("true"));
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

        public bool IsBedFree(int bedId)
        {
           
            try
            {
                DbConnection.Open();
                var command = DbConnection.CreateCommand();
                command.CommandText = $"SELECT Occupied FROM Bedstatus WHERE BEDID = {bedId};";
                command.Prepare();
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                var retVal = false;
                while (result.Read())
                {
                    retVal = !result.GetBoolean(0);
                }
                return retVal;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
            finally
            {
                CloseDb();
            }
        }
    }
}
