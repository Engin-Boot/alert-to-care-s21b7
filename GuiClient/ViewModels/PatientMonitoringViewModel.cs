using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GuiClient.Annotations;
using GuiClient.Models;

namespace GuiClient.ViewModels
{
    public class PatientMonitoringViewModel :INotifyPropertyChanged
    {
        private readonly AccessingData _accessing = new AccessingData();
        private PatientModel _allPatientListInIcu;
        #region Fields

        private string _selectedIcuId;


        #endregion

        #region Initializers



        #endregion

        #region Properties

        public string IcuIdSelected
        {
            get => _selectedIcuId;
            set
            {
                _selectedIcuId = value;
                OnPropertyChanged(nameof(IcuIdSelected));
            }
        }

        public PatientModel PatientsOfSelectedIcu
        {
            get => _allPatientListInIcu;
            set
            {
                _allPatientListInIcu = value;
                OnPropertyChanged(nameof(PatientsOfSelectedIcu));
            }
        }

        //public string 

       // public List<PatientModel> PatientList => _accessing.Patients;
        public List<IcuModel> IcuList => _accessing.Icu;

        public string PatientId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string BedNumber { get; set; }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic
        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PatientsInParticularIcu()
        {
            foreach (var patient in _accessing.IcuWithPatients[IcuIdSelected])
            {
                PatientId = patient.PId;
                Name = patient.Name;
                Gender = patient.Gender;

            }

            

        }

        #endregion

        #region Commands



        #endregion




    }
}
