using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Foe : MonoBehaviour
{
    private int multiplier;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private float stayingTime;
    private bool isAttacking;
    // Start is called before the first frame update
    void Start()
    {
        GameObject.Find("TeamList").GetComponent<TeamLister>().AddEnemy(this.GetComponent<Entity>().teamId);
        multiplier = 1;
        startPosition = transform.position;
        endPosition = startPosition + new Vector3(2 * multiplier, 0, 0);
    }

    public void DoOnAttack(bool attacking)
    {
        isAttacking = attacking;
    }

    public void DoOnDeath()
    {
       
    }

    // Update is called once per frame
    void Update()
    {   
        if (!GetComponent<Entity>().isAlive) { return; }
        if (Input.GetKeyDown("t"))
        {
            GetComponent<Entity>().Attack(1);
        }
        switch (GetComponent<Entity>().status)
        {
            case "attacking_move":
                if (transform.position.x < endPosition.x)
                {
                    transform.position += new Vector3(multiplier * 15 * Time.deltaTime, 0, 0);
                }
                else
                {
                    GetComponent<Entity>().status = "attacking_standing";
                    stayingTime = 2.5f;
                }
                break;

            case "attacking_standing":
                if (stayingTime > 0)
                {
                    stayingTime -= Time.deltaTime;
                }
                else
                {
                    GetComponent<Entity>().status = "attacking_back";
                }
                break;
            case "attacking_back":
                if (transform.position.x > startPosition.x)
                {
                    transform.position += new Vector3(-15 * Time.deltaTime, 0, 0);
                }
                else
                {
                    GetComponent<Entity>().status = "idle";
                    Camera.main.fieldOfView = 30.0f;
                    isAttacking = false;
                }
                break;

        }
    }
}
