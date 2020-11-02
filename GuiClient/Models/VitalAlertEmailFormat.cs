namespace GuiClient.Models
{
    // ReSharper disable once ClassNeverInstantiated.Global
    public class VitalAlertEmailFormat
    {
        public VitalAlertEmailFormat(string patientName, string pid,string icuId, int bedId, string status)
        {
            _vitalStatus = status;
            _icuId = icuId;
            _pid = pid;
            PatientName = patientName;
            _bedId = bedId;
            InitBodyOfEmail();
        }
        private void InitBodyOfEmail()
        {
            Body = $"{PatientName}({_pid}) in ICU:{_icuId} in Bed: {_bedId} has vitals within {_vitalStatus} range";
        }

        private string PatientName
        {
            get => _patientName;
            set
            {
                _patientName = value;
                UpdateSubject();
            }
        }
        private void UpdateSubject()
        {
            Subject = $"{_vitalStatus} in {_icuId} for {PatientName}";
        }

        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once NotAccessedField.Global
        public string Subject;
        private readonly string _icuId;
        private readonly int _bedId;
        private readonly string _pid;
        private string _patientName;
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once NotAccessedField.Global
        public string Body;
        private readonly string _vitalStatus;
    }
}
