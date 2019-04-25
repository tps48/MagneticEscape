using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

// basic WASD-style movement control
// commented out line demonstrates that transform.Translate instead of charController.Move doesn't have collision detection

[RequireComponent(typeof(CharacterController))]
[AddComponentMenu("Control Script/FPS Input")]
public class FPSInput : MonoBehaviour {
    [SerializeField] Canvas _canvas;
	public const float baseSpeed = 6.0f;
	public float speed = 6.0f;
	public float gravity = -9.8f;
	private CharacterController _charController;
    private Animator _animator;
    public bool alive;
    public bool pauseVisible;

    public void unPause()
    {
        pauseVisible = false;
        _canvas.gameObject.SetActive(pauseVisible);
    }

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
        _animator = GetComponent<Animator>();
        alive = true;
        pauseVisible = false;
        _canvas.gameObject.SetActive(pauseVisible);
    }
	
	void Update() {
        if (alive && !pauseVisible)
        {

            //transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
            float deltaX = Input.GetAxis("Horizontal") * speed;
            float deltaZ = Input.GetAxis("Vertical") * speed;
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 movement = new Vector3();
            if (Input.GetKey(KeyCode.W))
            {
                movement.z = speed;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                movement.z = -1 * speed;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                movement.x = speed;
            }
            else if (Input.GetKey(KeyCode.A))
            {
                movement.x = -1 * speed;
            }

            movement = Vector3.ClampMagnitude(movement, speed);

            if (Mathf.Abs(movement.x) >= 0.01 || Mathf.Abs(movement.z) >= 0.01)
            {
                float angle = Vector3.Angle(mousePos, movement);
                if ((angle < 90) || (angle > -45 && angle < 0))
                {
                    _animator.SetFloat("Forward", 1);
                }
                /*else if((angle > 45 && angle < 135))
                {
                    _animator.SetFloat("Right", 1);
                }
                else if ((angle < -45 && angle > -135))
                {
                    _animator.SetFloat("Left", 1);
                }*/
                else if ((angle > 90 || angle < -135))
                {
                    _animator.SetFloat("Backward", 1);
                }
            }
            else
            {
                _animator.SetFloat("Forward", 0);
                _animator.SetFloat("Backward", 0);
                _animator.SetFloat("Left", 0);
                _animator.SetFloat("Right", 0);
            }


            movement.y = gravity;

            movement *= Time.deltaTime;
            //movement = transform.TransformDirection(movement);
            _charController.Move(movement);
        }

        if (Input.GetKeyDown("escape"))
        {
            pauseVisible = !pauseVisible;
            _canvas.gameObject.SetActive(pauseVisible);
        }


    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void OnSpeedChanged(float value) {
		speed = baseSpeed * value;
	}
}
