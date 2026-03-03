using UnityEngine;
[System.Serializable]
public class MoveBlock : BaseBlock
{
    public string ObjectId;
    public Vector3 Offset;

    public override string Execute(BlockExecutionContext context)
    {
        var obj = context.GetObject(ObjectId);
        if (obj != null)
        {
            obj.transform.position += Offset;
        }

        return NextBlockId;
    }
}