using UnityEngine;

public class playerMovement : MonoBehaviour
{
	public CharacterController2D controller;

	public float runSpeed = 40f;

	float horizontalMove = 0f;

	float verticalMove = 0f;

	public Animator playerAnimator;
	

	// Update is called once per frame
	void Update()
	{

		horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
		verticalMove = Input.GetAxisRaw("Vertical") * runSpeed;

		if (horizontalMove > 0 || verticalMove > 0)
		{
			playerAnimator.SetBool("IsWalking", true);
		}
		else
		{
			playerAnimator.SetBool("IsWalking", false);
		}
	}

	void FixedUpdate()
	{
		// Move our character
		controller.Move(horizontalMove * Time.fixedDeltaTime, verticalMove * Time.fixedDeltaTime);
	}
}
