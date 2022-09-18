using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Winter : MonoBehaviour
{
    // Start is called before the first frame update
   public void ws(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
   }
}
