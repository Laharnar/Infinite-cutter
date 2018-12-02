using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour {

    [SerializeField] Canvas canvas;

    private void Start() {
        canvas.enabled = true;
    }

    public void StartGame() {
        canvas.enabled = false;
    }
}


