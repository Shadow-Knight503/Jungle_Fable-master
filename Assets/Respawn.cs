using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    public Player player;
    public AIPlayer aiPlayer;
    public Player2 player2;
    public Player3 player3;
    public Player4 player4;
    public Transform PlayerPoint;
    public Transform AIPlayerPoint;
    public Transform Player2Point;
    public Transform Player3Point;
    public Transform Player4Point;
    public Transform RespawnPoint;
    public int RP;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider Col)
    {
        if (Col.tag == "Player" && player.steps == 0)
        {
            PlayerPoint.transform.position = RespawnPoint.transform.position;
            player.routePosition = RP;
        }
        if (Col.tag == "AIPlayer" && aiPlayer.steps == 0)
        {
            AIPlayerPoint.transform.position = RespawnPoint.transform.position;
            aiPlayer.routePosition = RP;
        }
        if (Col.tag == "Player2" && player2.steps == 0)
        {
            Player2Point.transform.position = RespawnPoint.transform.position;
            player2.routePosition = RP;
        }
        if (Col.tag == "Player3" && player3.steps == 0)
        {
            Player3Point.transform.position = RespawnPoint.transform.position;
            player3.routePosition = RP;
        }
        if (Col.tag == "Player4" && player4.steps == 0)
        {
            Player4Point.transform.position = RespawnPoint.transform.position;
            player4.routePosition = RP;
        }
    }
}
