using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Points : MonoBehaviour {

	public GUIText scoreboard;
	public Text scoreText;

	private int score = 0;

	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "AddPoints");	
		scoreText = GetComponent<Text> ();
	}
	
	void AddPoints (Notification notificacion) {
		int newPoints = (int)notificacion.data;
		score += newPoints;
		UpdateScoreboard();
	}

	void UpdateScoreboard(){
		scoreText.text = "Score: " + score.ToString();
	}
}
