using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public EnemyBehaviour.typeMovement typeMov;

	public GameObject enemyPrefab;

	float timeElapsed = 0.0f;

	public float interval = 1.0f; // Seconds

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > interval) {
			timeElapsed = .0f;
			Debug.Log("suelta");

			enemyPrefab.GetComponent<EnemyBehaviour>().type = typeMov;

			Instantiate(enemyPrefab, this.transform.position, Quaternion.identity);
		}
	
	}
}
