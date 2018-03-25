using System;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

using static DolphinScript.Lib.Backend.Common;
using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.PointReturns;
using static DolphinScript.Lib.Backend.RandomNumber;
using static DolphinScript.Lib.Backend.MouseMoveMath;

namespace DolphinScript.Lib.ScriptEventClasses
{
    /// <summary>
    /// This class provides the core mouse moving functionality.
    /// </summary>
    [Serializable]
    class MouseMove : ScriptEvent
    {
        // mouse movement variables
        //
        private static double
            _Gravity = 9.0,
            _PushForce = 3.0,
            _MinWait = 10.0,
            _MaxWait = 15.0,
            _MaxStep = 10.0,
            _TargetArea = 15.0;

        /// <summary>
        /// moves the mouse from it's current location to the end point passed in
        /// </summary>
        /// <param name="end"></param>
        public static void MoveMouse(POINT end)
        {
            // store the current mouse position to pass into the core mouse move loop
            //
            POINT start = GetCursorPosition();

            // generate a random mouse speed close to the one set on the form
            //
            double randomSpeed = Math.Max((GetRandomNumber(0, MouseSpeed) / 2.0 + MouseSpeed) / 10.0, 0.1);

            // call the main mouse move loop and pass in the global params
            //
            MouseMoveCoreLoop(
                start,
                end,
                _Gravity,
                _PushForce,
                _MinWait / randomSpeed,
                _MaxWait / randomSpeed,
                _MaxStep * randomSpeed,
                _TargetArea * randomSpeed);
        }

        /// <summary>
        /// this function is the core mouse moving method, needs to be cleaned up...
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        /// <param name="gravity"></param>
        /// <param name="pushForce"></param>
        /// <param name="minWait"></param>
        /// <param name="maxWait"></param>
        /// <param name="maxStep"></param>
        /// <param name="targetArea"></param>
        public static void MouseMoveCoreLoop(
            POINT start,
            POINT end,
            double gravity,
            double pushForce,
            double minWait, double maxWait,
            double maxStep, double targetArea)
        {
            double xs = start.X, ys = start.Y;
            double xe = end.X, ye = end.Y;

            double dist, windX = 0, windY = 0, veloX = 0, veloY = 0, randomDist, veloMag, step;
            int oldX, oldY, newX = (int)Math.Round(xs), newY = (int)Math.Round(ys);

            double waitDiff = maxWait - minWait;
            double sqrt2 = Math.Sqrt(2.0);
            double sqrt3 = Math.Sqrt(3.0);
            double sqrt5 = Math.Sqrt(5.0);

            dist = Hypot(xe - xs, ye - ys);

            while (dist > 1.0)
            {
                pushForce = Math.Min(pushForce, dist);

                if (dist >= targetArea)
                {
                    int w = GetRandomNumber(0,(int)Math.Round(pushForce) * 2 + 1);
                    windX = windX / sqrt3 + (w - pushForce) / sqrt5;
                    windY = windY / sqrt3 + (w - pushForce) / sqrt5;
                }
                else
                {
                    windX = windX / sqrt2;
                    windY = windY / sqrt2;
                    if (maxStep < 3)
                        maxStep = GetRandomNumber(0,3) + 3.0;
                    else
                        maxStep = maxStep / sqrt5;
                }

                veloX += windX;
                veloY += windY;
                veloX = veloX + gravity * (xe - xs) / dist;
                veloY = veloY + gravity * (ye - ys) / dist;

                if (Hypot(veloX, veloY) > maxStep)
                {
                    randomDist = maxStep / 2.0 + GetRandomNumber(0,(int)Math.Round(maxStep) / 2);
                    veloMag = Hypot(veloX, veloY);
                    veloX = (veloX / veloMag) * randomDist;
                    veloY = (veloY / veloMag) * randomDist;
                }

                oldX = (int)Math.Round(xs);
                oldY = (int)Math.Round(ys);
                xs += veloX;
                ys += veloY;
                dist = Hypot(xe - xs, ye - ys);
                newX = (int)Math.Round(xs);
                newY = (int)Math.Round(ys);

                if (oldX != newX || oldY != newY)
                    SetCursorPos(newX, newY);

                step = Hypot(xs - oldX, ys - oldY);
                int wait = (int)Math.Round(waitDiff * (step / maxStep) + minWait);

                Task.WaitAll(Task.Delay(wait));
            }

            int endX = (int)Math.Round(xe);
            int endY = (int)Math.Round(ye);

            if (!IsRunning)
                return;
            else if (endX != newX || endY != newY)
                SetCursorPos(endX, endY);
        }

        /// <summary>
        /// main overriden method used to perform this script event
        /// </summary>
        public override void DoEvent()
        {
            // update the status label on the main form
            //
            Status = $"Mouse move: {CoordsToMoveTo.ToString()}.";

            MoveMouse(CoordsToMoveTo);
        }

        /// <summary>
        /// returns a string which is added to the listbox to give information about the event which was added to the event list
        /// </summary>
        /// <returns></returns>
        public override string GetEventListBoxString()
        {
            if (GroupID == -1)
                return "Move mouse to Point X: " + CoordsToMoveTo.X + " Y: " + CoordsToMoveTo.Y + ".";
            else
                return "[Group " + GroupID + " Repeat x" + NumberOfCycles + "] Move mouse to Point X: " + CoordsToMoveTo.X + " Y: " + CoordsToMoveTo.Y + ".";
        }

        /// <summary>
        /// Imported method which allows us to set the position of the mouse cursor.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        [DllImport("User32.Dll")]
        public static extern long SetCursorPos(int x, int y);
    }
}