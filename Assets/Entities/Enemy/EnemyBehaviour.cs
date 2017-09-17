using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour
{ 
	public GameObject attackPrefab;
	public float enemyhealth = 150;
	public float attackSpeed = 10f;
	public float shotsPerSeconds = 0.5f;
	public int scoreValue = 150;
	public AudioClip explosion;
	public AudioClip enemyLazer;
	private ScoreKeeper scoreKeeper;
	public GameObject smoke;
	void Start ()
	{
		scoreKeeper = GameObject.Find ("Score").GetComponent<ScoreKeeper> ();
	}

	void OnTriggerEnter2D (Collider2D collider)
	{
		Projectile missile = collider.gameObject.GetComponent<Projectile> ();
		if (missile) {
			enemyhealth -= missile.GetDamage ();
			missile.Hit ();
			if (enemyhealth <= 0) {
				//this is a really low font and  i cannot really see anything.
				Die ();
				
			}
			
		}
	}
	void Die ()
	{
		AudioSource.PlayClipAtPoint (explosion, transform.position);
		Instantiate (smoke, gameObject.transform.position, Quaternion.identity);
		scoreKeeper.CalculateScore (scoreValue);
		Destroy (gameObject);
	}
	
	void Update ()
	{
		float probability = Time.deltaTime * shotsPerSeconds;
		if (Random.value < probability) {
			Attack ();
			AudioSource.PlayClipAtPoint (enemyLazer, transform.position, 0.2f);
			
		}
	}
	
	void Attack ()
	{
		Vector3 startPosition = transform.position + new Vector3 (0, -1.5f, 0);
		GameObject attack = Instantiate (attackPrefab, startPosition, Quaternion.identity)as GameObject;
		attack.GetComponent<Rigidbody2D>().velocity = new Vector3 (0f, -attackSpeed, 0f);
	}
	
}
