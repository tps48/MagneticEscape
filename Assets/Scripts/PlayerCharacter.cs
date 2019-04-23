using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;
    public Vector2 pos = new Vector2(Screen.width-200, Screen.height-400);
    public Vector2 size = new Vector2(600, 200);
    private Texture2D emptyTex;
    private Texture2D fullTex;
    private Animator _animator;
    private FPSInput _fpsInput;

    void Start() {
		_health = 5;
        _animator = GetComponent<Animator>();
        _fpsInput = GetComponent<FPSInput>();
	}

	public void Hurt(int damage) {
		_health -= damage;
		Debug.Log("Health: " + _health);
        if (_health <= 0)
        {
            StartCoroutine(Die());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (_health > 0)
        {
            if (collision.gameObject.name == "Fireball")
            {
                Hurt(1);
            }
            else if (collision.gameObject.name == "Enemy")
            {
                Hurt(5);
            }
        }
    }

    void OnGUI()
    {
        int maxHealth = _health;
        if (maxHealth < 0) maxHealth = 0;
        GUI.skin.label.fontSize = 100;
        GUI.contentColor = Color.yellow;
        GUI.Label(new Rect(Screen.width - 500, 0, 1000, 250), "Health: " +maxHealth);
    }

    private IEnumerator Die()
    {
        _fpsInput.alive = false;
        if (_health == 0)
        {
            _animator.SetTrigger("Death");
        }
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
