using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreTracker : MonoBehaviour 
{
	static public ScoreTracker Instance;
	
	Text scoreText;
	int score = 0;
	
	void Awake()
	{
		Instance = this;
		
		scoreText = GetComponent<Text> ();
		scoreText.text = "Score: " + score.ToString ();
	}
	
	public void AddScore(int value)
	{
		score += value;
		scoreText.text = "Score: " + score.ToString ();
	}
}
