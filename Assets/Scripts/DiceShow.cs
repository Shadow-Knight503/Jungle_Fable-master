using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceShow : MonoBehaviour {
    public GameObject Dice;
    public int DiceNum;
    public float Angle;
    public Quaternion InitPos;

    // Start is called before the first frame update
    void Start() {
        Dice = GameObject.FindWithTag("PlayDice");
        InitPos = Dice.transform.rotation;
    }

    // Update is called once per frame
    void Update() {

    }

    public void DiceTurn(int Num) {
        DiceNum = Num;
        Debug.Log("Shoeww");
        Dice.transform.rotation = InitPos;
        if (DiceNum == 1) {
            Dice.transform.Rotate(0f, 0f, 0f, Space.Self);
        } else if (DiceNum == 2) {
            Dice.transform.Rotate(90f, 0f, 0f, Space.Self);
        }else if (DiceNum == 3) {
            Dice.transform.Rotate(0f, 90f, 0f, Space.Self);
        }else if (DiceNum == 4) {
            Dice.transform.Rotate(0f, -90f, 0f, Space.Self);
        }else if (DiceNum == 5) {
            Dice.transform.Rotate(-90f, 0f, 0f, Space.Self);
        }else if (DiceNum == 6) {
            Dice.transform.Rotate(0f, 180f, 0f, Space.Self);
        }
    }
}
