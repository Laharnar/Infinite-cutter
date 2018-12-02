using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bigButton : MonoBehaviour {

    
    [SerializeField] GameObject imageRoot;
    [SerializeField] float interval;
    private float time = 0;
    private int direction = 1;

    private void Start() {
        time = 0;
    }

    // Update is called once per frame
    void Update() {
        time += direction * 0.010f;
        if (time < 0 || time > interval) {
            direction *= -1;
        }
        float t = time / interval;
        imageRoot.transform.localScale = new Vector3(1.0f + t / 10.0f, 1.0f + t / 10.0f, 1.0f + t / 10.0f);

    }
}
