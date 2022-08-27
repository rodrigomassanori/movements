using UnityEngine;

public class movement2 : MonoBehaviour 
{
	CharacterController controller;

	public float Speed = 12f;

	public float gravity = -9.81f;
    
	Vector3 velocity;

	public Transform groundCheck;
    
	public float groundDistance =0.4f;
    
	public LayerMask groundMask;
    
	bool isGrounded;

	Rigidbody m_Rigidbody;

	
	void Awake()
	{
		controller = GetComponent<CharacterController>();
        
		m_Rigidbody = GetComponent <Rigidbody>();
	}

	void Update () 
	{
		//controle
        float x = Input.GetAxis("Vertical");
        
		float z = Input.GetAxis("Horizontal");
        
        Vector3  move = transform.right * x + transform.forward * z;
		
        controller.Move(move * Speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        
		controller.Move(velocity * Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

    	if(isGrounded && velocity.y < 0)
		{
        	velocity.y = -2f;
		}
	}

	void FixedUpdate() 
	{ 
    	if( Input.GetButton("jump"))	
		{
			m_Rigidbody.AddForce(transform.up * m_Thrust);
		}
	}
}