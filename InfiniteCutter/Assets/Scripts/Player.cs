using UnityEngine;

public class Player:MonoBehaviour {

    public float speed = 1f;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }

    public void Death() {
        Destroy(gameObject);
    }
}


