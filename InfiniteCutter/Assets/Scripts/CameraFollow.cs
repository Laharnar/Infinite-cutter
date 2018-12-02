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

        Vector3 new_pos = Vector3.Lerp(transform.position, pos, 0.2f);
        transform.position = new_pos;

    }
}
