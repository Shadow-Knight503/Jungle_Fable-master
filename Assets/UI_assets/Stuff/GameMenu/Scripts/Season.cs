using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Season : MonoBehaviour
{
    // Start is called before the first frame update
    public void nextSeason(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
     
}
