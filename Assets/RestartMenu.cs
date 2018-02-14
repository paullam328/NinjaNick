using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartMenu : MonoBehaviour {
    public GameObject restartMenuUI;

    public void StartGame() {
        print("Starting game");
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        print("quitting game");
        Application.Quit();
    }

}
