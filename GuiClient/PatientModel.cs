namespace GuiClient
{
    public class PatientModel
    {
        public string PId { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        //public double VitalBpm { get;  set; }
        //public double VitalSpo2 { get;  set; }
        //public double VitalRespRate { get;  set; }
        public string IcuId { get; set; }
        public int BedId { get; set; }
    }
}
