using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	private Text text;
	public float speed = 45.0f;
	public float padding = 1f;
	public GameObject lazerPrefab;
	public float beamSpeed;
	public float fireRate = 0.3f;
	float xmin  ;
	float xmax ;
	public float playerHealth = 250f;
	public AudioClip playerLazer;
	public AudioClip playerExplodes;

	private ScoreKeeper scoreKeeper;
	 
	void Start ()
	{ 
		
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
		//Using the camera to find the endpoints for the playspace.
		float distance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftMost = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, distance));
		Vector3 rightMost = Camera.main.ViewportToWorldPoint (new Vector3 (1, 0, distance));
		
		//Determine the min and maz position for the border positions.
		xmin = leftMost.x + padding;
		xmax = rightMost.x - padding;
	
		
	}
	void Fire ()
	{
		Vector3 offset = this.transform.position + new Vector3 (0f, 1f, 0f);
		GameObject beam = Instantiate (lazerPrefab, offset, Quaternion.identity) as GameObject;
		
		beam.GetComponent<Rigidbody2D>().velocity = new Vector3 (0, beamSpeed, 0);
		AudioSource.PlayClipAtPoint (playerLazer, transform.position, 1.2f);
	}
	void Update ()
	{
	    //change the position of the enemy.
		if (Input.GetKey (KeyCode.LeftArrow)) {
		
			//transform.position += new Vector3 (-speed * Time.deltaTime, 0, 0);
			
			transform.position += Vector3.left * speed * Time.deltaTime;
			
		
		} else if (Input.GetKey (KeyCode.RightArrow)) {
		
	         
			//transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
			
			transform.position += Vector3.right * speed * Time.deltaTime;
			
			
		}
		// restrict the player movement.
		float newX = Mathf.Clamp (transform.position.x, xmin, xmax);
		
		transform.position = new Vector3 (newX, transform.position.y, transform.position.z);
		
		if (Input.GetKeyDown (KeyCode.Space)) {
			InvokeRepeating ("Fire", 0.000001f, fireRate);
			
		}
		if (Input.GetKeyUp (KeyCode.Space)) {
			CancelInvoke ("Fire");
		}
	}
	void OnTriggerEnter2D (Collider2D coll)
	{
		Projectile missile = coll.gameObject.GetComponent<Projectile> ();
		if (missile) {
			playerHealth -= missile.GetDamage ();
	
			missile.Hit ();
		
			if (playerHealth <= 0) {
				Die ();
			}
			
		}
	}
	void Die ()
	{
		LevelManager man = GameObject.Find ("LevelManager").GetComponent<LevelManager> ();
		man.loadLevel ("Win");
		Destroy (gameObject);
		
	}
	void DisplayHealth ()
	{
		Text text = GetComponent<Text> ();
		text.text = playerHealth.ToString ();
	
	}
	
	
}