using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseRotation : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 mousePos = Input.mousePosition;
        //mousePos.z = 0;
        Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);


        transform.LookAt(worldPos);
    }
}
