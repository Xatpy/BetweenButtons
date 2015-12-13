
using UnityEngine;
using System.Collections;

public class ActivateEndGame : MonoBehaviour {

	public GameObject gameGO;
	public GameObject gameOverGO;
	public AudioClip gameOverClip;
	
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "EndGame");	
	}
	
	void EndGame(Notification notificacion)
	{		
//		GetComponent<AudioSource>().Stop();
//		GetComponent<AudioSource>().clip = gameOverClip;
//		GetComponent<AudioSource>().loop = true;
//		GetComponent<AudioSource>().Play();


		gameOverGO.SetActive(true);
		gameGO.SetActive (false);
	}
}