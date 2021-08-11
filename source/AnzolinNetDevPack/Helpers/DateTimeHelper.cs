using System;
using TimeZoneConverter;

namespace AnzolinNetDevPack.Helpers
{
    public static class DateTimeHelper
    {
        /// <summary>
        /// Retorna a data/hora de agora de Brasília ("America/Sao_Paulo").
        /// </summary>
        /// <returns></returns>
        public static DateTime GetDateTimeBrasilia() => TimeZoneInfo.ConvertTime(DateTime.UtcNow, TZConvert.GetTimeZoneInfo("America/Sao_Paulo"));

        /// <summary>
        /// Retorna a data/hora de agora de acordo com o timezone informado, exemplo: "America/Sao_Paulo".
        /// </summary>
        /// <param name="windowsOrIanaTimeZoneId"></param>
        /// <returns></returns>
        public static DateTime GetDateTimeByTimeZone(string windowsOrIanaTimeZoneId)
        {
            return TimeZoneInfo.ConvertTime(DateTime.UtcNow, TZConvert.GetTimeZoneInfo(windowsOrIanaTimeZoneId));
        }
    }
}
