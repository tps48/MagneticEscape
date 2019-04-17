using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    public GameObject player;
    public bool showText;
    public float range;
    public Vector3 playerposition; 

    void Start()
    {
        showText = false;
        range = 100.0f;
        player = GameObject.Find("Player");
    }

    void Update()
    {
        if (Random.Range(1, 100) == 1)
        {
            if ((player.transform.position - this.transform.position).sqrMagnitude < range)
            {
                range = 0.0f;
                showText = true;
                playerposition = player.transform.position;
                StartCoroutine(Wait());

            }
        }
    }

    void OnGUI()
    {
        if (showText)
        {
           GUI.Label(new Rect(500, 100, 200f, 200f), "Incoming Charge in 3 seconds!");
        }
    }

    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(3.0f);
        showText = false;
        this.transform.position = playerposition;
    }



}
