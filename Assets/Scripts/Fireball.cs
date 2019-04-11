using UnityEngine;
using System.Collections;

public class Fireball : MonoBehaviour {
	public int speed = 1000;
	public int damage = 1;
    public float height = 1;
    Rigidbody body;


    private void Start()
    {
        body = GetComponent<Rigidbody>();
        body.AddForce(transform.forward * speed);
    }

    private void Update()
    {
        float x = transform.position.x;
        float z = transform.position.z;
        transform.position = new Vector3(x, height, z);
    }

    void OnTriggerEnter(Collider other) {
		PlayerCharacter player = other.GetComponent<PlayerCharacter>();
		if (player != null) {
			player.Hurt(damage);
		}
		Destroy(this.gameObject);
	}
}
