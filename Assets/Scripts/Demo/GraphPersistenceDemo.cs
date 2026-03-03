using UnityEngine;
using System.IO;

public class GraphPersistenceDemo : MonoBehaviour
{
    public BlockGraphExecutor Executor;

    private string SavePath => Path.Combine(Application.persistentDataPath, "graph.json");
    //private string SavePath => Path.Combine(Application.dataPath, "graph.json");

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Save()
    {
        string json = GraphSerializer.Export(Executor.Blocks);
        File.WriteAllText(SavePath, json);
        Debug.Log("Graph saved to: " + SavePath);
    }

    public void Load()
    {
        if (!File.Exists(SavePath))
        {
            Debug.LogWarning("No save file found.");
            return;
        }

        string json = File.ReadAllText(SavePath);
        Executor.ClearScene();
        Executor.Blocks = GraphSerializer.Import(json);
        Debug.Log("Graph loaded.");
        Executor.Execute("create_cube");
        
    }
}