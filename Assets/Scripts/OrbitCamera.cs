using UnityEngine;
using System.Collections;

// maintains position offset while orbiting around target

public class OrbitCamera : MonoBehaviour {
	[SerializeField] private Transform target;

	public float rotSpeed = 3f;

	private float _rotY;
	private Vector3 _offset;

	// Use this for initialization
	void Start() {
		_rotY = transform.eulerAngles.y;
		_offset = target.position - transform.position;
	}
	
	// Update is called once per frame
	void LateUpdate() {
		
		transform.position = target.position + new Vector3(0, 30, 0);
	
	}
}
