using Hangfire;
using Hangfire.MySql;
using Hangfire.Storage.Monitoring;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace AnzolinNetDevPack.Helpers
{
    public static class HangfireForMySqlHelper
    {
        public static MySqlStorage Storage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="methodCall"></param>
        /// <returns></returns>
        public static Task Enqueue(Expression<Action> methodCall)
        {
            var client = new BackgroundJobClient(Storage);

            JobStorage.Current = Storage;

            var jobId = client.Enqueue(methodCall);

            var checkJobState = Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    var monitoringApi = JobStorage.Current.GetMonitoringApi();
                    var jobDetails = monitoringApi.JobDetails(jobId);
                    var currentState = jobDetails.History[0].StateName;

                    if (currentState != "Enqueued" && currentState != "Processing")
                        break;
                }
            });

            return checkJobState;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static JobDetailsDto GetJobDetails(MySqlStorage storage, string jobId)
        {
            JobStorage.Current = storage;

            var api = JobStorage.Current.GetMonitoringApi();
            var jobResult = api.JobDetails(jobId);
            var jobSucceeded = api.SucceededJobs(0, int.MaxValue).FirstOrDefault(q => q.Key == jobId).Value;

            return jobResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="storage"></param>
        /// <param name="jobId"></param>
        /// <returns></returns>
        public static object GetJobResult(MySqlStorage storage, string jobId)
        {
            JobStorage.Current = storage;

            var api = JobStorage.Current.GetMonitoringApi();
            var jobSucceeded = api.SucceededJobs(0, int.MaxValue).FirstOrDefault(q => q.Key == jobId).Value;

            return jobSucceeded.Result;
        }
    }
}
