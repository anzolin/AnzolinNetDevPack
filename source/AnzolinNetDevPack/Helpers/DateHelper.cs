using System;

namespace AnzolinNetDevPack.Helpers
{
    public static class DateHelper
    {
        public enum IntervalType
        {
            Day,
            Month,
            Year
        }

        /// <summary>
        /// Retorna entre datas de acordo com o tipo de intervalo escolhido.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="fromDate"></param>
        /// <param name="toDate"></param>
        /// <returns></returns>
        public static int DateDiff(IntervalType type, DateTime fromDate, DateTime toDate)
        {
            var duration = toDate - fromDate;

            switch (type)
            {
                case IntervalType.Day:
                    return duration.Days;

                case IntervalType.Month:
                    double floatValue = 12 * (fromDate.Year - toDate.Year) + fromDate.Month - toDate.Month;

                    return Convert.ToInt32(Math.Abs(floatValue));

                case IntervalType.Year:
                    return Convert.ToInt32(duration.Days / 365);

                default:
                    return 0;
            }
        }
    }
}
