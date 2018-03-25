using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace DolphinScript.Lib.Backend
{
    /// <summary>
    /// This class contains methods and variables invoked from other languages and are used in multiple different classes.
    /// </summary>
    public class WinAPI
    {
        // minimise/maximise window flags
        //
        public static int SW_SHOWNORMAL = 1;
        public static int SW_SHOWMINIMIZED = 2;
        public static int SW_SHOWMAXIMIZED = 3;

        // keypressed mem state
        //
        public const int KEY_PRESSED = 0x8000;

        /// <summary>
        /// struct used to store a rect area, offers extra functionality
        /// </summary>
        [Serializable]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;

            public int Height { get { return Bottom - Top; } }
            public int Width { get { return Right - Left; } }

            /// <summary>
            /// RECT constructor which takes two points (TopLeft & BottomRight points)
            /// </summary>
            /// <param name="TopLeft"></param>
            /// <param name="BottomRight"></param>
            public RECT(POINT TopLeft, POINT BottomRight)
            {
                Top = TopLeft.Y;
                Left = TopLeft.X;
                Bottom = BottomRight.Y;
                Right = BottomRight.X;
            }

            /// <summary>
            /// RECT constructor which takes four ints (each side of the RECT area)
            /// </summary>
            /// <param name="Top"></param>
            /// <param name="Left"></param>
            /// <param name="Bottom"></param>
            /// <param name="Right"></param>
            public RECT(int Top, int Left, int Bottom, int Right)
            {
                this.Top = Top;
                this.Left = Left;
                this.Bottom = Bottom;
                this.Right = Right;
            }

            /// <summary>
            /// prints the area of the rect
            /// </summary>
            /// <returns></returns>
            public string PrintArea()
            {
                return "Top-Left XY: " + Left + ", " + Top + " Bottom-Right XY: " + Right + ", " + Bottom;
            }
        }

        /// <summary>
        /// this struct is used to store a point, also offers extra functionality
        /// </summary>
        [Serializable]
        public struct POINT
        {
            public int X;
            public int Y;
            
            /// <summary>
            /// POINT constructor takes two ints which are the x and y position of the coordinate
            /// </summary>
            /// <param name="X"></param>
            /// <param name="Y"></param>
            public POINT(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }

            public override string ToString()
            {
                return $"X: {X} Y: {Y}";
            }

            /// <summary>
            /// converts the normal C# point to our POINT structure
            /// </summary>
            /// <param name="point"></param>
            public static implicit operator Point(POINT point)
            {
                return new Point(point.X, point.Y);
            }
        }

        /// <summary>
        /// stores the different mouse states the mouse can take
        /// </summary>
        public enum VirtualMouseStates : uint
        {
            LMB_Down = 0x02,
            LMB_Up = 0x04,
            RMB_Down = 0x08,
            RMB_Up = 0x10,
            MMB_Down = 0x0020,
            MMB_Up = 0x0040,
            Left_Click,
            Middle_Click,
            Right_Click,
            None
        }

        /// <summary>
        /// contains the different keys on the keyboard
        /// </summary>
        public enum VirtualKeyStates : int
        {
            VK_BACK = 0x08,
            VK_TAB = 0x09,
            //
            VK_CLEAR = 0x0C,
            VK_RETURN = 0x0D,
            //
            VK_SHIFT = 0x10,
            VK_CONTROL = 0x11,
            VK_MENU = 0x12,
            VK_PAUSE = 0x13,
            VK_CAPITAL = 0x14,
            //
            VK_ESCAPE = 0x1B,
            //
            VK_SPACE = 0x20,
            VK_PRIOR = 0x21,
            VK_NEXT = 0x22,
            VK_END = 0x23,
            VK_HOME = 0x24,
            VK_LEFT = 0x25,
            VK_UP = 0x26,
            VK_RIGHT = 0x27,
            VK_DOWN = 0x28,
            VK_SELECT = 0x29,
            VK_PRINT = 0x2A,
            VK_EXECUTE = 0x2B,
            VK_SNAPSHOT = 0x2C,
            VK_INSERT = 0x2D,
            VK_DELETE = 0x2E,
            VK_HELP = 0x2F,
            //
            VK_LWIN = 0x5B,
            VK_RWIN = 0x5C,
            //
            VK_NUMPAD0 = 0x60,
            VK_NUMPAD1 = 0x61,
            VK_NUMPAD2 = 0x62,
            VK_NUMPAD3 = 0x63,
            VK_NUMPAD4 = 0x64,
            VK_NUMPAD5 = 0x65,
            VK_NUMPAD6 = 0x66,
            VK_NUMPAD7 = 0x67,
            VK_NUMPAD8 = 0x68,
            VK_NUMPAD9 = 0x69,
            VK_MULTIPLY = 0x6A,
            VK_ADD = 0x6B,
            VK_SEPARATOR = 0x6C,
            VK_SUBTRACT = 0x6D,
            VK_DECIMAL = 0x6E,
            VK_DIVIDE = 0x6F,
            //
            VK_KEY_A = 0x41,
            VK_KEY_B = 0x42,
            VK_KEY_C = 0x43,
            VK_KEY_D = 0x44,
            VK_KEY_E = 0x45,
            VK_KEY_F = 0x46,
            VK_KEY_G = 0x47,
            VK_KEY_H = 0x48,
            VK_KEY_I = 0x49,
            VK_KEY_J = 0x4A,
            VK_KEY_K = 0x4B,
            VK_KEY_L = 0x4C,
            VK_KEY_M = 0x4D,
            VK_KEY_N = 0x4E,
            VK_KEY_O = 0x4F,
            VK_KEY_P = 0x50,
            VK_KEY_Q = 0x51,
            VK_KEY_R = 0x52,
            VK_KEY_S = 0x53,
            VK_KEY_T = 0x54,
            VK_KEY_U = 0x55,
            VK_KEY_V = 0x56,
            VK_KEY_W = 0x57,
            VK_KEY_X = 0x58,
            VK_KEY_Y = 0x59,
            VK_KEY_Z = 0x5A,
            //
            VK_KEY_0 = 0x30,
            VK_KEY_1 = 0x31,
            VK_KEY_2 = 0x32,
            VK_KEY_3 = 0x33,
            VK_KEY_4 = 0x34,
            VK_KEY_5 = 0x35,
            VK_KEY_6 = 0x36,
            VK_KEY_7 = 0x37,
            VK_KEY_8 = 0x38,
            VK_KEY_9 = 0x39,
            //
            VK_F1 = 0x70,
            VK_F2 = 0x71,
            VK_F3 = 0x72,
            VK_F4 = 0x73,
            VK_F5 = 0x74,
            VK_F6 = 0x75,
            VK_F7 = 0x76,
            VK_F8 = 0x77,
            VK_F9 = 0x78,
            VK_F10 = 0x79,
            VK_F11 = 0x7A,
            VK_F12 = 0x7B,
            VK_F13 = 0x7C,
            VK_F14 = 0x7D,
            VK_F15 = 0x7E,
            VK_F16 = 0x7F,
            VK_F17 = 0x80,
            VK_F18 = 0x81,
            VK_F19 = 0x82,
            VK_F20 = 0x83,
            VK_F21 = 0x84,
            VK_F22 = 0x85,
            VK_F23 = 0x86,
            VK_F24 = 0x87,
            //
            VK_NUMLOCK = 0x90,
            VK_SCROLL = 0x91,
            //
            VK_OEM_NEC_EQUAL = 0x92,   // '=' key on numpad
            //
            VK_LSHIFT = 0xA0,
            VK_RSHIFT = 0xA1,
            VK_LCONTROL = 0xA2,
            VK_RCONTROL = 0xA3,
            VK_LMENU = 0xA4,
            VK_RMENU = 0xA5,
            //
            VK_BROWSER_BACK = 0xA6,
            VK_BROWSER_FORWARD = 0xA7,
            VK_BROWSER_REFRESH = 0xA8,
            VK_BROWSER_STOP = 0xA9,
            VK_BROWSER_SEARCH = 0xAA,
            VK_BROWSER_FAVORITES = 0xAB,
            VK_BROWSER_HOME = 0xAC,
            //
            VK_VOLUME_MUTE = 0xAD,
            VK_VOLUME_DOWN = 0xAE,
            VK_VOLUME_UP = 0xAF,
            VK_MEDIA_NEXT_TRACK = 0xB0,
            VK_MEDIA_PREV_TRACK = 0xB1,
            VK_MEDIA_STOP = 0xB2,
            VK_MEDIA_PLAY_PAUSE = 0xB3,
            VK_LAUNCH_MAIL = 0xB4,
            VK_LAUNCH_MEDIA_SELECT = 0xB5,
            VK_LAUNCH_APP1 = 0xB6,
            VK_LAUNCH_APP2 = 0xB7,
            //
            VK_OEM_1 = 0xBA,   // ';:' for US
            VK_OEM_PLUS = 0xBB,   // '+' any country
            VK_OEM_COMMA = 0xBC,   // ',' any country
            VK_OEM_MINUS = 0xBD,   // '-' any country
            VK_OEM_PERIOD = 0xBE,   // '.' any country
            VK_OEM_2 = 0xBF,   // '/?' for US
            VK_OEM_3 = 0xC0,   // '`~' for US
                               //
            VK_OEM_4 = 0xDB,  //  '[{' for US
            VK_OEM_5 = 0xDC,  //  '\|' for US
            VK_OEM_6 = 0xDD,  //  ']}' for US
            VK_OEM_7 = 0xDE,  //  ''"' for US
            VK_OEM_8 = 0xDF,
            //
            VK_OEM_AX = 0xE1,  //  'AX' key on Japanese AX kbd
            VK_OEM_102 = 0xE2,  //  "<>" or "\|" on RT 102-key kbd.
            VK_ICO_HELP = 0xE3,  //  Help key on ICO
            VK_ICO_00 = 0xE4,  //  00 key on ICO
                               //
            VK_PROCESSKEY = 0xE5,
            //
            VK_ICO_CLEAR = 0xE6,
            //
            VK_PACKET = 0xE7,
            //
            VK_OEM_RESET = 0xE9,
            VK_OEM_JUMP = 0xEA,
            VK_OEM_PA1 = 0xEB,
            VK_OEM_PA2 = 0xEC,
            VK_OEM_PA3 = 0xED,
            VK_OEM_WSCTRL = 0xEE,
            VK_OEM_CUSEL = 0xEF,
            VK_OEM_ATTN = 0xF0,
            VK_OEM_FINISH = 0xF1,
            VK_OEM_COPY = 0xF2,
            VK_OEM_AUTO = 0xF3,
            VK_OEM_ENLW = 0xF4,
            VK_OEM_BACKTAB = 0xF5,
            //
            VK_ATTN = 0xF6,
            VK_CRSEL = 0xF7,
            VK_EXSEL = 0xF8,
            VK_EREOF = 0xF9,
            VK_PLAY = 0xFA,
            VK_ZOOM = 0xFB,
            VK_NONAME = 0xFC,
            VK_PA1 = 0xFD,
            VK_OEM_CLEAR = 0xFE,
            None
        }

        /// <summary>
        /// imported method which allows you to listen for a keypress
        /// </summary>
        /// <param name="vKey"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(VirtualKeyStates vKey);

        /// <summary>
        /// imported method which returns the current position of the mouse cursor
        /// </summary>
        /// <param name="lpPoint"></param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        public static extern bool GetCursorPos(out POINT lpPoint);
    }
}