using UnityEngine;
using System.Collections;

public class UI_Controller : MonoBehaviour
{
    public float barDisplay;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(600, 200);
    private Texture2D emptyTex;
    private Texture2D fullTex;

    void OnGUI()
    {
        //emptyTex = Texture2D.blackTexture;
        //fullTex = Texture2D.whiteTexture;
        //emptyTex.Resize(1, 1);
        //fullTex.Resize(1, 1);

        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);


        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    void Update()
    {

        if (barDisplay < 1)
        {
            barDisplay += Time.deltaTime * 0.05f;
        }

    }
}
