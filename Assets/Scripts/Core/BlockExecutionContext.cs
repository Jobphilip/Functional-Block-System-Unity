using System.Collections.Generic;
using UnityEngine;

public class BlockExecutionContext
{
    public Dictionary<string, float> Variables = new();
    public Dictionary<string, GameObject> SceneObjects = new();

    public GameObject GetObject(string id)
    {
        return SceneObjects.ContainsKey(id) ? SceneObjects[id] : null;
    }
}