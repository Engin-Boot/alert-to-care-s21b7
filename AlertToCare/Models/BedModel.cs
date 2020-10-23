namespace AlertToCare.Models
{
    public class BedModel
    {
        public BedModel()
        {
            BedId = 0;
            IcuId = "Dummy";
            BedLayout = "Dummy";
            BedStatus = "Dummy";
            BedNumber = "Dummy";

        }
        public int BedId { get; set; }
        public string IcuId { get; set; }
        public string BedLayout { get; set; }
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public string BedStatus { get; set; }
        public string BedNumber { get; set; }
    }
}
