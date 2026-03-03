[System.Serializable]
public class CompareBlock : BaseBlock
{
    public string VariableName;
    public float CompareValue;
    public string TrueBlockId;
    public string FalseBlockId;

    public override string Execute(BlockExecutionContext context)
    {
        if (!context.Variables.ContainsKey(VariableName))
            return FalseBlockId;

        return context.Variables[VariableName] > CompareValue
            ? TrueBlockId
            : FalseBlockId;
    }
}