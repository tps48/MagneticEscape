using UnityEngine;

public class ResizeTile : MonoBehaviour {
    Renderer rend;

    void Start() {
        rend = GetComponent<Renderer>();
        // Animates main texture scale in a funky way!
        float scaleX = GetComponent<Renderer>().bounds.size[0];
        float scaleY = GetComponent<Renderer>().bounds.size[2];
		Debug.Log(GetComponent<Renderer>().bounds.size);
        rend.material.mainTextureScale = new Vector2(scaleX, scaleY);
    }
}