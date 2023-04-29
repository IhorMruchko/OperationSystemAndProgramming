namespace Graphics.MenuOperations.EditMenuOperations;

internal class EditMenuOperation : MenuOperation
{
    public override int DisplayOrder => Constants.MenuOperationsSettings.Orders.EDIT;

    public override List<MenuOperation> GroupOperations => new()
    {
        new CopyMenuOperation(),
        new PasteMenuOperation()
    };

    public override Key[] KeyBind => Array.Empty<Key>();

    protected override string Name => Constants.MenuOperationsSettings.Names.EDIT;

    protected override string IconFileSource => string.Empty;

}
