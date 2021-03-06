using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	private Rigidbody2D myrigidbody;
	[SerializeField]
	private float movementspeed = 10f;
	[SerializeField]
	private float jumpheigt = 10f;
	public float fallmultiplier = 1.25f;
	private bool isGround;
	private bool facing = true;
	private float horizontal;
	public Transform groundCheck;
	public LayerMask whatIsGround;
	public GameObject PanelLose;
	public GameObject PanelWin;

	void Start ()
	{
		myrigidbody = GetComponent<Rigidbody2D> ();
		SoundManager.PlaySound(SoundManager.Sound.levelMusic);
	}

	bool wishJump;
	private void Update() {
		wishJump = Input.GetKey(KeyCode.Space);
		horizontal = Input.GetAxisRaw("Horizontal");

		if(Input.GetKeyDown(KeyCode.Space))
			SoundManager.PlaySound(SoundManager.Sound.jump);
		
		if(myrigidbody.velocity.y > 0f)
		{
			myrigidbody.velocity += Vector2.up * Physics2D.gravity.y * (fallmultiplier - 1) * Time.deltaTime;
		}
	}
	void FixedUpdate ()
	{
		isGround = Physics2D.OverlapCircle(groundCheck.position, .3f, whatIsGround);
		myrigidbody.velocity = new Vector2 (horizontal * movementspeed, myrigidbody.velocity.y);

		if(wishJump && isGround == true)
		{
			myrigidbody.AddForce (transform.up * jumpheigt, ForceMode2D.Impulse);
		}
		if (horizontal > 0 && !facing) 
		{
			Flip ();
		}
		else if (horizontal < 0 && facing) 
		{
			Flip ();
		}
	}

	private void Flip ()
	{
		facing = !facing;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}

	void Lose()
	{
		myrigidbody.bodyType = RigidbodyType2D.Static;
		PanelLose.SetActive (true);
		SoundManager.PlaySound(SoundManager.Sound.Lose);
		GameAssets.i.DestroyAllAudioSources();
		Destroy (gameObject);
	}

	void Finish ()
	{
		myrigidbody.bodyType = RigidbodyType2D.Static;
		PanelWin.SetActive (true);
		Destroy (gameObject);
	}

	void OnTriggerEnter2D (Collider2D col)
	{
		if(col.tag == "Saw")
		{
			Lose ();
		}
		if(col.tag == "Death")
		{
			Lose ();
		}
		if (col.tag == "Portal")
		{
			Finish ();
		}
	}

	private void OnCollisionEnter(Collision col) {

		if(col.collider.tag == "Ground")
		{
			isGround = true;
		}
		else
		{
			isGround = false;
		}
	}
}
