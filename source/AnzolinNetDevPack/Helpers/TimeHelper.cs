using System;
using System.Linq;

namespace AnzolinNetDevPack.Helpers
{
    public static class TimeHelper
    {
        public enum Type
        {
            Milliseconds = 0,
            Seconds = 1,
            Minutes = 2,
            Hours = 3,
            Days = 4
        }
        
        /// <summary>
        /// Converte uma string no formato "hh:mm:ss" para o tipo informado pelo parâmetro "returnType"
        /// </summary>
        /// <param name="time"></param>
        /// <param name="returnType"></param>
        /// <returns></returns>
        public static double ConvertTime(string time, Type returnType)
        {
            double returnTime = 0;

            try
            {
                var timeArr = GetTimeAsArray(time);

                if (timeArr != null && timeArr.Length != 3)
                    return 0;

                var tsTime = new TimeSpan(timeArr[0], timeArr[1], timeArr[2]);

                switch (returnType)
                {
                    case Type.Milliseconds:
                        returnTime = tsTime.TotalMilliseconds;
                        break;

                    case Type.Seconds:
                        returnTime = tsTime.TotalSeconds;
                        break;

                    case Type.Minutes:
                        returnTime = tsTime.TotalMinutes;
                        break;

                    case Type.Hours:
                        returnTime = tsTime.TotalHours;
                        break;

                    case Type.Days:
                        returnTime = tsTime.TotalDays;
                        break;
                }

                return returnTime;
            }
            catch
            {
                return 0;
            }
        }

        /// <summary>
        /// Converte uma string no formato "hh:mm:ss" para um DateTime contendo a hora, em que o "dia", "mes" e "ano" são de um "DateTime.MinValue".
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static DateTime? ConvertTime(string time)
        {
            try
            {
                var timeArr = GetTimeAsArray(time);

                if (timeArr != null && timeArr.Length != 3)
                    return null;

                if (timeArr != null && timeArr.Length == 3)
                    return new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, timeArr[0], timeArr[1], timeArr[2]);
                
                return null;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtêm uma hora no formato "hh:mm:ss" à partir tempo e tipo de tempo informados.
        /// </summary>
        /// <param name="time"></param>
        /// <param name="fromType"></param>
        /// <returns></returns>
        public static string GetTimeAsString(double time, Type fromType)
        {
            try
            {
                var tsTime = new TimeSpan();

                switch (fromType)
                {
                    case Type.Milliseconds:
                        tsTime = TimeSpan.FromMilliseconds(time);
                        break;

                    case Type.Seconds:
                        tsTime = TimeSpan.FromSeconds(time);
                        break;

                    case Type.Minutes:
                        tsTime = TimeSpan.FromMinutes(time);
                        break;

                    case Type.Hours:
                        tsTime = TimeSpan.FromHours(time);
                        break;

                    case Type.Days:
                        tsTime = TimeSpan.FromDays(time);
                        break;
                }

                var totalhours = (int)tsTime.TotalHours;

                return totalhours.ToString().PadLeft(2, '0') + ":" + tsTime.Minutes.ToString().PadLeft(2, '0') + ":" + tsTime.Seconds.ToString().PadLeft(2, '0');
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// Obtêm uma hora como um array de 3 posições representando horas, minutos e segundos respectivamente, à partir tempo informado. Caso ocorra algum erro retorna nulo.
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        public static int[] GetTimeAsArray(string time)
        {
            try
            {
                return time?.Split(':').Select(x => int.Parse(x)).ToArray();
            }
            catch
            {
                return null;
            }
        }


        /// <summary>
        /// Retorna somente a informação de hora, minuto e segundo de uma data completa.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTimeOffset GetTime(DateTimeOffset data)
        {
            return new DateTimeOffset(DateTimeOffset.MinValue.Year, DateTimeOffset.MinValue.Month, DateTimeOffset.MinValue.Day, data.Hour, data.Minute, data.Second, data.Offset);
        }

        /// <summary>
        /// Retorna somente a informação de hora, minuto e segundo de uma data completa.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTime GetTime(DateTime data)
        {
            return new DateTime(DateTime.MinValue.Year, DateTime.MinValue.Month, DateTime.MinValue.Day, data.Hour, data.Minute, data.Second);
        }

        /// <summary>
        /// Retorna a data e hora completa, sendo o tempo absoluto.
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        public static DateTimeOffset Truncate(DateTimeOffset data)
        {
            return new DateTimeOffset(data.Year, data.Month, data.Day, data.Hour, data.Minute, data.Second, data.Offset);
        }
    }
}
