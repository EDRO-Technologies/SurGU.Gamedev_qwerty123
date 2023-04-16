using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaivour : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void ChageFOV(float fov)
    {
        Camera.main.fieldOfView = fov;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
