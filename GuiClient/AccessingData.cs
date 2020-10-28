using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuiClient
{
    public class AccessingData
    {
        public readonly List<PatientModel> Patients = new List<PatientModel>();
        public readonly List<IcuModel> Icu = new List<IcuModel>();
        public readonly List<BedModel> Beds = new List<BedModel>();
        public readonly List<string> GenderList = new List<string>()
        {
            "Male","Female","X"
        };

        public Dictionary<string, List<PatientModel>> IcuWithPatients = new Dictionary<string, List<PatientModel>>();


    

        public AccessingData()
        {
            InitializePatients();
            InitializeBeds();
            InitializeIcu();
            InitializeIcuWithPatientsDict();
        }

        private void InitializePatients()
        {
            Patients.Add(new PatientModel()
            {

                Name = "Abc",
                Address = "",
                Age = 12,
                BedId = 1001,
                Email = "abc",
                Gender = "Female",
                IcuId = "I001",
                PhoneNumber = "8945761248",
                PId = "P142"

            });

            Patients.Add(new PatientModel()
            {

                Name = "Abc",
                Address = "",
                Age = 12,
                BedId = 1002,
                Email = "abc",
                Gender = "Female",
                IcuId = "I001",
                PhoneNumber = "8945761248",
                PId = "P143"

            });
        }

        private void InitializeIcu()
        {
            Icu.Add(new IcuModel()
            {
                IcuId = "I001",
                BedCount = 3
                    
            });
            Icu.Add(new IcuModel()
            {
                IcuId = "I002",
                BedCount = 2

            });
        }

        private void InitializeBeds()
        {
            Beds.Add(new BedModel()
            {
                BedId = 1,
                BedLayout = "left",
                BedStatus = "Occupied",
                IcuId = "I001",
                BedNumber = 1
            });
            Beds.Add(new BedModel()
            {
                BedId = 2,
                BedLayout = "right",
                BedStatus = "Occupied",
                IcuId = "I001",
                BedNumber = 2
            });
            Beds.Add(new BedModel()
            {
                BedId = 3,
                BedLayout = "center",
                BedStatus = "Free",
                IcuId = "I001",
                BedNumber = 3
            });
            Beds.Add(new BedModel()
            {
                BedId = 4,
                BedLayout = "center",
                BedStatus = "Free",
                IcuId = "I002",
                BedNumber = 1
            });
            Beds.Add(new BedModel()
            {
                BedId = 5,
                BedLayout = "left",
                BedStatus = "Free",
                IcuId = "I002",
                BedNumber = 2
            });
        }

        private void InitializeIcuWithPatientsDict()
        {
            IcuWithPatients.Add("Icu001",new List<PatientModel>()
            {

            });
        }
    }
}
