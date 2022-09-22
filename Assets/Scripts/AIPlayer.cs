using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AIPlayer : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;
    public int steps;
    bool isMoving;
    public bool Rolled = false;
    public Player player;
    public CamScript Cam;
    public TextMeshProUGUI DiceTxt;
    public GameObject DiceBtn;
    public DiceScript Dice;
    public DiceShow DShow;
    public DiceCheck DiceChk1;
    public DiceCheck DiceChk2;
    public DiceCheck DiceChk3;
    public DiceCheck DiceChk4;
    public DiceCheck DiceChk5;
    public DiceCheck DiceChk6;
    public AudioSource StartSound;
    public GameObject[] UserNames;
    public int TtlNoNames;
    public bool TrueRolled = false;
    public bool Rolling = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() {
        if (!Dice.Thrown && player.PS == 1 && !isMoving && !Rolled && !Rolling) {
            Debug.Log("ROlls " + Dice.Thrown.ToString());
            Dice.RollDice();
            DiceChk1.LogChange();
            DiceChk2.LogChange();
            DiceChk3.LogChange();
            DiceChk4.LogChange();
            DiceChk5.LogChange();
            DiceChk6.LogChange();
            Rolling = true;
        }
        if (!TrueRolled && Rolled && player.PS == 1 && !isMoving) {
            if(steps == 6) {
                TrueRolled = true;
            }
            DiceBtn.SetActive(true);
            isMoving = false;
            player.PS = 0;
            Rolled = false; 
            for (int i = 0; i < TtlNoNames; i++) {
                UserNames[i].SetActive(false);
            }
            UserNames[0].SetActive(true);
        }
        if (TrueRolled && Rolled && player.PS == 1 && !isMoving) {   
            if (Dice.Thrown && Dice.Landed) {
                if (routePosition + steps < currentRoute.childNodeList.Count) {
                    DShow.DiceTurn(steps);
                    StartCoroutine(Move());
                } else {
                    Debug.Log("Rolled Number is too high");
                    DiceTxt.text = "Num too high";
                    steps = 0;
                    StartCoroutine(Move());
                    DiceBtn.SetActive(true);
                }
            }
            
        }
    }

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;
        StartSound.Play();
        while (steps > 0)
        {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while (MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
        yield return new WaitForSeconds(0.5f);
        Cam.Focus_Obj = "DicePlat";
        DiceBtn.SetActive(true);
        isMoving = false;
        player.PS = 0;
        Rolled = false;
        for (int i = 0; i < TtlNoNames; i++) {
            UserNames[i].SetActive(false);
        }
        UserNames[0].SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }
}
