using UnityEngine;
using System.Collections;

public class destructorTrigger : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other){
		Debug.Log("Something has entered this zone.");    
		Destroy (other.gameObject);
	} 
}
