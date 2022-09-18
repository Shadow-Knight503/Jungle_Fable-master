using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class MAINMENU : MonoBehaviour
{
    // Start is called before the first frame update
    public void pg(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    public void quitGame(){
        Debug.Log("QUIT!");
        Application.Quit();
    }
}
