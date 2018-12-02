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

        float new_pos = Mathf.Lerp(transform.position.x, pos.x, 0.65f);
        pos.x = new_pos;
        transform.position = pos;

    }
}
