using System;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// this class can be used to calculate execution time of methods and
    /// other operations.
    /// </summary>
    class Benchmark
    {
        // these variables are used as a start and end point for the timer
        //
        private static DateTime startDate = DateTime.MinValue;
        private static DateTime endDate = DateTime.MinValue;

        // variable used to calculate the difference between the start and end time
        //
        public static TimeSpan Span { get { return endDate.Subtract(startDate); } }

        /// <summary>
        /// method used to start the timer
        /// </summary>
        public static void Start() { startDate = DateTime.Now; }

        /// <summary>
        /// method used to end the timer
        /// </summary>
        public static void End() { endDate = DateTime.Now; }

        /// <summary>
        /// method used to get the total runtime of the timer
        /// </summary>
        /// <returns></returns>
        public static double GetSeconds()
        {
            if (endDate == DateTime.MinValue) return 0.0;
            else return Span.TotalSeconds;
        }
    }
}
