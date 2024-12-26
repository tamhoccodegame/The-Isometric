using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
	public float rotationSpeed;

    public float horizontalMove;
    public float verticalMove;
    public Vector3 movement;

    private CharacterController characterController;
    private Animator animator;
	private Vector3 initialCameraForward;
	private Vector3 initialCameraRight;

	// Start is called before the first frame update
	void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

		// Lưu lại hướng của camera ban đầu (khi game bắt đầu)
		Vector3 cameraForward = Camera.main.transform.forward;
		Vector3 cameraRight = Camera.main.transform.right;

		cameraForward.y = 0f; // Loại bỏ trục Y
		cameraRight.y = 0f; // Loại bỏ trục Y

		initialCameraForward = cameraForward.normalized;
		initialCameraRight = cameraRight.normalized;
	}

	// Update is called once per frame
	void Update()
	{
		horizontalMove = Input.GetAxisRaw("Horizontal");
		verticalMove = Input.GetAxisRaw("Vertical");

		movement = horizontalMove * initialCameraRight + verticalMove * initialCameraForward;
		movement.Normalize();

		if (movement.magnitude > 0.01f)
		{
			// Quay nhân vật về hướng di chuyển mà không ảnh hưởng đến camera
			Quaternion toRotation = Quaternion.LookRotation(movement, Vector3.up);
			transform.rotation = Quaternion.Lerp(transform.rotation, toRotation, rotationSpeed * Time.deltaTime);
		}


		characterController.Move(movement * speed * Time.deltaTime);
		animator.SetBool("isRunning", movement.magnitude > 0f);

	}

}
