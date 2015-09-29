namespace MissingFeatures
{
    using System;
    using System.Threading.Tasks;

    public static class Code
    {
        // http://stackoverflow.com/questions/7413612/how-to-limit-the-execution-time-of-a-function-in-c-sharp/10544579#10544579
        public static bool ExecuteWithTimeLimit(TimeSpan timeSpan, Action codeBlock)
        {
            try
            {
                var task = Task.Factory.StartNew(codeBlock);
                task.Wait(timeSpan);
                return task.IsCompleted;
            }
            catch (AggregateException ae)
            {
                throw ae.InnerExceptions[0];
            }
        }
    }
}
