using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour {

    [SerializeField] Canvas canvas;
    [SerializeField] LevelImporter levelImporter;
    [SerializeField] GameObject rootSlicing;
    [SerializeField] Player player;

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
        player.Reset();

    }

    public void ShowGameOver() {
        canvas.enabled = true;
        Time.timeScale = 0.0f;
        rootSlicing.SetActive(false);
    }
}


