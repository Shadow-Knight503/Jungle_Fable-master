using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Player2 : MonoBehaviour
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
    public GameObject[] UserNames;
    public int TtlNoNames;
    int Num;
    bool FMove = false;
    public bool TrueRolled = false;
    public int PSs;
    public int PSe;
    public bool Alive = false;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update() {
        if (!TrueRolled && Rolled && Play.PS == PSs && !isMoving) {
            if(steps == 6) {
                TrueRolled = true;
            }
            isMoving = false;
            Play.PS = PSe;
            Rolled = false; 
            for (int i = 0; i < TtlNoNames; i++) {
                UserNames[i].SetActive(false);
            }
            UserNames[PSe].SetActive(true);
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
        for (int i = 0; i < TtlNoNames; i++) {
            UserNames[i].SetActive(false);
        }
        UserNames[PSe].SetActive(true);
    }

    bool MoveToNextNode(Vector3 goal)
    {
        return goal != (transform.position = Vector3.MoveTowards(transform.position, goal, 8f * Time.deltaTime));
    }
}
