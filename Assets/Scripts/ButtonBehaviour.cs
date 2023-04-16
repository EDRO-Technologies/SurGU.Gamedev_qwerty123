using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBehaviour : MonoBehaviour
{

    public string role;
    public int teamId;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TransferTurnData()
    {
        GameObject.Find("TeamList").GetComponent<TeamLister>().GetTurnData(role, teamId);
    }
}
