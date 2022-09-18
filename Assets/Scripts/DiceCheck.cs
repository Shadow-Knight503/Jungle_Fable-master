using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DiceCheck : MonoBehaviour {
    public bool OnGround;
    public int DiceSide;
    public bool Logged = false; 
    public TextMeshProUGUI DiceTxt;
    public DiceScript Dice;
    public Player Play1;
    public AIPlayer AiPlay; 
    public CamScript Cam;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LogChange() {
        Logged = false;
    }

    public void OnTriggerStay(Collider Col) {
        if (Col.tag == "Ground" && !Logged && Dice.Rb.IsSleeping() && Dice.Landed && Dice.Thrown) {
            OnGround = true;
            Logged = true;
            Debug.Log("PS: " + Play1.PS);
            if (Play1.PS == 0) {
                Play1.steps = DiceSide;
                Play1.Rolled = true;
            } else if (Play1.PS == 1) {
                Debug.Log("Ai Works " + DiceSide.ToString());
                AiPlay.steps = DiceSide;
                AiPlay.Rolled = true;
                AiPlay.Rolling = false;
            }
            Cam.Focus_Obj = "Player1";
        }
    }

    public void OnTriggerExit(Collider Col) {
        if (Col.tag == "Ground") {
            OnGround = false;
        }
    }
}
