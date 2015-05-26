using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ConditionTracker : MonoBehaviour 
{
	static public ConditionTracker Instance;
	bool aConditionIsMet;

	Text conditionText; 
	// Use this for initialization
	void Start () 
	{
		Instance = this;
		conditionText  = GetComponent<Text> ();
		conditionText.text = " ";
		aConditionIsMet = false;
	}

	public void Win()
	{
		if(aConditionIsMet == false)
		{
			aConditionIsMet = true;
			conditionText.text = "You Won";
			StartCoroutine (Reset());
		}

	}

	public void Lost()
	{
		if(aConditionIsMet == false)
		{
			aConditionIsMet = true;
			conditionText.text = "Game Over";
			StartCoroutine (Reset());
		}
	}
	
	IEnumerator Reset ()
	{
		yield return new WaitForSeconds(5.0f);
		Application.LoadLevel (0);
	}
}
