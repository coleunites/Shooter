using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class HealthTracker : MonoBehaviour {

	static public HealthTracker Instance;

	float healthPercantage;
	float newHealthPercantage;
	float healthImageWidth;
	Image healthImage;

	// Use this for initialization
	void Start () 
	{
		Instance = this;
		healthImage = GetComponent<Image> ();
		healthPercantage = 1f;
		newHealthPercantage = healthPercantage;
		healthImageWidth = healthImage.rectTransform.rect.width;
	}

	public void SubtractHealth(float newPercentage)
	{
		newHealthPercantage = newPercentage;
	}

	// Update is called once per frame
	void Update () 
	{
			healthPercantage = Mathf.Lerp (healthPercantage, newHealthPercantage, Time.deltaTime * 1);
			Vector2 temp;
			temp.x = healthImageWidth * healthPercantage;
			temp.y = healthImage.rectTransform.rect.height;
			healthImage.rectTransform.sizeDelta = temp;
	}
}
