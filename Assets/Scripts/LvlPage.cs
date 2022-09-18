using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlPage : MonoBehaviour {
    public GameObject LoadPanel;
    public int LvlsUnlocked;
    public GameObject[] Lvls;
    public GameObject[] Buttons;
    public GameObject PrvBtn;
    public GameObject NxtBtn;
    public int TotalBtns;
    public int Lvli = 0;

    // Start is called before the first frame update
    void Start() {
        LvlsUnlocked = PlayerPrefs.GetInt("LvlsUnlocked", 1);
        Lvli = 0;

        foreach(GameObject Button in Buttons) {
            Button.SetActive(false);
        }
        for (int i = 0; i < LvlsUnlocked; i++) {
            Buttons[i].SetActive(true);
        }

        foreach(GameObject Lvl in Lvls) {
            Lvl.SetActive(false);
        }
        Lvls[0].SetActive(true);

        PrvBtn.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void NxtLvl() {
        if (Lvli + 1 == TotalBtns - 1) {
            NxtBtn.SetActive(false);
        }
        if (Lvli + 1 != 0) {
            PrvBtn.SetActive(true);
        }
        Lvls[Lvli].SetActive(false);
        Lvls[Lvli + 1].SetActive(true);
        Lvli += 1;
    }

    public void PrvLvl() {
        if (Lvli - 1 == 0) {
            PrvBtn.SetActive(false);
        }
        if (Lvli - 1 != TotalBtns - 1) {
            NxtBtn.SetActive(true);
        }
        Lvls[Lvli].SetActive(false);
        Lvls[Lvli - 1].SetActive(true);
        Lvli -= 1;
    }
    
    public void LoadLevel (int LevelNum) {
        StartCoroutine(LoadAsync(LevelNum + 1));
    }

    IEnumerator LoadAsync(int ScnIndx) {
        LoadPanel.SetActive(true);
        AsyncOperation op = SceneManager.LoadSceneAsync(ScnIndx);
        while (!op.isDone) {
            Debug.Log(op.progress);
            yield return null;
        }
    }

    public void LoadHome () {
        SceneManager.LoadScene("HomePage");
    }

    public void QuitGame() {
        Application.Quit();
    }
}
