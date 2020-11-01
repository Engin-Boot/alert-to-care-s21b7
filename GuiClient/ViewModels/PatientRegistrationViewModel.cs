using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.Models;
using GuiClient.ServerWrapper;
// ReSharper disable All
namespace GuiClient.ViewModels
{
    public class PatientRegistrationViewModel  : INotifyPropertyChanged
    {

        #region Initializers

        public PatientRegistrationViewModel()
        {
            Patient = new PatientModel();
            GenderList = new List<string>()
            {
                "Male" , "Female" , "Others"
            };
            Admit = new RelayCommand(AdmitPatient);
            RefreshCommand = new RelayCommand(RefreshView);
            InitDetails();

        }
        private void InitDetails()
        {
            var icus = GetAllIcusFromServer();
            IcuList = icus.OrderBy(a => a).ToList();
            Clear();
        }
        

        #endregion

        #region Properties

        public string SelectedIcuId
        {
            get => Patient.IcuId;
            set
            {
                Patient.IcuId = value;
                GetAllBedsForIcu(value);
                OnPropertyChanged(nameof(SelectedIcuId));
            }
        }

        public int SelectedBedId
        {
            get => Patient.BedId;
            set
            {
                Patient.BedId = value;
                OnPropertyChanged(nameof(SelectedBedId));
            } 
        }
        public string FullName
        {
            get => Patient.Name;
            set
            {
                Patient.Name = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public int Age
        {
            get => Patient.Age;
            set
            {
                Patient.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string SelectedGender
        {
            get => Patient.Gender;
            set 
            {
                Patient.Gender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }
        public string Address
        {
            get => Patient.Address;
            set {
                Patient.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string Email
        {
            get => Patient.Email;
            set
            {
                Patient.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PhoneNumber
        {
            get => Patient.PhoneNumber;
            set {
                Patient.PhoneNumber = value;
                OnPropertyChanged(nameof(PhoneNumber));
            }
        }

        public List<int> FreeBedIdsOfSelectedIcu
        {
            get => _freeBedList;
            set
            {
                _freeBedList = value;
                OnPropertyChanged(nameof(FreeBedIdsOfSelectedIcu));
            }
        }

        public string Pid
        {
            get => Patient.PId;
            set
            {
                Patient.PId = value;
                OnPropertyChanged(nameof(Pid));
            }
        }

        public List<string> GenderList
        {
            get;
        }

        public List<PatientModel> PatientList { get; set; }

        private List<BedModel> BedList
        {
            get => _bedList;
            set
            {
                _bedList = value;
                FreeBedsInParticularIcu();
            }
        }

        public List<string> IcuList
        {
            get => _icuList;

            set
            {
                _icuList = value;
                OnPropertyChanged(nameof(IcuList));
            }
        }
        private List<BedModel> _bedList;
        public List<string> BedsInIcu { get; set; }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic

        private void AdmitPatient(object obj)
        {
            var patientObj = new PatientWrapper();
            if (patientObj.AddPatient(Patient) == 1)
            {
                GetAllBedsForIcu(SelectedIcuId);
                FreeBedsInParticularIcu();
                this.Clear();
                MessageBox.Show("Patient Added successfully!");
            }
            else
            {
                MessageBox.Show("Unable to add patient");
            }
        }

        private List<string> GetAllIcusFromServer()
        {
            var wrapperObj = new IcuWrapper();
            return wrapperObj.GetAllIcu();
        }

        private void GetAllBedsForIcu(string icuId)
        {
            var wrapperObj = new BedsWrapper();
            var ret = wrapperObj.GetListOfBedsForIcu(icuId);
            BedList = ret;
        }
        private void RefreshView(object obj)
        {
            InitDetails();
        }
        private void FreeBedsInParticularIcu()
        {
            if(BedList == null) return;
            FreeBedIdsOfSelectedIcu = (from bed in BedList
                                      where bed.IcuId == SelectedIcuId && bed.BedStatus.Equals("False", StringComparison.InvariantCultureIgnoreCase)
                                      select bed.BedId).ToList();
        }

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void Clear()
        {
            SelectedIcuId = "";
            SelectedBedId = 0;
            FullName = "";
            Age = 0;
            Address = "";
            SelectedGender = "";
            PhoneNumber = "";
            Email = "";
            Pid = "";
        }
        #endregion

        #region Commands

        public ICommand Admit
        {
            get;
        }

        public ICommand RefreshCommand
        {
            get;
        }


        #endregion

        #region Private

        private List<int> _freeBedList;
        private List<string> _icuList;
        // ReSharper disable once AutoPropertyCanBeMadeGetOnly.Local
        private PatientModel Patient { get; set; }
        #endregion
    }
}
