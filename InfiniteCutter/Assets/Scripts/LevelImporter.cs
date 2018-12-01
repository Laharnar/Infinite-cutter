using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImporter : MonoBehaviour {

    [SerializeField] TextAsset level;

	// Use this for initialization
	void Start () {
        Debug.Log(level.text);
        Level l = Level.CreateFromJSON(level.text);
        Debug.Log(l.height);
        Debug.Log(l.layers[0].data[0]);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
