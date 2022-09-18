using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinTrig : MonoBehaviour {
    public Player Play1;
    public AIPlayer PlayAi;
    public game_manager Manager;
    bool Win;


    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void OnTriggerEnter (Collider Col) {
        Play1.enabled = false;
        PlayAi.enabled = false;
    }

    void OnTriggerStay(Collider Col) {
        if (Col.tag == "Player" || Col.tag == "Player2" || Col.tag == "Player3" || Col.tag == "Player4") {
            Debug.Log("Won");
            Win = true;
            Invoke("EndGame", 2f);
        } else if (Col.tag == "AIPlayer") {
            Debug.Log("Lost");
            Win = false;
            Invoke("EndGame", 2f);
        }
    }

    void EndGame() {
        Manager.Endgame(Win);
    }
}
