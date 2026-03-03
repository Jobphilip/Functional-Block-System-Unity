using UnityEngine;
[System.Serializable]
public class RotateBlock : BaseBlock
{
    public string ObjectId;
    public Vector3 Rotation;

    public override string Execute(BlockExecutionContext context)
    {
        var obj = context.GetObject(ObjectId);
        if (obj != null)
        {
            obj.transform.Rotate(Rotation);
        }

        return NextBlockId;
    }
}