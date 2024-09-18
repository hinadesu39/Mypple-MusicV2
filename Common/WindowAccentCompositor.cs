using System;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Shell;
//原文地址https://slimenull.com/p/20240530104846/#%E8%83%8C%E6%99%AF%E6%A8%A1%E7%B3%8A-api
namespace Common
{
    public class WindowAccentCompositor
    {
        [DllImport("DWMAPI")]
        public static extern nint DwmSetWindowAttribute(nint hwnd, DwmWindowAttribute attribute, nint dataPointer, uint dataSize);
        [DllImport("User32")]
        public static extern bool SetWindowCompositionAttribute(nint hwnd, ref WindowCompositionAttributeData data);
        [DllImport("DWMAPI")]
        public static extern nint DwmExtendFrameIntoClientArea(nint hwnd, ref Margins margins);

        public enum DwmWindowAttribute
        {
            NCRENDERING_ENABLED,
            NCRENDERING_POLICY,
            TRANSITIONS_FORCEDISABLED,
            ALLOW_NCPAINT,
            CAPTION_BUTTON_BOUNDS,
            NONCLIENT_RTL_LAYOUT,
            FORCE_ICONIC_REPRESENTATION,
            FLIP3D_POLICY,
            EXTENDED_FRAME_BOUNDS,
            HAS_ICONIC_BITMAP,
            DISALLOW_PEEK,
            EXCLUDED_FROM_PEEK,
            CLOAK,
            CLOAKED,
            FREEZE_REPRESENTATION,
            PASSIVE_UPDATE_MODE,
            USE_HOSTBACKDROPBRUSH,

            // 表示是否使用暗色模式, 它会将窗体的模糊背景调整为暗色
            USE_IMMERSIVE_DARK_MODE = 20,
            WINDOW_CORNER_PREFERENCE = 33,
            BORDER_COLOR,
            CAPTION_COLOR,
            TEXT_COLOR,
            VISIBLE_FRAME_BORDER_THICKNESS,

            // 背景类型, 值可以是: 自动, 无, 云母, 或者亚克力
            SYSTEMBACKDROP_TYPE,
            LAST
        }

        public enum WindowBackdrop
        {
            Auto = 0,
            None = 1,
            MainWindow = 2,
            TransientWindow = 3,
            TabbedWindow = 4
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WindowCompositionAttributeData
        {
            /// <summary>
            /// A flag describing which value to get or set, specified as a value of the <see cref="WindowCompositionAttribute"/> enumeration. 
            /// This parameter specifies which attribute to get or set, and the pvData member points to an object containing the attribute value.
            /// </summary>
            public WindowCompositionAttribute Attribute;

            /// <summary>
            /// When used with the GetWindowCompositionAttribute function, this member contains a pointer to a variable that will hold the value of the requested attribute when the function returns. <br/>
            /// When used with the SetWindowCompositionAttribute function, it points an object containing the attribute value to set. <br/>
            /// The type of the value set depends on the value of the Attrib member.
            /// </summary>
            public nint DataPointer;

            /// <summary>
            /// The size of the object pointed to by the pvData member, in bytes.
            /// </summary>
            public uint DataSize;
        }

        public enum WindowCompositionAttribute
        {
            // 省略其他未使用的字段
            WcaAccentPolicy = 19,
            // 省略其他未使用的字段
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct AccentPolicy
        {
            public AccentState AccentState;
            public AccentFlags AccentFlags;
            public int GradientColor;
            public int AnimationId;
        }

        public enum AccentState
        {
            Disabled,
            EnableGradient = 1,           // 渐变 (实测没什么用)
            EnableTransparent = 2,        // 透明 (实测没什么用)
            EnableBlurBehind = 3,         // 背景模糊 (有用)
            EnableAcrylicBlurBehind = 4,  // 背景亚克力模糊 (有用)
            EnableHostBackdrop = 5,       // 没啥用
            InvalidState = 6,
        }

        [Flags]
        public enum AccentFlags
        {
            None = 0,
            ExtendSize = 0x4,      // 启用此 flag 会导致窗体大小拓展至屏幕大小
            LeftBorder = 0x20,     // 启用窗口左侧边框 (当 WindowStyle 为 None 时可以看出来)
            TopBorder = 0x40,      // 启用窗口顶部边框 (同上)
            RightBorder = 0x80,    // 启用窗口右侧边框 (同上)
            BottomBorder = 0x100,  // 启用窗口底部边框

            // 合起来, 启用窗口所有边框
            AllBorder = LeftBorder | TopBorder | RightBorder | BottomBorder,
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct Margins
        {
            public int LeftWidth;
            public int RightWidth;
            public int TopHeight;
            public int BottomHeight;
        }
    }
}
