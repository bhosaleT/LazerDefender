using UnityEngine;
using System.Collections;

public class LevelManager : MonoBehaviour
{

	public void loadLevel (string name)
	{
		Debug.Log ("Level Load Requested for: " + name);
		
		Application.LoadLevel (name);
		
	}  
	
	 
	public void quitLevel ()
	{
		Debug.Log ("Quit level");
		Application.Quit ();
	
	}
	
	public void LoadNextLevel ()
	{

		Application.LoadLevel (Application.loadedLevel + 1);
	}
	
	public void BrickDestroyed ()
	{
		
		LoadNextLevel ();
		
	}
}