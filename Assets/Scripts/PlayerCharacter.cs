using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
    public Vector2 pos = new Vector2(Screen.width-200, Screen.height-400);
    public Vector2 size = new Vector2(600, 200);
    private Texture2D emptyTex;
    private Texture2D fullTex;

    void Start() {
		_health = 5;
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);
        if (_health <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Fireball")
        {
            Hurt(1);
        }
    }

    void OnGUI()
    {

        /*GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);
        GUI.BeginGroup(new Rect(0, 0, size.x * _health/5, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();*/
    }
}
