using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreKeeper : MonoBehaviour
{

	public static int score = 0;
	public static int max = 0;
	private Text myText;

	
	void Start ()
	{
		myText = GetComponent<Text> ();
		Reset ();
	}
	
	public void CalculateScore (int pt)
	{
		score += pt;
		myText.text = score.ToString ();
		
	
	
	}
	public  int HighScore ()
	{
		if (score > max) {
			max = score;
		}
		return max;
	}
	
	
	
	public static	void Reset ()
	{
		score = 0;
		
	}
}
