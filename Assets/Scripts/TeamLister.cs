using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TeamLister : MonoBehaviour
{

    public List<int> enemyList = new List<int>();
    public List<int> allyList = new List<int>();
    private int allyTurnid;
    private int enemyTurnId;
    public string whoseTurn;
    public int turn;
    // Start is called before the first frame update
    void Start()
    {
        allyTurnid = 0;
        enemyTurnId = 0;
        turn = 1;
        whoseTurn = "ally";
    }

    public void GetTurnData(string role, int teamId)
    {
        if (role == "ally") { allyTurnid = teamId; }
        else { enemyTurnId = teamId; }
        if (allyTurnid != 0 && enemyTurnId != 0)
        {
            Entity ally = GameObject.Find("Ally " + allyTurnid.ToString()).GetComponent<Entity>();
            ally.Attack(enemyTurnId);
        }
    }

    public void NextTurn()
    {
        turn++;
        GameObject.Find("Turn").GetComponent<Text>().text = turn.ToString();
        if (whoseTurn == "enemy")
        {
            GameObject.Find("TurnOwner").GetComponent<Text>().text = "Ваш ход";
            whoseTurn = "ally";
            Entity ally = GameObject.Find("Ally " + allyTurnid.ToString()).GetComponent<Entity>();
            //Entity enemy = GameObject.Find("Enemy " + enemyTurnId.ToString()).GetComponent<Entity>();
            //ally.Attack(enemyTurnId);
            allyTurnid = 0;
            enemyTurnId = 0;
        }
        else
        {
            GameObject.Find("TurnOwner").GetComponent<Text>().text = "Ход противника";
            whoseTurn = "enemy";
            allyTurnid = Random.Range(1, allyList.Count);
            enemyTurnId = Random.Range(1, enemyList.Count);
            GameObject.Find("Enemy " + enemyTurnId.ToString()).GetComponent<Entity>().Attack(allyTurnid);
        }
    }

    public void AddAlly(int teamId)
    {
        allyList.Add(teamId);
    }

    public void DeleteAlly(int teamId)
    {
        allyList.Remove(teamId);
    }

    public void AddEnemy(int teamId)
    {
        enemyList.Add(teamId);
    }

    public void DeleteEnemy(int teamId)
    {
        
        enemyList.Remove(teamId);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
