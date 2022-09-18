using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiceScript : MonoBehaviour {
    public Rigidbody Rb;
    public bool Thrown;
    public bool Landed;
    public Vector3 InitPos;
    public int DiceVal;
    public Player Play;
    public GameObject DiceBtn;

    // Start is called before the first frame update
    void Start() {
        InitPos = transform.position;
        Rb.useGravity = false;
    }

    // Update is called once per frame
    void Update() {
        if (Rb.IsSleeping() && !Landed && Thrown) {
            Landed = true;
            Rb.useGravity = false; 
            
        } else if (Rb.IsSleeping() && Landed && Thrown) {
            Debug.Log("This is immposible ");
            Invoke("ResetDice", 0.5f);
        }
    }

    public void RollDice() {
        Debug.Log("Rolling ?");
        if (!Thrown && !Landed) {
            DiceBtn.SetActive(false);
            Thrown = true; 
            Debug.Log(Thrown);
            Rb.useGravity = true;
            Rb.AddTorque(Random.Range(0, 500), Random.Range(0, 500), Random.Range(0, 500));
            Rb.AddForce(Random.Range(0, 300), Random.Range(0, 5), Random.Range(500, 1000));
            Debug.Log(Thrown);
        } else if (Thrown && Landed) {
            ResetDice();
            RollDice();
        } else if (Thrown && !Landed) {
            ResetDice();
            RollDice();
            DiceBtn.SetActive(true);
        }
    }

    public void ResetDice () {
        Debug.Log("Reseting...");
        transform.position = InitPos;
        if (Landed) {
            Thrown = false;
            Landed = false;
            Rb.useGravity = false;
        }
    }
}
