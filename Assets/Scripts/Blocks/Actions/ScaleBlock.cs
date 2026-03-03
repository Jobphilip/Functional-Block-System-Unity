using UnityEngine;
[System.Serializable]
public class ScaleBlock : BaseBlock
{
    public string ObjectId;
    public Vector3 Scale;

    public override string Execute(BlockExecutionContext context)
    {
        var obj = context.GetObject(ObjectId);
        if (obj != null)
        {
            obj.transform.localScale = Scale;
        }

        return NextBlockId;
    }
}