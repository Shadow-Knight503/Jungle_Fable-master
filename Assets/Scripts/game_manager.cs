using UnityEngine;
using UnityEngine.SceneManagement;



public class game_manager : MonoBehaviour
{

    public GameObject endpanel_win;
    public GameObject endpanel_lost;
    public GameObject pause_panel;
    public GameObject pause_button;


    public void Pause()
    {
        pause_panel.SetActive(true);
        pause_button.SetActive(false);
        
    }

    public void Resume()
    {
        pause_panel.SetActive(false);
        pause_button.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void Endgame(bool win) {
        if (win) {
            endpanel_win.SetActive(true);
            if (SceneManager.GetActiveScene().buildIndex > PlayerPrefs.GetInt("LvlsUnlocked")) {
                PlayerPrefs.SetInt("LvlsUnlocked", SceneManager.GetActiveScene().buildIndex + 1);                
            }
        } else if (!win) {
            endpanel_lost.SetActive(true);
        }
    }

    public void LoadHome () {
        SceneManager.LoadScene("HomePage");
    }

    public void LoadLevel () {
        SceneManager.LoadScene("Level_Page");
    }
}
