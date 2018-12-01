using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class Layer {
    public List<uint> data;      
}

[System.Serializable]
public class Level {
    public int height;
    public int width;
    public List<Layer> layers;

    public static Level CreateFromJSON(string jsonString) {
        return JsonUtility.FromJson<Level>(jsonString);
    }
}