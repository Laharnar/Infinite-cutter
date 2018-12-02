using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    [SerializeField] Transform player;

	// Update is called once per frame
	void Update () {
        Vector3 pos = player.position;
        pos.y = transform.position.y;
        pos.z = transform.position.z;

        pos = Vector3.Lerp(pos, transform.position, 0.5f);
        transform.position = pos;

    }
}
