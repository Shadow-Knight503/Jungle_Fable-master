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
                DiceTxt.text = "You can move now!";
            }
            DiceTxt.text = "Roll 6 to move";
            isMoving = false;
            PS = 1;
            Rolled = false; 
            DiceTxt.text = "Ai's Turn";
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
        DiceTxt.text = "Ai's Turn";
    }

    bool MoveToNextNode(Vector3 goal) {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }
}
