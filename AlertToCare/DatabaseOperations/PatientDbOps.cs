﻿using System;
using System.Collections.Generic;
using System.Net;
using AlertToCare.Models;

namespace AlertToCare.DatabaseOperations
{
    public class PatientDbOps: DbOps
    {
        public PatientDbOps(string filePath) : base(filePath) { }

        public object AddPatientToDb(PatientModel newPatient)
        {
            DbConnection.Open();
            using var command = DbConnection.CreateCommand();
            try
            {
                command.CommandText =
                    @"INSERT INTO Patients(Pid, Name, Age, Gender, Email, PhoneNumber, Address, IcuID, BedID )" +
                    "VALUES (@Pid, @Name, @Age, @Gender, @Email, @PhoneNumber, @Address, @IcuID, @BedId);";
                command.Parameters.AddWithValue(@"Pid", newPatient.PId);
                command.Parameters.AddWithValue(@"Name", newPatient.Name);
                command.Parameters.AddWithValue(@"Age", newPatient.Age);
                command.Parameters.AddWithValue(@"Gender", newPatient.Gender);
                command.Parameters.AddWithValue(@"Email", newPatient.Email);
                command.Parameters.AddWithValue(@"PhoneNumber", newPatient.PhoneNumber);
                command.Parameters.AddWithValue(@"Address", newPatient.Address);
                command.Parameters.AddWithValue(@"IcuID", newPatient.IcuId);
                command.Parameters.AddWithValue(@"BedId", newPatient.BedId);
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

        public object DeletePatientFromDatabase(string pid)
        {
            DbConnection.Open();
            using var command = DbConnection.CreateCommand();
            try
            {
                command.CommandText = $"DELETE from Patients where pid = '{pid}';";
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

        public Dictionary<string, PatientModel> GetAllPatientsFromDb()
        {
            DbConnection.Open();
            var allPatients = new Dictionary<string, PatientModel>();
            using var command = DbConnection.CreateCommand();
            try
            {
                command.CommandText = "Select * from Patients";
                command.Prepare();
                command.ExecuteNonQuery();
                var result = command.ExecuteReader();
                while (result.Read())
                {
                    var patient = new PatientModel
                    {
                        PId = result.GetString(0),
                        Name = result.GetString(1),
                        Age = result.GetInt32(2),
                        Gender = result.GetString(3),
                        Email = result.GetString(4),
                        PhoneNumber = result.GetString(5),
                        Address = result.GetString(6),
                        IcuId = result.GetString(7),
                        BedId = result.GetInt32(8)
                    };


                    allPatients.Add(patient.PId, patient);
                }

                return allPatients;
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
