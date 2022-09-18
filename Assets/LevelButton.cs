using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class LevelButton : MonoBehaviour
{
    [HideInInspector] public int levelNum;
    public TextMeshProUGUI buttonText;

    // Start is called before the first frame update
    void Update()
    {
        levelNum = int.Parse(buttonText.text);

    }

    public void LoadLevel()
    {
        SceneManager.LoadScene(levelNum);

    }

}
