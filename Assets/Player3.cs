using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player3 : MonoBehaviour
{
    public Route currentRoute;
    public int routePosition;
    public int steps;
    public bool isMoving;
    public bool Rolled = false;
    public CamScript Cam;
    public TextMeshProUGUI DiceTxt;
    public DiceShow DShow;
    public Player Play;
    int Num;
    bool FMove = false;
    public bool TrueRolled = false;
    public int PSs;
    public int PSe;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!TrueRolled && Rolled && Play.PS == PSs && !isMoving) {
            if(steps == 6) {
                TrueRolled = true;
                DiceTxt.text = "You can move now!";
            }
            DiceTxt.text = "Roll 6 to move";
            isMoving = false;
            Play.PS = 2;
            Rolled = false; 
            DiceTxt.text = "Ai's Turn";
        } 
        if(TrueRolled && Rolled && !isMoving && Play.PS == PSs) {
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

    IEnumerator Move()
    {
        if (isMoving)
        {
            yield break;
        }
        isMoving = true;

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
        isMoving = false;
        Play.PS = PSe;
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }
}
