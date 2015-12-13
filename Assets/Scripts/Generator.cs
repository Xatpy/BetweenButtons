using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public EnemyBehaviour.typeMovement typeMov;

	public GameObject enemyPrefab;

	float timeElapsed = 0.0f;

	public float intervalMin = 5.0f;
	public float intervalMax = 10.0f; // Seconds
	private float interval = 7.0f;
	
	void Start() {
		interval = Random.Range (intervalMin, intervalMax);
	}
	
	// Update is called once per frame
	void Update () {
		timeElapsed += Time.deltaTime;

		if (timeElapsed > interval) {
			timeElapsed = .0f;

			enemyPrefab.GetComponent<EnemyBehaviour>().type = typeMov;

			GameObject go = Instantiate(enemyPrefab, this.transform.position, Quaternion.identity) as GameObject;
			go.gameObject.transform.parent = this.transform.parent;
		}
	
	}
}
