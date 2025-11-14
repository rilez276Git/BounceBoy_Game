using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dashing : MonoBehaviour
{
   
	[Header("Refernces")]
	public Transform orientation;
	public Transform playerCam;
	private Rigidbody rb;
	private MoveController pm;

	[Header("Dashing")]
	public float dashForce;
	public float dashUpwardForce;
	public float dashDuration;

	[Header("Settings")]
	public bool useCameraForward = true;
	public bool allowAllDirections = true;
	public bool disableGravity = false;
	public bool resetVel = true;

	[Header("Cooldown")]
	public float dashCd;
	private float dashCdTimer;

	[Header("Input")]
	public KeyCode dashKey = KeyCode.E;

	public Image dashCooldownBar;
	public float dashCooldown;
	public float dashMaxCooldown;

	public AudioSource audioSrc;
	public AudioClip dash;

	public void Start()
	{
		rb = GetComponent<Rigidbody>();
		pm = GetComponent<MoveController>();
		dashCooldown = 0.0f;
	}

	public void Update()
	{

		dashCooldown -= Time.deltaTime;

         if (dashCooldown < 0.0f)
			{
				dashCooldown = 0.0f;
			}

		if (Input.GetKeyDown(dashKey))
		{
			Dash();
		}

		if(dashCdTimer > 0)
			dashCdTimer -= Time.deltaTime;

		dashCooldownBar.fillAmount = (float)dashCooldown;
	}

	public void Dash()
	{
		if (dashCdTimer > 0) return;
		else dashCdTimer = dashCd;

		Transform forwardT;
		
		if (useCameraForward)
			forwardT = playerCam;
		else	
			forwardT = orientation;

		Vector3 direction = GetDirection(forwardT);

		Vector3 forceToApply = direction * dashForce + orientation.up * dashUpwardForce;

		rb.AddForce(forceToApply, ForceMode.Impulse);

		Invoke(nameof(ResetDash), dashDuration);

		dashCooldown = 1f;

		audioSrc.clip = dash;
		audioSrc.Play();
	}

	public void ResetDash()
	{
		
	}

	public Vector3 GetDirection(Transform forwardT)
	{		
		float horizontalInput = Input.GetAxisRaw("Horizontal");
		float verticalInput = Input.GetAxisRaw("Vertical");

		Vector3 direction = new Vector3();

		if (allowAllDirections)
			direction = forwardT.forward * verticalInput + forwardT.right * horizontalInput;
		else	
			direction = forwardT.forward;

		if (verticalInput == 0 && horizontalInput == 0)
			direction = forwardT.forward;

		return direction.normalized;
	}
}
