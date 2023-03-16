namespace TranslatorLIB;

public static class Constants
{
    public static class Errors
    {
        public const string VARIABLE_NOT_FOUND = "There is no such a variable as [{0}].";
        public const string WRONG_NUMERIC_INPUT = "Number [{0}] was in invalid format.";
    }

    public static class Converting
    {
        public const int BINARY_BASE = 2;
        public const int DECIMAL_BASE = 10;
        public const int HEX_BASE = 16;
        public const int DECIMAL_CAPACITY = 32;
        public const int ASCII_CHARSET_DIFFERENCE = 48;
        public const int OCT_BITS = 256;

        public const char LEADING_ZEROES = '0';

        public const string UNKNOW_VALUE = "?";
        public const string BINARY_BASE_SIGN = "B";
        public const string HEX_BASE_SIGN = "H";

        public static readonly char[] HEX_VALUES_SYMBOLS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };

        public static readonly int[] HEX_VALUES = new int[] { 10, 11, 12, 13, 14, 15 };
    }
}
