using UnityEngine;
using UnityEngine.Events;

public class CharacterControllerTest : MonoBehaviour
{

    private float slopeForce;
    private float slopeForceRayLength;

	[SerializeField] private float m_JumpForce = 400f;                          // Amount of force added when the player jumps.
	[Range(0, 1)] [SerializeField] private float m_CrouchSpeed = .36f;          // Amount of maxSpeed applied to crouching movement. 1 = 100%
	[Range(0, .3f)] [SerializeField] private float m_MovementSmoothing = .0f;  // How much to smooth out the movement
	[SerializeField] private bool m_AirControl = false;                         // Whether or not a player can steer while jumping;
	[SerializeField] private LayerMask m_WhatIsGround;                          // A mask determining what is ground to the character
	[SerializeField] private Transform m_GroundCheck;                           // A position marking where to check if the player is grounded.
	[SerializeField] private Transform m_CeilingCheck;                          // A position marking where to check for ceilings
	[SerializeField] private Collider2D m_CrouchDisableCollider;                // A collider that will be disabled when crouching

	const float k_GroundedRadius = .2f; // Radius of the overlap circle to determine if grounded
	private bool m_Grounded;            // Whether or not the player is grounded.
	const float k_CeilingRadius = .2f; // Radius of the overlap circle to determine if the player can stand up
	private Rigidbody2D m_Rigidbody2D;
	private bool m_FacingRight = true;  // For determining which way the player is currently facing.
	private Vector3 m_Velocity = Vector3.zero;

    public float moveSpeed;
    public float rayYPos;

	[Header("Events")]
	[Space]

	public UnityEvent OnLandEvent;

	[System.Serializable]
	public class BoolEvent : UnityEvent<bool> { }

	public BoolEvent OnCrouchEvent;
	private bool m_wasCrouching = false;

    // private bool OnSlope()
    // {
    //     if(!m_Grounded){
    //         return false;
    //     }

    //     RaycastHit2D hit2D;

    //     if(Physics2D.Raycast(transform.position, Vector3.down, rayYPos  ))
    //     {

    //     }
    // }
    
    private float timeSinceJump;
	private void Awake()
	{
		m_Rigidbody2D = GetComponent<Rigidbody2D>();

		if (OnLandEvent == null)
			OnLandEvent = new UnityEvent();

		if (OnCrouchEvent == null)
			OnCrouchEvent = new BoolEvent();
		
		m_Grounded = true;
	}

	private void Update()
	{	
		if(m_Grounded)
		{
			OnLandEvent.Invoke();
		}

        else
        {
			RaycastHit2D hitInfo;
			hitInfo = Physics2D.Raycast(transform.position - new Vector3(0, rayYPos, 0), Vector3.down, 0.5f);
			Debug.DrawRay(transform.position - new Vector3(0, rayYPos, 0), Vector3.down, Color.magenta);
			if (hitInfo && hitInfo.collider.gameObject.tag == "Ground")
			{   timeSinceJump += Time.deltaTime;
				if(timeSinceJump > 0.1f)
				{	
					//Debug.Log(timeSinceJump);
					m_Grounded = true;
					timeSinceJump = 0;
					OnLandEvent.Invoke();
				}

			}
			Debug.Log(hitInfo.collider.gameObject.tag);
        }
	}

	public void Move(float move, bool crouch, bool jump)
	{
		// If crouching, check to see if the character can stand up
		if (!crouch)
		{
			// If the character has a ceiling preventing them from standing up, keep them crouching
			if (Physics2D.OverlapCircle(m_CeilingCheck.position, k_CeilingRadius, m_WhatIsGround))
			{
				crouch = true;
			}
		}

		//only control the player if grounded or airControl is turned on
		if (m_Grounded || m_AirControl)
		{

			// Move the character by finding the target velocity
			Vector3 targetVelocity = new Vector2(move * moveSpeed, m_Rigidbody2D.velocity.y);
			// And then smoothing it out and applying it to the character
			m_Rigidbody2D.velocity = Vector3.SmoothDamp(m_Rigidbody2D.velocity, targetVelocity, ref m_Velocity, m_MovementSmoothing);

			// If the input is moving the player right and the player is facing left...
			if (move > 0 && !m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
			// Otherwise if the input is moving the player left and the player is facing right...
			else if (move < 0 && m_FacingRight)
			{
				// ... flip the player.
				Flip();
			}
		}
		// If the player should jump...
		if (jump && m_Grounded)
		{
			// Add a vertical force to the player.
			m_Grounded = false;
			transform.position += new Vector3(0, 0f, 0);
			m_Rigidbody2D.AddForce(new Vector2(0f, m_JumpForce));
            timeSinceJump = 0f;
		}
	}


	private void Flip()
	{
		// Switch the way the player is labelled as facing.
		m_FacingRight = !m_FacingRight;
		// Multiply the player's x local scale by -1.
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}
}
