using UnityEngine;

public class Trap:MonoBehaviour {
    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.GetComponent<SlicingMechanic>()) {
            // trap activated.
            collision.gameObject.GetComponent<Player>().Death();
        }
    }
}


