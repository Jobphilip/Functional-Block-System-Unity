[System.Serializable]
public class SetVariableBlock : BaseBlock
{
    public string VariableName;
    public float Value;

    public override string Execute(BlockExecutionContext context)
    {
        context.Variables[VariableName] = Value;
        return NextBlockId;
    }
}