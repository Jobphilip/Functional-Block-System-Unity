using UnityEngine;

[System.Serializable]
public class CreateObjectBlock : BaseBlock
{
    public string ObjectId;
    public PrimitiveType PrimitiveType;
    public Vector3 Position;

    public override string Execute(BlockExecutionContext context)
    {
        var obj = GameObject.CreatePrimitive(PrimitiveType);
        obj.transform.position = Position;
        context.SceneObjects[ObjectId] = obj;

        return NextBlockId;
    }
}