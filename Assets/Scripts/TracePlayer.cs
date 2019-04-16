using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TracePlayer : MonoBehaviour
{
    public GameObject player;
    public float range;
    Vector3 distance;
    Vector3 playerposition;


    // Start is called before the first frame update
    void Start()
    {
        range = 500.0f;
        player = GameObject.Find("Player");
       
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.transform.position - this.transform.position).sqrMagnitude < range)
        {
            transform.LookAt(player.transform);
        }


    }
}
