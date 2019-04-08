using UnityEngine;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
	public const float baseSpeed = 6.0f;

	public float speed = 6.0f;
	public float gravity = -9.8f;

	private CharacterController _charController;

	void Awake() {
		//Keep Player speed constant
		//Messenger<float>.AddListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}
	void OnDestroy() {
		//Keep Player speed constant
		//Messenger<float>.RemoveListener(GameEvent.SPEED_CHANGED, OnSpeedChanged);
	}

	void Start() {
		_charController = GetComponent<CharacterController>();
	}
	
	void Update() {
        //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
        float deltaX = Input.GetAxis("Horizontal") * speed;
        float deltaZ = Input.GetAxis("Vertical") * speed;
		Vector3 movement = new Vector3();
        if (Input.GetKey(KeyCode.W))
        {
            movement.z = speed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            movement.z = -1 * speed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            movement.x = speed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            movement.x = -1 * speed;
        }
        movement = Vector3.ClampMagnitude(movement, speed);

		movement.y = gravity;

		movement *= Time.deltaTime;
		//movement = transform.TransformDirection(movement);
		_charController.Move(movement);


    }

    private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}
}
