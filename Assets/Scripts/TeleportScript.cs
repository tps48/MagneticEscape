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
            int windowWidth = 500;
            int windowHeight = 500;
            int x = (Screen.width - windowWidth) / 2;
            int y = (Screen.height - windowWidth) / 2;
            GUI.skin.label.fontSize = 100;
            GUI.contentColor = Color.blue;
            if (endTime - startTime < 90)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Your grade: S!");
            }
            else if (endTime - startTime > 90 && endTime - startTime < 120)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Your grade: A!");
            }
            else if (endTime - startTime > 120 && endTime - startTime < 150)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Your grade: B!");
            }
            else if (endTime - startTime > 150 && endTime - startTime < 180) 
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Your grade: C!");
            }
            else if (endTime - startTime > 180)
            {
                GUI.Label(new Rect(x, y, windowWidth, windowHeight), "Your grade: D!");
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
