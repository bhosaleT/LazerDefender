using UnityEngine;
using System.Collections;

public class Meteor : MonoBehaviour
{
	public GameObject meteorPrefab;
	public float height = 10f;
	public float width = 10f;
	// Use this for initialization
	void Start ()
	{
	
	}
	public void OnDrawGizmos ()
	{
		Gizmos.DrawWireCube (transform.position, new Vector3 (width, height));
	}
	// Update is called once per frame
	void Update ()
	{
	
	}
}
