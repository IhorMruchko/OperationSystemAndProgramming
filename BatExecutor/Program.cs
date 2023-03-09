using OperationSystemAndProgrammingLIB;
using OperationSystemAndProgrammingLIB.Extensions;
using OperationSystemAndProgrammingLIB.Helpers;
using System.Diagnostics;

var programsCodes = new byte[]
{
    0xEB, 0x18, 0x90,
    0x54, 0x65, 0x73, 0x74, 0x69, 0x6E,
    0x67, 0x3A, 0x20, 0x70, 0x72, 0x69,
    0x6E, 0x74, 0x20, 0x61, 0x20, 0x6C,
    0x69, 0x6E, 0x65, 0x3A,
    0x24,

    0xB4, 0x09,
    0x8D, 0x16, 0x03, 0x01,
    0xCD, 0x21,
    0xB8, 0x00, 0x4c,
    0xCD, 0x21,
};


var binaryfileSource = IOHelper.CreateBinaryFile(Environment.CurrentDirectory,
                                                 Constants.IO.COM_FILE_COMMAND_NAME,
                                                 Constants.IO.COM_FILE_EXTENSION,
                                                 programsCodes);

var fileSource = IOHelper.CreateFile(Environment.CurrentDirectory,
                                     Constants.IO.BAT_FILE_COMMAND_NAME,
                                     Constants.IO.BAT_FILE_EXTENSION,
                                     Constants.IO.BAT_FILE_COMMAND_FORMAT.Format(binaryfileSource));



Process.Start(fileSource);

