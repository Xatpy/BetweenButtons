using UnityEngine;
using System.Collections;

public class EnemyBehaviour : MonoBehaviour {

	public enum typeMovement
	{
		Down,
		Up,
		Right,
		Left
	}

	public typeMovement type = typeMovement.Down;

	public float Velocity = 0.01f;

	private Vector3 vecDir;

	private float factor = 1.0f;

	void Start () {
		switch (type) {
			case typeMovement.Down:
			vecDir = new Vector3(.0f,-1.0f,.0f);
			break;
		case typeMovement.Up:
			vecDir = new Vector3(.0f,1.0f,.0f);
			break;
		case typeMovement.Left:
			vecDir = new Vector3(-1.0f,.0f,.0f);
			break;
		case typeMovement.Right:
			vecDir = new Vector3(1.0f,.0f,.0f);
			break;
		}
	}
	
	void FixedUpdate () {
		this.transform.position += (vecDir * Velocity * factor);
	}
}
