﻿using GuiClient.ViewModels;

namespace GuiClient.Views
{
    /// <summary>
    /// Interaction logic for BedRegistrationForm.xaml
    /// </summary>
    
    public partial class BedRegistrationForm
    {
        // ReSharper disable once MemberCanBePrivate.Global
        public BedRegistrationViewModel BedRegistrationVm = new BedRegistrationViewModel();
        public BedRegistrationForm()
        {
            InitializeComponent();
            DataContext = BedRegistrationVm;
        }

    }
}
