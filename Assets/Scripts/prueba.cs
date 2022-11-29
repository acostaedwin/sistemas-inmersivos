using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{
    LineRenderer RayRender;
    GameObject LineObject;

    // Start is called before the first frame update
    void Start()
    {
        RayRender = GameObject.Find("RayInit").GetComponent(typeof(LineRenderer)) as LineRenderer;
        
    }

    // Update is called once per frame
    void Update()
    {
        RayRender.SetPosition(0, new Vector3(0, 0, 0));
        RayRender.SetPosition(0, new Vector3(0, 1, 1));

    }
}
