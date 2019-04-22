using UnityEngine;

public class MenuTiling : MonoBehaviour
{
    // Scroll main texture based on time

    float scrollSpeed = 0.5f;
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer> ();
    }

    void Update()
    {
        // Animates main texture scale in a funky way!
        float scaleX = Time.time * 0.5f + 1;
        float scaleY = Mathf.Sin(Time.time) * 0.5f + 1;
        rend.material.SetTextureOffset("_MainTex", new Vector2(scaleX, scaleY));
    }
}