using System;
using System.Drawing;
using System.Collections.Generic;
using System.Runtime.InteropServices;

using static DolphinScript.Lib.Backend.WinAPI;
using static DolphinScript.Lib.Backend.ScreenCapture;
using static DolphinScript.Lib.Backend.PointReturns;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// This class contains methods which have some colour functionality such as getting the colour of a particular pixel.
    /// </summary>
    class ColourEvent
    {
        /// <summary>
        /// gets the pixel colour at a point
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        public static Color GetColorAt(Point position)
        {
            // gets a handle to the screen
            //
            IntPtr desk = GetDesktopWindow();

            // gets a device context for the screen
            //
            IntPtr dc = GetWindowDC(desk);

            // gets an unsigned int pixel at the selected position
            //
            int a = (int)GetPixel(dc, position.X, position.Y);

            // frees the device context memory
            //
            ReleaseDC(desk, dc);

            // returns a colour object of the colour at the pixel position
            //
            return Color.FromArgb(255, (a >> 0) & 0xff, (a >> 8) & 0xff, (a >> 16) & 0xff);
        }

        /// <summary>
        /// method of saving the colour under the mouse cursor when the user presses shift
        /// </summary>
        /// <returns></returns>
        public static Color SaveSearchColour()
        {
            // continuously loop
            //
            while (true)
            {
                // listen for left shift key
                //
                if (GetAsyncKeyState(VirtualKeyStates.VK_LSHIFT) < 0)
                {
                    // return the pixel colour under the cursor position
                    //
                    return GetColorAt(GetCursorPosition());
                }
            }
        }

        /// <summary>
        /// Determines if a colour exists in a given search area
        /// </summary>
        /// <param name="ColourSearchArea"></param>
        /// <param name="SearchColour"></param>
        /// <returns></returns>
        public static bool ColourExistsInArea(RECT ColourSearchArea, int SearchColour)
        {
            // create a bitmap of the search area
            //
            Bitmap b = ScreenshotArea(ColourSearchArea);

            // lock the bitmap memory
            //
            lock (b)
            {
                // create a lockbitmap object
                //
                LockBitmap lockBitmap = new LockBitmap(b);

                try
                {
                    // lock the object data
                    //
                    lockBitmap.LockBits();

                    // loop through all pixels
                    //
                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        for (int x = 0; x < lockBitmap.Width; x++)
                        {
                            // check if the search pixel matches the current pixel we're on
                            //
                            if (lockBitmap.GetPixel(x, y).ToArgb() == SearchColour)
                            {
                                // no need to continue searching
                                //
                                return true;
                            }
                        }
                    }
                }
                finally
                {
                    // unlock the data
                    //
                    lockBitmap.UnlockBits();
                }
            }
            
            // we finished searching all pixels without finding a matching pixel
            //
            return false;
        }

        /// <summary>
        /// Returns a list of matching colour points found in the search area
        /// </summary>
        /// <param name="ColourSearchArea"></param>
        /// <param name="SearchColour"></param>
        /// <returns></returns>
        public static List<POINT> GetMatchingPixelList(RECT ColourSearchArea, int SearchColour)
        {
            // this list will store the list of pixels matching the search colour
            //
            List<POINT> MatchingColourPixels = new List<POINT>();

            // create a bitmap to use in the search process
            //
            Bitmap b = ScreenshotArea(ColourSearchArea);

            // lock the bitmap image memory
            //
            lock (b)
            {
                // create a lockbitmap object to use in the search process
                //
                LockBitmap lockBitmap = new LockBitmap(b);

                try
                {
                    // lock the bitmap memory
                    //
                    lockBitmap.LockBits();

                    // loop through all pixels on the image
                    //
                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        for (int x = 0; x < lockBitmap.Width; x++)
                        {
                            // check if the current pixel matches the search colour
                            //
                            if (lockBitmap.GetPixel(x, y).ToArgb() == SearchColour)
                            {
                                // if it matches then add the pixel to the matching pixels list
                                //
                                MatchingColourPixels.Add(new POINT(ColourSearchArea.Left + x, ColourSearchArea.Top + y));
                            }
                        }
                    }
                }
                finally
                {
                    // when we're done, unlock the memory region
                    //
                    lockBitmap.UnlockBits();
                }
            }

            // return the list of matching pixels we found (if any)
            //
            return MatchingColourPixels;
        }

        /// <summary>
        /// Changes the colour of all matching colour pixels on a given bitmap image
        /// </summary>
        /// <param name="b"></param>
        /// <param name="SearchColour"></param>
        /// <param name="NewColour"></param>
        /// <returns></returns>
        public static Bitmap SetMatchingColourPixels(Bitmap b, int SearchColour, Color NewColour)
        {
            // create a copy of the bitmap image we're going to edit
            //
            Bitmap temp = b;
            
            // lock the bitmap memory region
            //
            lock (temp)
            {
                // create a lockbitmap object
                //
                LockBitmap lockBitmap = new LockBitmap(temp);

                try
                {
                    // lock the image data
                    //
                    lockBitmap.LockBits();

                    // loop through all pixels on the image
                    //
                    for (int y = 0; y < lockBitmap.Height; y++)
                    {
                        for (int x = 0; x < lockBitmap.Width; x++)
                        {
                            // check if the current pixel colour matches the search colour
                            //
                            if (lockBitmap.GetPixel(x, y).ToArgb() == SearchColour)
                            {
                                // change the matching search colour to the colour we want it to be changed to
                                //
                                lockBitmap.SetPixel(x, y, NewColour);
                            }
                        }
                    }
                }
                finally
                {
                    // when we're done, unlock the memory region
                    //
                    lockBitmap.UnlockBits();
                }
            }

            // return the new bitmap with the new colour for the matching pixels
            //
            return temp;
        }

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetDesktopWindow();

        [DllImport("gdi32.dll", SetLastError = true)]
        public static extern uint GetPixel(IntPtr dc, int x, int y);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern IntPtr GetWindowDC(IntPtr window);

        [DllImport("user32.dll", SetLastError = true)]
        public static extern int ReleaseDC(IntPtr window, IntPtr dc);
    }
}
