
namespace PowerTradesReport
{
    public class ReportLineItem
    {
        private string[] localTime = new string[] { 
            "23:00", "00:00", "01:00", "02:00", "03:00", "04:00", "05:00", 
            "06:00", "07:00", "08:00", "09:00", "10:00", "11:00",
            "12:00", "13:00", "14:00", "15:00", "16:00", "17:00",
            "18:00", "19:00", "20:00", "21:00", "22:00"
        };
        public ReportLineItem(int period, double volume) 
        {
            Volume = volume;
            LocalTime = localTime[period-1];
        }
        public string LocalTime { get; protected set; }
        public double Volume { get; protected set; }

        public override string ToString()
        {
            return $"{LocalTime},{Volume}";
        }
    }
}
