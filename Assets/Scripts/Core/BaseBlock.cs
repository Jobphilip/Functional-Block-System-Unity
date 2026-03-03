using System;
using UnityEngine;

[Serializable]
public abstract class BaseBlock
{
    public string Id;
    public string NextBlockId;

    public abstract string Execute(BlockExecutionContext context);
}