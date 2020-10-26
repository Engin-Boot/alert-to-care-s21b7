using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using AlertToCare.Models;
using GuiClient.Annotations;
using GuiClient.Commands;

namespace GuiClient.ViewModels
{
    public class PatientRegistrationViewModel  : INotifyPropertyChanged
    {
        private readonly PatientModel _patient = new PatientModel();
        private readonly AccessingData _accessing = new AccessingData();

        #region Fields

        private List<int> _freeBedList;
        #endregion

        #region Initializers

        public PatientRegistrationViewModel()
        {
            //Admit = new DelegateCommandClass(this.Execute,this.CanExecute);
        }

        #endregion

        #region Properties

        public string IcuId
        {
            get => _patient.IcuId;
            set
            {
                _patient.IcuId = value;
                OnPropertyChanged(nameof(IcuId));
            }
        }
        public int BedId
        {
            get => _patient.BedId;
            set
            {
                _patient.BedId = value;
                OnPropertyChanged(nameof(BedId));
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

        public string Gender
        {
            get => _patient.Gender;
            set 
            {
                _patient.Gender = value;
                OnPropertyChanged(nameof(Gender));
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

        public List<string> GenderList => _accessing.GenderList;

        public List<PatientModel> PatientList => _accessing.Patients;
        public List<BedModel> BedList => _accessing.Beds;
        
        public List<IcuModel> IcuList => _accessing.Icu;

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic

        public void FreeBedsInParticularIcu()
        {
            FreeBedIdsOfSelectedIcu = (from bed in _accessing.Beds
                                      where bed.IcuId == IcuId && bed.BedStatus == "Free"
                select bed.BedId).ToList();

        }

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
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
           return !(string.IsNullOrEmpty(IcuId) || BedId<0 || string.IsNullOrEmpty(FullName) ||
                     Age <= 0 || Age > 150 || string.IsNullOrEmpty(Gender) || string.IsNullOrEmpty(Address) ||
                     string.IsNullOrEmpty(PhoneNumber) || string.IsNullOrEmpty(Email));
        }

        public void Clear()
        {
            IcuId = "";
            BedId = 0;
            FullName = "";
            Age = 0;
            Address = "";
            Gender = "";
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
