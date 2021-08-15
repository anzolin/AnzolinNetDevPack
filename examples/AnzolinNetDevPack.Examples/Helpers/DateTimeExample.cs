using AnzolinNetDevPack.Helpers;

namespace AnzolinNetDevPack.Examples.Helpers
{
    public class DateTimeExample
    {
        public void Main()
        {
            var dateAndTimeOfBrasilia = DateTimeHelper.GetDateTimeBrasilia();

            var dateAndTimeOfCentralStandardTime = DateTimeHelper.GetDateTimeByTimeZone("Central Standard Time");

            var dateAndTimeOfAmericaNewYork = DateTimeHelper.GetDateTimeByTimeZone("America/New_York");
        }
    }
}
