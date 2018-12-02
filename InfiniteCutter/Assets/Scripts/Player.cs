using UnityEngine;
using System.Collections.Generic;

public class Player:MonoBehaviour {

    [SerializeField] float speed = 1f;
    [SerializeField] Rigidbody rigidbody;
    [SerializeField] AudioClip bump;
    [SerializeField] AudioSource audioSource;
    [SerializeField] GameManager gameManager;
    [SerializeField] MeshCollider meshCollider;
    [SerializeField] MeshFilter meshFilter;
    [SerializeField] Mesh cube;
    private const string kTagObstacle = "Obstacle";
    private List<GameObject> alreadyHit;
    private int Life = 4;
    private float maxSpeed = 2.0f;
    

    // Use this for initialization
    void Start() {
        alreadyHit = new List<GameObject>();
        Life = 4;
}

    // Update is called once per frame
    void Update() {
        //transform.Translate(Vector3.right * Time.deltaTime * speed);
        //rigidbody.velocity = new Vector3(speed, rigidbody.velocity.y, rigidbody.velocity.z);
        //rigidbody.AddForce(Vector3.right * speed, ForceMode.Force);
        if (Time.timeScale > 0) {
            Vector3 scale = transform.localScale;

            scale.x *= 1.0015f;
            scale.y *= 1.0015f;
            transform.localScale = scale;
        }
        //Debug.Log(rigidbody.velocity);
        maxSpeed += 0.00001f;
        float speedXMax = Mathf.Min(rigidbody.velocity.x, maxSpeed);
        rigidbody.velocity = new Vector3(speedXMax, rigidbody.velocity.y, rigidbody.velocity.z);
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
            Life--;
            if (Life <= 0) {
                gameManager.ShowGameOver();
            }
        }
    }

    public void Reset() {
        transform.position = new Vector3(-9.25f, -4.16f, 0.02f);
        meshCollider.sharedMesh = cube;
        meshFilter.mesh = cube;
        transform.localScale = new Vector3(1, 1, 1);
    }
}


