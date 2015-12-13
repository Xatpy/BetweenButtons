using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	public LineRenderer catapultLineBack;

	public bool lineRenderActive;

	private Ray rayToMouse;
	
	private bool clickedOn;
	

	// Use this for initialization
	void Start () {
		if (lineRenderActive)
			LineRendererSetup();
	}
	
	// Update is called once per frame
	void Update () {
		if (clickedOn)
			Dragging ();

		if (lineRenderActive)
			LineRendererUpdate ();
	}

	void LineRendererSetup () {
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);	
		catapultLineBack.SetPosition (1, this.transform.position);
		Debug.Log ("done");
	}

	void OnMouseDown () {
		clickedOn = true;
	}
	
	void OnMouseUp () {
		clickedOn = false;
	}
	
	void Dragging () {
		Vector3 mouseWorldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		mouseWorldPoint.z = 0f;
		transform.position = mouseWorldPoint;
	}

	void LineRendererUpdate () {
		catapultLineBack.SetPosition(0, catapultLineBack.transform.position);	
		catapultLineBack.SetPosition (1, this.transform.position);
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.transform.parent.name == "borders") {
			clickedOn = false;
			return;
		}

		NotificationCenter.DefaultCenter().PostNotification(this, "EndGame");
	} 
}
