using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GuiClient.Annotations;
using GuiClient.Commands;

namespace GuiClient.ViewModels
{
    public class PatientRegistrationViewModel  : INotifyPropertyChanged
    {
        private readonly PatientModel _patient = new PatientModel();
        //private readonly AccessingData _accessing = new AccessingData();

        #region Fields

        private List<int> _freeBedList;
        #endregion

        #region Initializers

        public PatientRegistrationViewModel()
        {
            GenderList = new List<string>()
            {
                "Male" , "Female" , "Others"
            };
            Admit = new RelayCommand(AdmitPatient);
        }

        private void AdmitPatient(object obj)
        {
            IcuList = GetAllIcusFromServer();
        }

        private List<IcuModel> GetAllIcusFromServer()
        {
            throw new NotImplementedException();
        }
        private void GetAllBedsForGivenIcu(string selectedIcuId)
        {
            
        }

        #endregion

        #region Properties

        public string SelectedIcuId
        {
            get => _patient.IcuId;
            set
            {
                _patient.IcuId = value;
                GetAllBedsForGivenIcu(SelectedIcuId);
                OnPropertyChanged(nameof(SelectedIcuId));
            }
        }

        public int SelectedBedId
        {
            get => _patient.BedId;
            set
            {
                _patient.BedId = value;
                OnPropertyChanged(nameof(SelectedBedId));
            } 
        }
        public string FullName
        {
            get => _patient.Name;
            set
            {
                _patient.Name = value;
                OnPropertyChanged(nameof(FullName));
            }
        }

        public int Age
        {
            get => _patient.Age;
            set
            {
                _patient.Age = value;
                OnPropertyChanged(nameof(Age));
            }
        }

        public string SelectedGender
        {
            get => _patient.Gender;
            set 
            {
                _patient.Gender = value;
                OnPropertyChanged(nameof(SelectedGender));
            }
        }
        public string Address
        {
            get => _patient.Address;
            set {
                _patient.Address = value;
                OnPropertyChanged(nameof(Address));
            }
        }
        public string Email
        {
            get => _patient.Email;
            set
            {
                _patient.Email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public string PhoneNumber
        {
            get => _patient.PhoneNumber;
            set {
                _patient.PhoneNumber = value;
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

        public List<string> GenderList
        {
            get;
            set;
        }

        public List<PatientModel> PatientList;
        public List<BedModel> BedList;
        public List<IcuModel> IcuList;

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic

        public void FreeBedsInParticularIcu()
        {
            FreeBedIdsOfSelectedIcu = (from bed in BedList
                                      where bed.IcuId == SelectedIcuId && bed.BedStatus == "Free"
                select bed.BedId).ToList();
        }

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public void Admit_Executed()
        {
            //if (Save_CanExecute(parameter))
            //{
            //    //add the patient in the database
            //      set occupied and stuff.
            //}
        }
        public bool Admit_CanExecute()
        {
           return !(string.IsNullOrEmpty(SelectedIcuId) || SelectedBedId<0 || string.IsNullOrEmpty(FullName) ||
                     Age <= 0 || Age > 150 || string.IsNullOrEmpty(SelectedGender) || string.IsNullOrEmpty(Address) ||
                     string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Email));
        }

        public void Clear()
        {
            SelectedIcuId = "";
            SelectedBedId = 0;
            FullName = "";
            Age = 0;
            Address = "";
            SelectedGender = "";
            PhoneNumber = "";
            Email = "";
        }
        #endregion

        #region Commands

        public ICommand Admit
        {
            get;
            set;
        }


        #endregion
    }
}
