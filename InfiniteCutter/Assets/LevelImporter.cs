using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelImporter : MonoBehaviour {

    [SerializeField] TextAsset level;

	// Use this for initialization
	void Start () {
        Debug.Log(level.text);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
