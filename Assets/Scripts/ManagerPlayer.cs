using UnityEngine;
using System.Collections;

public class ManagerPlayer : MonoBehaviour {

	public GameObject Button1;
	public GameObject Button2;

	public LineRenderer lineRender;

	private bool clickedOn;

	// Use this for initialization
	void Start () {
		LineRendererSetup();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.touchCount > 0) {
			for(int i = 0; i < Input.touchCount; i++) {
				Touch t = Input.GetTouch(i);
				
				if (t.phase == TouchPhase.Began) {

					RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint((Input.GetTouch(i).position)), Vector2.zero);
					if(hit.collider != null)
					{
						Debug.Log ("Touched it");
					}
				}
				
				if (t.phase == TouchPhase.Ended) {
					// Stop all movement
				}
			}
		}
	}

	void LineRendererSetup () {
		lineRender.SetPosition(0, Button1.transform.position);	
		lineRender.SetPosition (1, Button2.transform.position);
	}

	void LineRendererUpdate () {
		lineRender.SetPosition(0, Button1.transform.position);	
		lineRender.SetPosition (1, Button2.transform.position);
	}
}
