﻿using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Input;
using GuiClient.Commands;
using GuiClient.ServerWrapper;
// ReSharper disable All
namespace GuiClient.ViewModels
{
    public sealed class PatientDischargeViewModel: INotifyPropertyChanged
    {
        #region Ctor
        public PatientDischargeViewModel()
        {
            DischargePatientCommand = new RelayCommand(DischargePatient);
            RefreshCommand = new RelayCommand(RefreshView);
            InitView();
        }
        private void InitView()
        {
            var patients = new PatientWrapper().GetAllPatients();
            AllPatients = patients.Keys.ToList();
        }
        #endregion

        #region Logic
        private void RefreshView(object obj)
        {
            InitView();
        }
        private void DischargePatient(object obj)
        {
            var wrapperObj = new PatientWrapper();
            if (wrapperObj.DischargePatient(SelectedPatient) == 1)
            {
                AllPatients = new PatientWrapper().GetAllPatients().Keys.ToList();
                MessageBox.Show("Patient successfully discharged");
            }
            else
            {
                MessageBox.Show("Unable to delete ICU as there are beds in the ICU.");
            }

            
        }
        #endregion

        #region Properties
        public string SelectedPatient
        {
            get => _selectedPatient;
            set
            {
                _selectedPatient = value;
                OnPropertyChanged(nameof(SelectedPatient));
            }
        }


        public List<string> AllPatients
        {
            get => _allPatients;
            set
            {
                _allPatients = value;
                OnPropertyChanged(nameof(AllPatients));
            }
        }
        #endregion

        #region Commands
        public ICommand DischargePatientCommand { get; set; }
        public ICommand RefreshCommand { get; set; }
        #endregion

        #region PrivateVariables

        private string _selectedPatient;
        private List<string> _allPatients;

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion

    }
}
