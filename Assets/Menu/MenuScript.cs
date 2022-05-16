using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuScript : MonoBehaviour
{
    public void playGame() {
        SceneManager.LoadScene("MainLevel");
    }
    public void quitGame() {
        Application.Quit();
    }

    public void goToSettingsScene() {
        SceneManager.LoadScene("Settings");
    }
    public void goToMainMenuScene() {
        SceneManager.LoadScene("Menu");
    }
}
