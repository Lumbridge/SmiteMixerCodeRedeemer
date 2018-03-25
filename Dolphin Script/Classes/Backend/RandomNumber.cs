using System;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// This class can be used to generate random numbers quickly and easily.
    /// </summary>
    class RandomNumber
    {
        // the random object remains private because we don't need external access to it
        //
        private static readonly Random getrandom = new Random();
        
        // we create this lock object to use in the class methods
        //
        private static readonly object syncLock = new object();

        /// <summary>
        /// This method returns a random integer inside the range passed in.
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomNumber(int min, int max)
        {
            // we lock this method so that we ensure that the method only returns the same number once
            // and that a unique number is returned every time the method is called
            //
            lock (syncLock)
            {
                // return the random number using the private random object
                //
                return getrandom.Next(min, max + 1);
            }
        }

        /// <summary>
        /// This method returns a random double inside the range passed in.
        /// </summary>
        /// <param name="minimum"></param>
        /// <param name="maximum"></param>
        /// <returns></returns>
        public static double GetRandomDouble(double minimum, double maximum)
        {
            // we lock this method so that we ensure that the method only returns the same number once
            // and that a unique number is returned every time the method is called
            //
            lock (syncLock)
            {
                // return the random number using the private random object
                //
                return getrandom.NextDouble() * (maximum - minimum) + minimum;
            }
        }
    }
}
