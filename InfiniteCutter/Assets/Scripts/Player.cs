using UnityEngine;
using System.Collections.Generic;

public class Player:MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] AudioClip bump;
    [SerializeField] AudioSource audioSource;
    private const string kTagObstacle = "Obstacle";
    private List<GameObject> alreadyHit;
    

    // Use this for initialization
    void Start() {
        alreadyHit = new List<GameObject>();
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

    private void OnCollisionEnter(Collision collision) {
        GameObject go = collision.gameObject;
        if (!alreadyHit.Contains(go) && go.tag == kTagObstacle) {
            alreadyHit.Add(go);
            Debug.Log("Hit");
            audioSource.PlayOneShot(bump);
        }
    }
}


