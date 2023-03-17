namespace TranslatorLIB;

public static class Constants
{
    public static class Operands
    {
        public const string IMMEDIATE8_DEFAULT = "im8";
        public const string IMMEDIATE16_DEFAULT = "im16";
        public const string REGISTER_DEFAULT = "reg";
        public const string W_DEFAULT = "w";
        public const string REGISTER_OR_MEMORY_DEFAULT = "r/m";
        public const string MOD_DEFAULT = "mod";
        public const string SEGMENT_DEFAULT = "s";
        public const string SEGMENT_REGISTER_DEFAULT = "sreg";
    }

    public static class Errors
    {
        public const string VARIABLE_NOT_FOUND = "There is no such a variable as [{0}].";
        public const string WRONG_NUMERIC_INPUT = "Number [{0}] was in invalid format.";
        public const string REGISTER_NOT_FOUND = "Cannot find [{0}] register.";
        public const string SEGMENT_REGISTER_NOT_FOUND = "Cannot find [{0}] segment register.";
    }

    public static class Converting
    {
        public const int BIT = 1;
        public const int VALUE_INDEX = 1;
        public const int BINARY_BASE = 2;
        public const int TWO_BITS = 2;
        public const int BITS_IN_BYTE = 8;
        public const int DECIMAL_BASE = 10;
        public const int HEX_BASE = 16;
        public const int DECIMAL_CAPACITY = 32;
        public const int ASCII_CHARSET_DIFFERENCE = 48;
        public const int OCT_BITS = 256;

        public const char LEADING_ZEROES = '0';

        public const string CONSTANTS_SIGN = "\"";
        public const string UNKNOW_VALUE = "?";
        public const string BINARY_BASE_SIGN = "B";
        public const string HEX_BASE_SIGN = "H";

        public static readonly char[] HEX_VALUES_SYMBOLS = new char[] { 'A', 'B', 'C', 'D', 'E', 'F' };

        public static readonly int[] HEX_VALUES = new int[] { 10, 11, 12, 13, 14, 15 };
    }

    public static class Register
    {
        public const string A = "A";
        public const string AL = "AL";
        public const string AX = "AX";
        public const string CL = "CL";
        public const string CX = "CX";
        public const string DL = "DL";
        public const string DX = "DX";
        public const string BL = "BL";
        public const string BX = "BX";
        public const string AH = "AH";
        public const string SP = "SP";
        public const string CH = "CH";
        public const string BP = "BP";
        public const string DH = "DH";
        public const string SI = "SI";
        public const string BH = "BH";
        public const string DI = "DI";
        public const string H = "H";
        public const string L = "L";
        public const string ES = "ES";
        public const string CS = "CS";
        public const string SS = "SS";
        public const string DS = "DS";
        public const string MOD = "11";
        public const string ZERO = "0";
        public const string ONE = "1";

        public static readonly string[] OPERATION_REGISTERS_8 = new[] { "AL", "BL", "CL", "DL", "AH", "BH", "CH", "DH" };
        public static readonly string[] OPERATION_REGISTERS_16 = new[] { "AX", "BX", "CX", "DX" };
        public static readonly string[] OPERATION_REGISTERS_32 = new[] { "EAX", "EBX", "ECX", "EDX" };
        public static readonly string[] OFFSET_REGISTERS = new[] { "SI", "DI" };
        public static readonly string[] BASE_REGISTERS = new[] { "BX", "BP" };
        public static readonly string[] SEGMENT_REGISTERS = new[] { "ES", "SS", "DS", "CS" };
        public static readonly string[] ADRESS_REGISTERS = OFFSET_REGISTERS.Concat(BASE_REGISTERS).ToArray();
        public static readonly string[] OPERATION_REGISTERS = OPERATION_REGISTERS_16.Concat(OPERATION_REGISTERS_8).ToArray();

        public static readonly Dictionary<string, string> REGISTER_TO_BINARY = new()
        {
            [AL] = "000",
            [AX] = "000",
            [ES] = "000",
            [CL] = "001",
            [CX] = "001",
            [CS] = "001",
            [DL] = "010",
            [DX] = "010",
            [SS] = "010",
            [BL] = "011",
            [BX] = "011",
            [DS] = "011",
            [AH] = "100",
            [SP] = "100",
            [CH] = "101",
            [BP] = "101",
            [DH] = "110",
            [SI] = "110",
            [BH] = "111",
            [DI] = "111",
        };
    }

    public static class Address
    {
        public const int PARTS_AMOUNT = 3;

        public const string OPEN_BRACKETS = "[";
        public const string CLOSE_BRACKETS = "]";
        public const string PLUS_SIGN = "+";
        public const string MOD = "10";

        public const string CLOSED_OPEN_RACKETS = CLOSE_BRACKETS + OPEN_BRACKETS;

        public static readonly (string, string) DISPOSED_VALUES = ("00", "110");

        public static readonly char[] LINE_SEPARATORS = new char[] { ' ', OPEN_BRACKETS[0], CLOSE_BRACKETS[0] };

        public static readonly Dictionary<string, (string, string)> ADRESS_TO_VALUES = new()
        {
            ["SI"] = ("00", "100"),
            ["DI"] = ("00", "101"),
            ["BX"] = ("00", "111")
        };
    }
}
