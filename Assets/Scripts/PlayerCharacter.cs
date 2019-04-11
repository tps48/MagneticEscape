using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class PlayerCharacter : MonoBehaviour {
	private int _health;

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
}
