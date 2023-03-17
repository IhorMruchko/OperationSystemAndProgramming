using TranslatorLIB;
using TranslatorLIB.Extensions;
using TranslatorLIB.Operands;
using Const = ASMEngine.Constant;
using Reg = ASMEngine.Register;
using CompError = ASMEngine.CompileError;
using SegReg = ASMEngine.SegmentRegister;
using Adr = ASMEngine.Address;
using TranslatorLIB.Helpers;

namespace Tests.TranslatorLIB;

public class OperandsTesting
{
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    [TestCase("\"\"", false)]
    [TestCase("\"1\"", true)]
    [TestCase("21", true)]
    [TestCase("21513", true)]
    [TestCase("\"21513\"", false)]
    public void Constant_CanCreate_ExpectedResult(string line, bool result)
    {
        var canCreate = new Constant().CanCreate(line);
        Assert.That(canCreate, Is.EqualTo(result));
    }

    [Test]
    [TestCase("\"\"")]
    [TestCase("\"1\"")]
    [TestCase("21")]
    [TestCase("21513")]
    [TestCase("\"21513\"")]
    public void Constant_CanCreate_ComparingResult(string line)
    {
        var canCreate = new Constant().CanCreate(line);
        var tryCreate = new Const().TryToCreate(line);
        Assert.That(canCreate, Is.EqualTo(tryCreate));
    }

    [Test]
    [TestCase("\"1\"", 1)]
    [TestCase("\"1\"", 2)]
    [TestCase("251", 1)]
    [TestCase("251", 2)]
    public void Constant_Create_ComparingResults(string line, int bytes)
    {
        var constant = new Constant(line, bytes);
        var @const = new Const(line, bytes);
        Assert.Multiple(() =>
        {
            Assert.That(constant.Im8, Is.EqualTo(@const.im8));
            Assert.That(constant.Im16, Is.EqualTo(@const.im16));
            Assert.That(constant.OperandTypes.Select(t => t.ToString()),
                Is.EquivalentTo(@const.types.Select(t => t.ToString())));
            Assert.That(constant.ConstantValue, Is.EqualTo(@const.Data));
        });
    }

    [Test]
    [TestCase(Constants.Register.AL)]
    [TestCase(Constants.Register.AX)]
    [TestCase(Constants.Register.CL)]
    [TestCase(Constants.Register.CX)]
    [TestCase(Constants.Register.DL)]
    [TestCase(Constants.Register.DX)]
    [TestCase(Constants.Register.BL)]
    [TestCase(Constants.Register.BX)]
    [TestCase(Constants.Register.AH)]
    [TestCase(Constants.Register.SP)]
    [TestCase(Constants.Register.CH)]
    [TestCase(Constants.Register.BP)]
    [TestCase(Constants.Register.DH)]
    [TestCase(Constants.Register.SI)]
    [TestCase(Constants.Register.BH)]
    [TestCase(Constants.Register.DI)]
    [TestCase("AM")]
    public void Register_CanCreate_ComparingResults(string line)
    {
        var register = new Register().CanCreate(line);
        var reg = new Reg().TryToCreate(line);

        Assert.That(reg, Is.EqualTo(register));
    }

    [Test]
    [TestCase(Constants.Register.AL)]
    [TestCase(Constants.Register.AX)]
    [TestCase(Constants.Register.CL)]
    [TestCase(Constants.Register.CX)]
    [TestCase(Constants.Register.DL)]
    [TestCase(Constants.Register.DX)]
    [TestCase(Constants.Register.BL)]
    [TestCase(Constants.Register.BX)]
    [TestCase(Constants.Register.AH)]
    [TestCase(Constants.Register.SP)]
    [TestCase(Constants.Register.CH)]
    [TestCase(Constants.Register.BP)]
    [TestCase(Constants.Register.DH)]
    [TestCase(Constants.Register.SI)]
    [TestCase(Constants.Register.BH)]
    [TestCase(Constants.Register.DI)]
    [TestCase(Constants.Register.AL, true)]
    [TestCase(Constants.Register.AX, true)]
    [TestCase(Constants.Register.CL, true)]
    [TestCase(Constants.Register.CX, true)]
    [TestCase(Constants.Register.DL, true)]
    [TestCase(Constants.Register.DX, true)]
    [TestCase(Constants.Register.BL, true)]
    [TestCase(Constants.Register.BX, true)]
    [TestCase(Constants.Register.AH, true)]
    [TestCase(Constants.Register.SP, true)]
    [TestCase(Constants.Register.CH, true)]
    [TestCase(Constants.Register.BP, true)]
    [TestCase(Constants.Register.DH, true)]
    [TestCase(Constants.Register.SI, true)]
    [TestCase(Constants.Register.BH, true)]
    [TestCase(Constants.Register.DI, true)]
    public void Register_Create_ComparingResults(string line, bool first = false)
    {
        var register = new Register(line);
        var reg = new Reg(line);

        Assert.Multiple(() =>
        {
            Assert.That(register.Register, Is.EqualTo(reg.reg));
            Assert.That(register.W, Is.EqualTo(reg.w));
            Assert.That(register.Mod, Is.EqualTo(reg.mod));
            Assert.That(register.OperandTypes.Select(t => t.ToString()),
               Is.EquivalentTo(reg.types.Select(t => t.ToString())));
        });
    }

    [Test]
    [TestCase("AM")]
    public void Register_Create_Raise(string line)
    {
        Assert.Multiple(() =>
        {
            Assert.Throws<CompileError>(() => new Register(line), Constants.Errors.REGISTER_NOT_FOUND.Format(line));
            Assert.Throws<CompError>(() => new Reg(line));
        });
    }

    [Test]
    [TestCase(Constants.Register.ES)]
    [TestCase(Constants.Register.CS)]
    [TestCase(Constants.Register.SS)]
    [TestCase(Constants.Register.DS)]
    [TestCase(Constants.Register.AX)]
    public void SegmentRegister_CanCreate_CompareResults(string line)
    {
        var segmentRegister = new SegmentRegister().CanCreate(line);
        var segRegister = new SegReg().TryToCreate(line);

        Assert.That(segmentRegister, Is.EqualTo(segRegister));
    }

    [Test]
    [TestCase(Constants.Register.SI)]
    [TestCase(Constants.Register.DI)]
    [TestCase(Constants.Register.BX)]
    [TestCase("[BX] SI []")]
    [TestCase("BX [DI] []")]
    [TestCase("BP SI")]
    [TestCase("BP DI")]
    [TestCase("SI 12+31")]
    [TestCase("DI DI+31")]
    [TestCase("BP +SI+31")]
    [TestCase("BX +BP+32")]
    [TestCase("[BX] [sI] 12")]
    [TestCase("[BX] [DI] 12h")]
    [TestCase("[BP] [SI] 12b")]
    [TestCase("[BP] [DI] 122")]

    public void Address_Init_CompareResults(string line)
    {
        var address = new Address(line);
        var adr = new Adr(line);

        Assert.Multiple(() =>
        {
            Assert.That(address.Mod, Is.EqualTo(adr.mod));
            Assert.That(address.RegisterOrMemory, Is.EqualTo(adr.rm));
            Assert.That(address.AddressStringValue, Is.EqualTo(adr.var));
            Assert.That(address.Offset, Is.EqualTo(adr.offset));
            Assert.That(address.OperandTypes.Select(t => t.ToString()),
              Is.EquivalentTo(adr.types.Select(t => t.ToString())));
        });

    }
}
