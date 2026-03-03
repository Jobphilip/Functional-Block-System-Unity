using System.Collections.Generic;
using UnityEngine;

public class BlockGraphExecutor : MonoBehaviour
{
    [SerializeReference]
    public List<BaseBlock> Blocks = new();

    private Dictionary<string, BaseBlock> blockMap;
    private BlockExecutionContext context;

    void Awake()
    {
        Blocks = new List<BaseBlock>
        {
            new CreateObjectBlock
            {
                Id = "create_cube",
                NextBlockId = "create_sphere",
                ObjectId = "cube_1",
                PrimitiveType = PrimitiveType.Cube,
                Position = new Vector3(-2f, 0.5f, 0f)
            },

            new CreateObjectBlock
            {
                Id = "create_sphere",
                NextBlockId = "set_variable",
                ObjectId = "sphere_1",
                PrimitiveType = PrimitiveType.Sphere,
                Position = new Vector3(2f, 0.5f, 0f)
            },

            new SetVariableBlock
            {
                Id = "set_variable",
                NextBlockId = "compare_block",
                VariableName = "sizeFactor",
                Value = 2f
            },

            new CompareBlock
            {
                Id = "compare_block",
                VariableName = "sizeFactor",
                CompareValue = 1f,
                TrueBlockId = "scale_cube",
                FalseBlockId = "scale_sphere"
            },

            new ScaleBlock
            {
                Id = "scale_cube",
                NextBlockId = "move_cube",
                ObjectId = "cube_1",
                Scale = new Vector3(2f, 2f, 2f)
            },

            new MoveBlock
            {
                Id = "move_cube",
                NextBlockId = "rotate_cube",
                ObjectId = "cube_1",
                Offset = new Vector3(0f, 0f, 3f)
            },

            new RotateBlock
            {
                Id = "rotate_cube",
                ObjectId = "cube_1",
                Rotation = new Vector3(0f, 45f, 0f)
            }
        };
    }

    void Start()
    {
        Execute("create_cube");
    }

    public void Execute(string startBlockId)
    {
        context = new BlockExecutionContext();
        blockMap = new Dictionary<string, BaseBlock>();

        foreach (var block in Blocks)
            blockMap[block.Id] = block;

        string currentId = startBlockId;

        while (!string.IsNullOrEmpty(currentId))
        {
            if (!blockMap.ContainsKey(currentId))
                break;

            currentId = blockMap[currentId].Execute(context);
        }
    }
    public void ClearScene()
    {
        if (context == null)
            return;

        foreach (var obj in context.SceneObjects.Values)
        {
            if (obj != null)
                Destroy(obj);
        }

        context.SceneObjects.Clear();
    }
}