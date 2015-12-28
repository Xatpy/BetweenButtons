using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	public LineRenderer catapultLineBack;

	public bool lineRenderActive;

	private Ray rayToMouse;
	
	private bool clickedOn;

	public Camera camera;

	public GameObject test;
	public bool testing;

	void Start () {
		if (lineRenderActive)
			LineRendererSetup();
	}

	void Multitouch () {
		if (!testing)
			return;

		if (Input.touchCount > 0) {
			Touch myTouch = Input.GetTouch (0);
			Touch[] myTouches = Input.touches;
			for (int i = 0; i < Input.touchCount; i++) {
				//Do something with the touches
				Ray ray = camera.ScreenPointToRay (new Vector3 (myTouches [i].position.x, myTouches [i].position.y, 0));
				RaycastHit hit;
				if (Physics.Raycast (ray, out hit, Mathf.Infinity, LayerMask.NameToLayer ("Player"))) {
					Debug.Log ("hit");
					test.SetActive(true);
					//enter here if the object has been hit. The first hit object belongin to the layer "layerOfYourGameObject" is returned.
				}
			}
		} else {
			test.SetActive(false);
		}
	}
	
	void Update () {
		//Multitouch ();

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
