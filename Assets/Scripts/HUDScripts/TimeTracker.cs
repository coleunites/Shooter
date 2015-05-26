using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TimeTracker : MonoBehaviour 
{
	static public TimeTracker Instance;
	public int secondsLeft;

	Text timeText;
	float secondCalc;


	// Use this for initialization
	void Start () 
	{
		Instance = this;
		timeText = GetComponent<Text> ();
		secondCalc = 0f;
		timeText.text = "Time : " + secondsLeft.ToString();
	}
	
	// Update is called once per frame
	void Update () 
	{
		secondCalc += (1 * Time.deltaTime);
		if(secondCalc >= 1 && secondsLeft > 0)
		{
			--secondsLeft;
			secondCalc = 0f;
			timeText.text = "Time : " + secondsLeft.ToString();
			if(secondsLeft == 0)
			{
				ConditionTracker.Instance.Win ();
			}
		}
	}
}
