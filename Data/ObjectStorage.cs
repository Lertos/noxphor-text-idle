using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

public class ObjectStorage
{
    private string filePath;

    public ObjectStorage(string filePath)
    {
        this.filePath = filePath;
    }

    public void StoreObject<T>(T obj, string id)
    {
        Dictionary<string, T> objects = LoadObjects<T>();
        objects[id] = obj;

        SaveObjects(objects);
    }

    public T RetrieveObject<T>(string id)
    {
        Dictionary<string, T> objects = LoadObjects<T>();

        if (objects.ContainsKey(id))
        {
            return objects[id];
        }
        else
        {
            throw new KeyNotFoundException($"Object with ID '{id}' not found.");
        }
    }

    private Dictionary<string, T> LoadObjects<T>()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            return JsonConvert.DeserializeObject<Dictionary<string, T>>(json);
        }
        else
        {
            return new Dictionary<string, T>();
        }
    }

    private void SaveObjects<T>(Dictionary<string, T> objects)
    {
        string json = JsonConvert.SerializeObject(objects, Formatting.Indented);
        File.WriteAllText(filePath, json);
    }
}