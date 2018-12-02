using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour {

    [SerializeField] Canvas canvas;
    [SerializeField] LevelImporter levelImporter;
    [SerializeField] GameObject rootSlicing;

    private void Start() {
        canvas.enabled = true;
        Time.timeScale = 0.0f;
        rootSlicing.SetActive(false);
    }

    public void StartGame() {
        canvas.enabled = false;
        Time.timeScale = 1.0f;
        levelImporter.Reset();
        levelImporter.SpawnFirstChunk();
        rootSlicing.SetActive(true);

    }

    public void ShowGameOver() {
        canvas.enabled = true;
        Time.timeScale = 0.0f;
        rootSlicing.SetActive(false);
    }
}


