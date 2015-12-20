using UnityEngine;
using System.Collections;

public class destructorTrigger : MonoBehaviour {

	public int points = 10;

	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "IncrementarPuntos");
	}
	
	void OnTriggerEnter2D(Collider2D other){
		NotificationCenter.DefaultCenter().PostNotification(this, "AddPoints", points);
		Destroy (other.gameObject);
	} 
}
