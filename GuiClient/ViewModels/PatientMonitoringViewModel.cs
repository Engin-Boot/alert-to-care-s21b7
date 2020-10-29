using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using GuiClient.Models;
using GuiClient.ServerWrapper;

namespace GuiClient.ViewModels
{
    public class PatientDataMonitor
    {
        public string PId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int BedId { get; set; }
        public double VitalBpm { get; set; }
        public double VitalSpo2 { get; set; }
        public double VitalRespRate { get; set; }
        public string Status { get; set; }
    }
    public class PatientMonitoringViewModel :INotifyPropertyChanged
    {
        #region trying something
        
        

        #endregion





        private PatientModel _allPatientListInIcu;
        #region Fields

        private string _selectedIcuId;
        private readonly IcuWrapper _icuWrapper = new IcuWrapper();
        private readonly PatientWrapper _patientWrapper = new PatientWrapper();
        //private GuiClient.ServerWrapper.PatientVitalsWrapper _patientVitalsWrapper = new PatientVitalsWrapper();
        private List<string> _icuList = new List<string>();
        private string _patientId;
        private string _name;
        private string _gender;
        private string _bedId;
        private double _bpm;
        private double _spo2;
        private double _respRate;
        private List<PatientDataMonitor> _patientDataMonitors;

        #endregion

        #region Initializers

        public PatientMonitoringViewModel()
        {
            IcuList = _icuWrapper.GetAllIcu();
        }

        #endregion

        #region Properties

        public string IcuIdSelected
        {
            get => _selectedIcuId;
            set
            {
                _selectedIcuId = value;
                OnPropertyChanged(nameof(IcuIdSelected));
                PatientsInParticularIcu();
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
        public List<string> IcuList
       {
           get => _icuList;
           set
           {
               _icuList = value;
               OnPropertyChanged(nameof(IcuList));
           }
       }

        public string PatientId
        {
            get => _patientId;
            set
            {
                _patientId = value;
                OnPropertyChanged(nameof(PatientId));
            }
        }

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
        }
        public string Gender
        {
            get => _gender;
            set
            {
                _gender = value;
                OnPropertyChanged(nameof(Gender));
            }
        }

        public string BedNumber
        {
            get => _bedId;
            set
            {
                _bedId = value;
                OnPropertyChanged(nameof(BedNumber));
            }
        }

        public double Bpm
        {
            get => _bpm;
            set
            {
                _bpm = value;
                OnPropertyChanged(nameof(Bpm));
            }
        }
        public double Spo2
        {
            get => _spo2;
            set
            {
                _spo2 = value;
                OnPropertyChanged(nameof(Spo2));
            }
        }
        public double RespRate
        {
            get => _respRate;
            set
            {
                _respRate = value;
                OnPropertyChanged(nameof(RespRate));
            }
        }

        public List<PatientDataMonitor> PatientDataMonitors
        {
            get => _patientDataMonitors;
            set
            {
                _patientDataMonitors = value;
                OnPropertyChanged(nameof(PatientDataMonitors));
            }
        }

        #endregion

        #region Event

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Logic
        
        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void PatientsInParticularIcu()
        {
            var dictOfAllPatients = _patientWrapper.GetPatientsFromIcu(IcuIdSelected);
            var vitals = _patientWrapper.GetPatientVitals();
            if (dictOfAllPatients == null || vitals == null) return;
            var theDataGridList = from data in dictOfAllPatients // outer sequence
                join vital in vitals //inner sequence 
                    on data.Value.PId equals vital.Value.PId // key selector 
                select new PatientDataMonitor()
                { // result selector 
                    PId = data.Value.PId,
                    BedId = data.Value.BedId,
                    Gender = data.Value.Gender,
                    Name = data.Value.Name,
                    VitalBpm = vital.Value.VitalBpm,
                    VitalSpo2 = vital.Value.VitalSpo2,
                    VitalRespRate = vital.Value.VitalRespRate,
                    Status = ""
                };
            PatientDataMonitors = theDataGridList.ToList();
        }

        #endregion

        #region Commands



        #endregion




    }
}
