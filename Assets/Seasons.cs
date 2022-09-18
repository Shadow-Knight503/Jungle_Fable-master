using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Seasons : MonoBehaviour
{
    public int Sea;

    public void SeasonsLevel()
    {
        SceneManager.LoadScene(Sea);

    }
}
