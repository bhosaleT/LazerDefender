using UnityEngine;
using System.Collections;

public  class MusicPlayer : MonoBehaviour
{    //There should be only one music player instance running at any given time.
	static MusicPlayer instance = null;
    
	void Awake ()
	{
		Debug.Log ("Music player awake " + GetInstanceID ());
		if (instance != null) {
			Destroy (gameObject);
			print ("Duplicate music player destroyed!");
		} else {
			//This instance of the musicplayer is claimed.! so dont destroy it.
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
    
    
    
    
	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Music player start " + GetInstanceID ());
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
}
