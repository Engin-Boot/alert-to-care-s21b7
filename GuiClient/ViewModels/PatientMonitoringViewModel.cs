using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using GuiClient.Commands;
using GuiClient.Models;
using GuiClient.ServerWrapper;
// ReSharper disable All

namespace GuiClient.ViewModels
{
    public class PatientDataMonitor
    {
        public string PId { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public int BedId { get; set; }
        public string BedLayout { get; set; }
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
        #region Continuous Update
        public void UpdatePatientData()
        {
            if (IcuIdSelected != null)
                GetPatientsInParticularIcu();
        }
        #endregion

        #region Fields

        private string _selectedIcuId;
        private readonly IcuWrapper _icuWrapper = new IcuWrapper();
        private  readonly  BedsWrapper _bedsWrapper = new BedsWrapper();
        private readonly PatientWrapper _patientWrapper = new PatientWrapper();
        private List<string> _icuList = new List<string>();
       /* private string _patientId;
        private string _name;
        private string _gender;
        private string _bedId;
        private double _bpm;
        private double _spo2;
        private double _respRate;
       */
        private List<PatientModel> _allPatientListInIcu;
        private List<BedModel> _allBedsInIcu;
        private List<PatientVital> _allPatientVitals;
        private List<PatientDataMonitor> _patientDataMonitors;
        private PatientDataMonitor _selectedWarningDataMonitor;
        private PatientDataMonitor _selectedEmergencyDataMonitor;
        public ObservableCollection<PatientDataMonitor> WarningData { get; set; }
        public ObservableCollection<PatientDataMonitor> EmergencyData { get; set; }
        public ObservableCollection<PatientDataMonitor> UndoWarningData { get; set; }
        public ObservableCollection<PatientDataMonitor> UndoEmergencyData { get; set; }

        #endregion

        #region Initializers

        public PatientMonitoringViewModel()
        {

            WarningData = new ObservableCollection<PatientDataMonitor>();
            EmergencyData=new ObservableCollection<PatientDataMonitor>();
            UndoEmergencyData=new ObservableCollection<PatientDataMonitor>();
            UndoWarningData=new ObservableCollection<PatientDataMonitor>();
            
            this.SuppressEmergencyCommand= new DelegateCommandClass(
                SuppressEmergencyCommandWrapper,
                CanExecuteWrapper);

            this.UndoEmergencyCommand= new DelegateCommandClass(
                UndoEmergencyCommandWrapper,
                CanExecuteWrapper);

            this.SuppressWarningCommand= new DelegateCommandClass(
                SuppressWarningCommandWrapper,
                CanExecuteWrapper);

            this.UndoWarningCommand = new DelegateCommandClass(
                UndoWarningCommandWrapper,
                CanExecuteWrapper);

            this.RefreshPatientCommand = new DelegateCommandClass(
                RefreshPatientCommandWrapper,
                CanExecuteWrapper);

           
                IcuList = _icuWrapper.GetAllIcu();

        }

        

        #endregion

        #region Properties

        
        public PatientDataMonitor SelectedWarningDataMonitorForSuppress
        {
            get => _selectedWarningDataMonitor;
            set
            {
                _selectedWarningDataMonitor = value;
                OnPropertyChanged(nameof(SelectedWarningDataMonitorForSuppress));
            }
        }
        public PatientDataMonitor SelectedEmergencyDataMonitorForSuppress
        {
            get => _selectedEmergencyDataMonitor;
            set
            {
                _selectedEmergencyDataMonitor = value;
                OnPropertyChanged(nameof(SelectedEmergencyDataMonitorForSuppress));
            }
        }

        public string IcuIdSelected
        {
            get => _selectedIcuId;
            set
            {
                _selectedIcuId = value;
                OnPropertyChanged(nameof(IcuIdSelected));
                GetPatientsInParticularIcu();
                // Wrapper2();
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


     public List<PatientModel> PatientsInParticularIcu
     {
         get => _allPatientListInIcu;
         set
         {
             _allPatientListInIcu = value;
             OnPropertyChanged(nameof(PatientsInParticularIcu));
             GetAllPatientVitals();
         }
     }


     public List<PatientVital> AllPatientVitals
     {
         get => _allPatientVitals;
         set
         {
             _allPatientVitals = value;
             OnPropertyChanged(nameof(AllPatientVitals));
             GetBedsInParticularIcu();
         }
     }

     public List<BedModel> BedsInParticularIcu
     {
         get => _allBedsInIcu;
         set
         {
             _allBedsInIcu = value;
             OnPropertyChanged(nameof(BedsInParticularIcu));
             GetPatientDataToMonitor();
             StatusSet();
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


        public void GetPatientsInParticularIcu()
        {
            EmergencyData.Clear();
            WarningData.Clear();
            var patientMonitoringList = _patientWrapper.GetPatientsFromIcu(IcuIdSelected).Values.ToList();
            if (patientMonitoringList != null)
            {
                PatientsInParticularIcu = patientMonitoringList;
            }
        }

        public void GetBedsInParticularIcu()
        {
            BedsInParticularIcu = _bedsWrapper.GetListOfBedsForIcu(IcuIdSelected);
        }

        public void GetAllPatientVitals()
        {
            AllPatientVitals = _patientWrapper.GetPatientVitals().Values.ToList();
        }

        public void GetPatientDataToMonitor()
        {
            if (PatientsInParticularIcu == null || AllPatientVitals == null) return;
            var theDataGridList = from patientData in PatientsInParticularIcu // outer sequence
                join vital in AllPatientVitals on patientData.PId equals vital.PId // key selector 
                join beds in BedsInParticularIcu on patientData.BedId equals beds.BedId
                select new PatientDataMonitor()
                { // result selector 
                    PId = patientData.PId,
                    BedId = patientData.BedId,
                    BedLayout = beds.BedLayout,
                    Gender = patientData.Gender,
                    Name = patientData.Name,
                    VitalBpm = vital.VitalBpm,
                    VitalSpo2 = vital.VitalSpo2,
                    VitalRespRate = vital.VitalRespRate,
                    RespRateBackGround = new SolidColorBrush(Colors.White),
                    Spo2BackGround = new SolidColorBrush(Colors.White),
                    BpmBackGround = new SolidColorBrush(Colors.White),
                    Status = new SolidColorBrush(Colors.Green)
                };
            PatientDataMonitors = theDataGridList.ToList();
        }

        public void StatusSet()
        {
            var dictionaryIntColor = new Dictionary<int, SolidColorBrush>
            {
                {0, new SolidColorBrush(Colors.Green)},
                {1, new SolidColorBrush(Colors.Yellow)},
                {2, new SolidColorBrush(Colors.Red)}
            };

            foreach (var data in PatientDataMonitors)
            {
               var bpmStatus = CheckBpm(data);
               var spo2Status = CheckSpo2(data);
                var respStatus = CheckRespRate(data);

                var listOfStatus = new List<int>() {bpmStatus, spo2Status, respStatus};

                var highest = listOfStatus.Max();
                data.Status = dictionaryIntColor[highest];
                
                if (highest == 1)
                {
                    WarningData.Add(data);
                    //var email = new VitalAlertEmailFormat(data.Name, data.PId, IcuIdSelected, data.BedId, "Warning");
                    //var emailAlertWrapper = new EmailAleterWrapper();
                    //emailAlertWrapper.SendEmailAlert(email);
                }
                if (highest == 2)
                {
                    EmergencyData.Add(data);
                    //var email = new VitalAlertEmailFormat(data.Name, data.PId, IcuIdSelected, data.BedId, "Emergency");
                    //var emailAlertWrapper = new EmailAleterWrapper();
                    //emailAlertWrapper.SendEmailAlert(email);
                }
            }

        }

        public int CheckBpm(PatientDataMonitor data)
        {
            if (IsEmergency(data.VitalBpm, 161, 59))
            {
                data.BpmBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                data.Status = new SolidColorBrush(Colors.Red);
                //EmergencyData.Add(data);
                return 2;
            }
            else
            {
                if (IsWarning(data.VitalBpm, 151, 69))
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
            if (data.VitalSpo2 < 90)
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
            if (IsEmergency(data.VitalRespRate, 101, 24))
            {
                data.RespRateBackGround = new SolidColorBrush(Colors.LightGoldenrodYellow);
                data.Status = new SolidColorBrush(Colors.Red);
                //EmergencyData.Add(data);
                return 2;
            }
            else
            {
                if (IsWarning(data.VitalRespRate, 96, 29))
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

        public void RemoveFromObservableAndAddToUndo(PatientDataMonitor data,ObservableCollection<PatientDataMonitor> removeFrom ,
            ObservableCollection<PatientDataMonitor>addTo)
        {
            foreach (var entry in removeFrom)
            {
                if (!entry.Equals(data)) continue;
                removeFrom.Remove(data);
                addTo.Add(data);
                break;
            }
        }

        public void RemoveLastFromUndoObservableAndAddBackToOriginal(
            ObservableCollection<PatientDataMonitor> removeLastFrom,
            ObservableCollection<PatientDataMonitor> addTo)
        {
            if (removeLastFrom.Count==0)
                MessageBox.Show("Nothing To Undo.");
            else
            {
                var lastData = removeLastFrom.Last();
                removeLastFrom.Remove(lastData);
                addTo.Add(lastData);
                MessageBox.Show($"Undo successful. PID : {lastData.PId} , Name : {lastData.Name}");
            }
        }
        #endregion

        #region Commands

        public ICommand SuppressEmergencyCommand
        {
            get;
            set;
        }
        public ICommand UndoEmergencyCommand
        {
            get;
            set;
        }
        public ICommand SuppressWarningCommand
        {
            get;
            set;
        }
        public ICommand UndoWarningCommand
        {
            get;
            set;
        }

        public ICommand RefreshPatientCommand
        {
            get;
            set;
        }
        #endregion

        #region helper command wrappers

        public void SuppressWarningCommandWrapper(object parameter)
        {
            if (SelectedWarningDataMonitorForSuppress != null)
            {
                RemoveFromObservableAndAddToUndo(SelectedWarningDataMonitorForSuppress,
                    WarningData, UndoWarningData);
                SelectedWarningDataMonitorForSuppress = null;
            }
            else
            {
                MessageBox.Show("Nothing is Selected to Suppress.");
            }
        }
        public void SuppressEmergencyCommandWrapper(object parameter)
        {
            if (SelectedEmergencyDataMonitorForSuppress != null)
            {
                RemoveFromObservableAndAddToUndo(SelectedEmergencyDataMonitorForSuppress,
                    EmergencyData, UndoEmergencyData);
                SelectedEmergencyDataMonitorForSuppress = null;
            }
            else
            {
                MessageBox.Show("Nothing is Selected to Suppress.");
            }
        }

        public void UndoEmergencyCommandWrapper(object parameter)
        {

            RemoveLastFromUndoObservableAndAddBackToOriginal(
                UndoEmergencyData, EmergencyData);

        }
        public void UndoWarningCommandWrapper(object parameter)
        {

            RemoveLastFromUndoObservableAndAddBackToOriginal(
                UndoWarningData, WarningData);

        }

        private void RefreshPatientCommandWrapper(object obj)
        {
            IcuList = _icuWrapper.GetAllIcu();
        }

        public bool CanExecuteWrapper(object parameter)
        {
            return true;
        }

        #endregion


    }
}
