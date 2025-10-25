using System.Drawing;

namespace book_management.UI.Theme
{
    public static class AppColors
    {
        // Primary brand color (used for active/selected states)
        public static Color Primary => Color.FromArgb(74, 144, 226);
        // Color used for text/icons on top of the primary color
        public static Color OnPrimary => Color.White;

        // Default text color in the app
        public static Color TextPrimary => Color.FromArgb(51, 51, 51);

        // Sidebar inactive button background
        public static Color SidebarInactive => Color.White;

        // Main content background
        public static Color ContentBackground => Color.FromArgb(243, 244, 246);

        public static Color SuccessGreen => Color.FromArgb(34, 197, 94);

        public static Color WarningYellow => Color.FromArgb(234, 179, 8);

        public static Color ErrorRed => Color.FromArgb(254, 242, 242);

        public static Color ErrorTextRed => Color.FromArgb(185, 28, 28);
    }
}
