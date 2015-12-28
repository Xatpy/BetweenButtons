using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UpdateScoreboard : MonoBehaviour {

	public GameObject scoreGame;
	
	void Awake() {
		this.GetComponent<Text>().text = scoreGame.GetComponent<Text>().text;
	}
}
