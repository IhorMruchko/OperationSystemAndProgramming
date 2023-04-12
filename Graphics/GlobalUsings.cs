global using System;
global using System.Collections.Generic;
global using System.Windows.Input;
global using System.IO;
global using static System.Math;
using System.Windows.Media;

namespace Graphics;

public static class Constants
{
    public const string TITLE = "Pain-t";
    public const string TITLE_EDIT = "Pain-t*";
    public static class IO
    {
        public static readonly string CurrentDirectory = Environment.CurrentDirectory;
        public static readonly string ResourcesDirectory = Path.Combine(CurrentDirectory, "Resources");

        public static class Images
        {
            public const string BMP_FILTER = "Bmp|*.bmp";
            
            public static class Icons
            {
                private const string ICONS_DIR = @"Resources\Icons";
                private const string WINDOW_ICON = "pain-t.png";
                private const string NEW_ICON = "new-file.png";
                private const string ADD_ICON = "add.png";
                private const string OPEN_ICON = "open.png";
                private const string SAVE_ICON = "save.png";
                private const string EXIT_ICON = "exit.png";

                private const string MOVE_ICON = "move.png";
                private const string LINE_ICON = "line.png";
                private const string ELLIPSE_ICON = "ellipse.png";
                private const string RECTANGLE_ICON = "rectangle.png";
                
                private const string LINE_COLOR_ICON = "stroke-color.png";
                private const string FILL_COLOR_ICON = "fill-color.png";
                private const string THICKNESS_ICON = "thickness.png";

                public static readonly string WindowIcon = Path.Combine(CurrentDirectory, ICONS_DIR, WINDOW_ICON);
                public static readonly string OpenIcon = Path.Combine(CurrentDirectory, ICONS_DIR, OPEN_ICON);
                public static readonly string NewFileIcon = Path.Combine(CurrentDirectory, ICONS_DIR, NEW_ICON);
                public static readonly string SaveIcon = Path.Combine(CurrentDirectory, ICONS_DIR, SAVE_ICON);
                public static readonly string AddIcon = Path.Combine(CurrentDirectory, ICONS_DIR, ADD_ICON);
                
                public static readonly string MoveIcon = Path.Combine(CurrentDirectory, ICONS_DIR, MOVE_ICON);
                public static readonly string LineIcon = Path.Combine(CurrentDirectory, ICONS_DIR, LINE_ICON);
                public static readonly string ElipseIcon = Path.Combine(CurrentDirectory, ICONS_DIR, ELLIPSE_ICON);
                public static readonly string RectangleIcon = Path.Combine(CurrentDirectory, ICONS_DIR, RECTANGLE_ICON);
                public static readonly string LineColorIcon = Path.Combine(CurrentDirectory, ICONS_DIR, LINE_COLOR_ICON);
                public static readonly string FillColorIcon = Path.Combine(CurrentDirectory, ICONS_DIR, FILL_COLOR_ICON);
                public static readonly string ThicknessColorIcon = Path.Combine(CurrentDirectory, ICONS_DIR, THICKNESS_ICON);
                public static readonly string ExitIcon = Path.Combine(CurrentDirectory, ICONS_DIR, EXIT_ICON);

            }
        }
    }

    public static class MenuOperationsSettings
    {
        public static class Names
        {
            public const string FILE = "File";
            public const string NEW = "New";
            public const string ADD = "Add";
            public const string OPEN = "Open";
            public const string SAVE = "Save";
            public const string SAVE_AS = "Save as";
            public const string EXIT = "Exit";

            public const string EDIT = "Edit";
            public const string CUT = "Cut";
            public const string COPY = "Copy";
            public const string PASTE = "Paste";
            public const string DELETE = "Delete";
            public const string SELECT_ALL = "Select all";

            public const string TOOLS = "Tools";
            public const string MOVER = "Move";
            public const string LINE = "Line";
            public const string ELLIPSE = "Ellipse";
            public const string RECTANGLE = "Rectangle";

            public const string PROPERTIES = "Properties";
            public const string LINE_COLOR = "Line color";
            public const string FILL_COLOR = "Fill color";
            public const string THICKNESS = "Thickness";

        }

        public static class Orders
        {
            public const int FILE = 1;
            public const int NEW = 2;
            public const int ADD = 3;
            public const int OPEN = 4;
            public const int SAVE = 5;
            public const int SAVE_AS = 6;
            public const int EXIT = 7;

            public const int EDIT = 2;
            public const int CUT = 1;
            public const int COPY = 2;
            public const int PASTE = 3;
            public const int DELETE = 4;
            public const int SELECT_ALL = 5;

            public const int TOOLS = 3;
            public const int MOVER = 0;
            public const int LINE = 1;
            public const int ELLIPSE = 2;
            public const int RECTANGLE = 3;

            public const int PROPERTIES = 4;
            public const int LINE_COLOR = 1;
            public const int FILL_COLOR = 2;
            public const int THICKNESS = 3;
        }

        public static class Keys
        {
            public const string FILE = "";
            public const string NEW = "Ctrl + N";
            public const string ADD = "Ctrl + O";
            public const string OPEN = "Ctrl + Shift + O";
            public const string SAVE = "Ctrl + S";
            public const string SAVE_AS = "Ctrl + Shift + S";
            public const string EXIT = "Ctrl + E";

            public const string EDIT = "";
            public const string CUT = "Ctrl + X";
            public const string COPY = "Ctrl + C";
            public const string PASTE = "Ctrl + V";
            public const string DELETE = "del";
            public const string SELECT_ALL = "Ctrl + A";

            public const string TOOLS = "";
            public const string MOVER = "Ctrl + Shift + M";
            public const string LINE = "Ctrl + Shift + L";
            public const string ELLIPSE = "Ctrl + Shift + E";
            public const string RECTANGLE = "Ctrl + Shift + R";

            public const string PROPERTIES = "";
            public const string LINE_COLOR = "Ctrl + L + C";
            public const string FILL_COLOR = "Ctrl + F + C";
            public const string THICKNESS = "Ctrl + T";
        }
    }

    public static class Properties
    {
        public static readonly Brush DefaultFillColor = Brushes.Transparent;
        public static readonly Brush DefaultStrokeColor = Brushes.Black;
        public static readonly int DefaultStrokeThickness = 2;
    }
}