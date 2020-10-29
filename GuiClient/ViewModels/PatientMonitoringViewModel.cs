using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using GuiClient.Commands;
using GuiClient.Models;
using GuiClient.ServerWrapper;
using Microsoft.EntityFrameworkCore.ChangeTracking;

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
        public SolidColorBrush Status { get; set; }
        public SolidColorBrush BpmBackGround { get; set; }
        public SolidColorBrush Spo2BackGround { get; set; }
        public SolidColorBrush RespRateBackGround { get; set; }
    }
    public class PatientMonitoringViewModel :INotifyPropertyChanged
    {
        #region trying something

        public ObservableHashSet<PatientDataMonitor> WarningData { get; set; }

        public ObservableHashSet<PatientDataMonitor> EmergencyData { get; set; }

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
            WarningData = new ObservableHashSet<PatientDataMonitor>();
            EmergencyData=new ObservableHashSet<PatientDataMonitor>();
            //this.SuppressCommand = new DelegateCommandClass(
            //    new Action<object>(this.SuppressCommandWrapper),
            //    new Func<object, bool>(this.CanExecuteWrapper));
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
                StatusSet();
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
                    RespRateBackGround = new SolidColorBrush(Colors.White),
                    Spo2BackGround = new SolidColorBrush(Colors.White),
                    BpmBackGround = new SolidColorBrush(Colors.White),
                    Status = new SolidColorBrush(Colors.Green)
                };
            PatientDataMonitors = theDataGridList.ToList();
        }



        public void StatusSet()
        {
            var dictionaryIntColor = new Dictionary<int, SolidColorBrush>();
            dictionaryIntColor.Add(1,new SolidColorBrush(Colors.Yellow));
            dictionaryIntColor.Add(2,new SolidColorBrush(Colors.Red));

            foreach (var data in PatientDataMonitors)
            {
               var bpmStatus = CheckBpm(data);
               var spo2Status = CheckSpo2(data);
                var respStatus = CheckRespRate(data);

                var listOfStatus = new List<int>() {bpmStatus, spo2Status, respStatus};

                var highest = listOfStatus.Max();
                data.Status = dictionaryIntColor[highest];
                if (highest == 1)
                    WarningData.Add(data);
                if (highest == 2)
                    EmergencyData.Add(data);
            }

        }

        


        public int CheckBpm(PatientDataMonitor data)
        {
            if (IsEmergency(data.VitalBpm, 120, 30))
            {
                data.BpmBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                data.Status = new SolidColorBrush(Colors.Red);
                //EmergencyData.Add(data);
                return 2;
            }
            else
            {
                if (IsWarning(data.VitalBpm, 101, 39))
                {
                    data.BpmBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    data.Status = new SolidColorBrush(Colors.Yellow);
                    //WarningData.Add(data);
                    return 1;
                }

                return 0;
            }
            
            
            
        }

        public int CheckSpo2(PatientDataMonitor data)
        {
            if (data.VitalSpo2 < 85)
            {
                data.Status = new SolidColorBrush(Colors.Red);
                data.Spo2BackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                //EmergencyData.Add(data);
                return 2;
            }
            else
            {
                if (!(data.VitalSpo2 < 95)) return 0;
                data.Status = new SolidColorBrush(Colors.Yellow);
                data.Spo2BackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
               // WarningData.Add(data);
               return 1;
            }
        }

        public int CheckRespRate(PatientDataMonitor data)
        {
            if (IsEmergency(data.VitalRespRate, 20, 9))
            {
                data.RespRateBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                data.Status = new SolidColorBrush(Colors.Red);
                //EmergencyData.Add(data);
                return 2;
            }
            else
            {
                if (IsWarning(data.VitalRespRate, 17, 11))
                {
                    data.RespRateBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                    data.Status = new SolidColorBrush(Colors.Yellow);
                   // WarningData.Add(data);
                    return 1;
                }

                return 0;
            }
            
            
            // ReSharper disable once InvertIf
            
            
        }

        public bool IsWarning(double reading, double upper, double lower)
        {
            return reading >= upper || reading <= lower;
        }

        public bool IsEmergency(double reading, double upper, double lower)
        {
            return reading >= upper || reading <= lower;
        }

        #endregion

        // #region Commands

        //public ICommand SuppressCommand
        //{
        //    get;
        //    set;
        //}

        //#endregion

        //public void SuppressCommandWrapper(object parameter)
        //{
        //    var obj = (PatientDataMonitor)parameter;
        //}

        //public bool CanExecuteWrapper(object parameter)
        //{
        //    return true;
        //}

    }
}
