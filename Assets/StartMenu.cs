using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {
    public void StartGame() {
        print("Starting game");
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        print("quitting game");
        Application.Quit();
    }
}
