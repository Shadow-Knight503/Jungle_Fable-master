using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HomePage : MonoBehaviour {

    public void QuitGame() {
        Application.Quit();
    }

    public void LevelPage() {
        SceneManager.LoadScene("Level_Page");
    }
}
