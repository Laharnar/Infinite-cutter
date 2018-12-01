using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TilePhysicsObject : MonoBehaviour {
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] MeshCollider meshCollider;
    [SerializeField] Sprite sprite;
	// Use this for initialization
	void Start () {
        Mesh meshFromSprite = Helper.SpriteToMesh(sprite);
        meshFilter.mesh = meshFromSprite;
        meshCollider.sharedMesh = meshFromSprite;

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
