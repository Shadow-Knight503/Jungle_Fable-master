using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;
    public int steps;
    public bool isMoving;
    public bool Rolled = false;
    public int PS;
    public CamScript Cam;
    public TextMeshProUGUI DiceTxt;
    public DiceShow DShow;
    public AudioSource StartSound;
    public GameObject[] UserNames;
    public int TtlNoNames;
    int Num;
    bool FMove = false;
    public bool TrueRolled = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (!TrueRolled && Rolled && PS == 0 && !isMoving) {
            if(steps == 6) {
                TrueRolled = true;
            }
            isMoving = false;
            PS = 1;
            Rolled = false; 
            for (int i = 0; i < TtlNoNames; i++) {
                UserNames[i].SetActive(false);
            }
            UserNames[1].SetActive(true);
        } 
        if(TrueRolled && Rolled && !isMoving && PS == 0) {
            FMove = false;
            
            if (routePosition + steps < currentRoute.childNodeList.Count) {
                DShow.DiceTurn(steps);
                StartCoroutine(Move());
            } else {
                Debug.Log("Rolled Number is too high");
                DiceTxt.text = "Num too high";
                steps = 0;
                StartCoroutine(Move());
            }
            Rolled = false; 
        }
    }

    IEnumerator Move() {
        if(isMoving) {
            yield break;
        }
        isMoving = true;
        StartSound.Play();
        while(steps>0) {
            Vector3 nextPos = currentRoute.childNodeList[routePosition + 1].position;
            while(MoveToNextNode(nextPos))
            {
                yield return null;
            }
            yield return new WaitForSeconds(0.1f);
            steps--;
            routePosition++;
        }
        if (FMove) {
            while(Num > 0) {
                Vector3 nextPos = currentRoute.childNodeList[routePosition - 1].position;
                while(MoveToNextNode(nextPos))
                {
                    yield return null;
                }
                yield return new WaitForSeconds(0.1f);
                steps--;
                routePosition--;
            }
        }
        yield return new WaitForSeconds(0.5f);
        Cam.Focus_Obj = "PlayerAi";
        isMoving = false;
        PS = 1;
        for (int i = 0; i < TtlNoNames; i++) {
            UserNames[i].SetActive(false);
        }
        UserNames[1].SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal) {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }
}
