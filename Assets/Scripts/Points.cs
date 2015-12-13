using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public GUIText scoreboard;
	public Text scoreText;

	private int score = 0;

	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "AddPoints");	
		scoreText = GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void AddPoints (Notification notificacion) {
		int newPoints = (int)notificacion.data;
		score += newPoints;
		UpdateScoreboard();
	}

	void UpdateScoreboard(){
		scoreText.text = "Score: " + score.ToString();
	}
}
