using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour {
	[SerializeField] private GameObject plate;
	[SerializeField] private GameObject door;
	[SerializeField] private Material materialOn;
	[SerializeField] private Material materialOff;
	
	void OnCollisionEnter (Collision col) {
		 plate.GetComponent<MeshRenderer> ().material = materialOn;
		 door.SetActive(false);
    }
	
	void OnCollisionExit(Collision collisionInfo) {
         plate.GetComponent<MeshRenderer> ().material = materialOff;
		 door.SetActive(true);
    }
}
