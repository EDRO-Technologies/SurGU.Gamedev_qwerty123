using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public int hp;
    public string role;
    public int teamId;
    public bool isAlive;
    public string status;
    

    // Start is called before the first frame update
    void Start()
    {
        status = "idle";
        isAlive = true;
        
    }

    public void Damaged(int damage)
    {
        status = "attacking_move";
        if (damage >= hp)
        {
            hp = 0;
            Death();
        }
        else
        {
            hp -= damage;
        }
        Debug.Log(role + teamId.ToString() + " " + hp.ToString() + " " + damage.ToString());
    }

    public void Attack(int teamId)
    {   
        if (role == "enemy") { GetComponent<Foe>().DoOnAttack(true);  }
        else { GetComponent<Ally>().DoOnAttack(true); }
        Camera cam = Camera.main;
        cam.fieldOfView = 24.0f;
        //if (status == "idle") { return; }
        GameObject target;
        status = "attacking_move";
        if (role == "ally")
        {
            int target_id = GameObject.Find("TeamList").GetComponent<TeamLister>().enemyList[teamId - 1];
            target = GameObject.Find("Enemy " + target_id.ToString());
        }
        else
        {
            int target_id = GameObject.Find("TeamList").GetComponent<TeamLister>().allyList[teamId - 1];
            target = GameObject.Find("Ally " + target_id.ToString());
        }

        if (target.GetComponent<Entity>())
        {
            target.GetComponent<Entity>().Damaged(5);
        }
    }

    void Death()
    {
        isAlive = false;

        //this.gameObject.SetActive(false);
        print("literraly death");
        if (role == "ally")
        {
            GameObject.Find("TeamList").GetComponent<TeamLister>().DeleteAlly(teamId);
        }
        else
        {
            GameObject.Find("TeamList").GetComponent<TeamLister>().DeleteEnemy(teamId);
        }

        Debug.Log("Death: " + role + teamId.ToString());
        status = "dying";
        if (role == "enemy") { GetComponent<Foe>().DoOnDeath(); }
        else { GetComponent<Ally>().DoOnDeath(); }
    }

    // Update is called once per frame
    void Update()
    {
        if (status == "dying")
        {

        }
    }
}
