using UnityEngine;
using System.Collections;

public class ReactiveTarget : MonoBehaviour {

	Animator anim;
    Rigidbody body;
    public float thrust;


    void Start(){

		anim = GetComponent<Animator>();
	}


	public void ReactToHit(Vector3 playerPosition, int direction) {
        body = GetComponent<Rigidbody>();
        body.AddForce((this.transform.position - playerPosition) * thrust * direction);
	}

}
