using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager:MonoBehaviour {
    public string gameplayScene = "CuttingTesting";
    public string mainmenuScene = "MainMenu";

    public void LoadGameplay() {
        SceneManager.LoadScene(gameplayScene);
    }

    public void LoadMainMenu() {
        SceneManager.LoadScene(mainmenuScene);
    }
}


