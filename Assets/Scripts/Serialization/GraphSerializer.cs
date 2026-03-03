using System;
using System.Collections.Generic;
using UnityEngine;

public static class GraphSerializer
{
    public static string Export(List<BaseBlock> blocks)
    {
        var wrappers = new List<BlockWrapper>();

        foreach (var block in blocks)
        {
            wrappers.Add(new BlockWrapper
            {
                Type = block.GetType().AssemblyQualifiedName,
                JsonData = JsonUtility.ToJson(block)
            });
        }

        return JsonUtility.ToJson(
            new WrapperCollection { Blocks = wrappers },
            true
        );
    }

    public static List<BaseBlock> Import(string json)
    {
        var collection = JsonUtility.FromJson<WrapperCollection>(json);
        var result = new List<BaseBlock>();

        foreach (var wrapper in collection.Blocks)
        {
            var type = Type.GetType(wrapper.Type);
            var block = (BaseBlock)JsonUtility.FromJson(wrapper.JsonData, type);
            result.Add(block);
        }

        return result;
    }
}