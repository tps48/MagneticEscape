using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class TeleportScript : MonoBehaviour
{
    [SerializeField] private GameObject plate;
    [SerializeField] private Material materialOn;
    [SerializeField] private Material materialOff;
    [SerializeField] private string destination;

    public bool showText;
    public float startTime;
    public float endTime;
    public bool stopTime;
    


    void Start()
    {
        showText = false;
        startTime = Time.time;
        stopTime = false;
    }

    void OnCollisionEnter(Collision col)
    {
        plate.GetComponent<MeshRenderer>().material = materialOn;
        stopTime = true;
        StartCoroutine(Teleport());
    }

    //   void OnCollisionExit(Collision collisionInfo)
    //  {
    //      plate.GetComponent<MeshRenderer>().material = materialOff;
    //  }

    void OnGUI()
    {
        if (showText)
        {
            if (endTime - startTime < 90)
            {
                GUI.Label(new Rect(450, 100, 200f, 200f), "Your grade: S!");
            }
            else if (endTime - startTime > 90 && endTime - startTime < 120)
            {
                GUI.Label(new Rect(450, 100, 200f, 200f), "Your grade: A!");
            }
            else if (endTime - startTime > 120 && endTime - startTime < 150)
            {
                GUI.Label(new Rect(450, 100, 200f, 200f), "Your grade: B!");
            }
            else if (endTime - startTime > 150 && endTime - startTime < 180) 
            {
                GUI.Label(new Rect(450, 100, 200f, 200f), "Your grade: C!");
            }
            else if (endTime - startTime > 180)
            {
                GUI.Label(new Rect(450, 100, 200f, 200f), "Your grade: D!");
            }
        }
    }

    void Update()
    {
        if (stopTime == false)
        {
            endTime = Time.time;
        }
         
    }

    private IEnumerator Teleport()
    {
        showText = true;
        yield return new WaitForSeconds(5.0f);
        showText = false;
        SceneManager.LoadScene("" + destination);
    }
}
