
using UnityEngine;
using System.Collections;

public class ActivateEndGame : MonoBehaviour {

	public GameObject gameGO;
	public GameObject gameOverGO;
	public AudioClip gameOverClip;
	
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "EndGame");	
	}
	
	void EndGame(Notification notificacion)
	{
		gameOverGO.SetActive(true);
		gameGO.SetActive (false);
	}
}