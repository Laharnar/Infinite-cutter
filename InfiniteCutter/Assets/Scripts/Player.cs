using UnityEngine;

public class Player:MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody rigidbody;

    // Use this for initialization
    void Start() {
        //rigidbody.velocity = new Vector3(speed, 0,0);
    }

    // Update is called once per frame
    void Update() {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        //rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //rigidbody.AddForce(Vector3.right * speed, ForceMode.Force);
        Vector3 scale = transform.localScale;
        scale.x *= 1.0015f;
        scale.y *= 1.0015f;
        transform.localScale = scale;
    }
    

    public void Death() {
        Destroy(gameObject);
    }
}


