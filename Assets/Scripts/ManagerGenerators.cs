using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GeneratorInfo {
	public Animator 	animator;
	public float		interval;

	public GeneratorInfo(Animator anim) 
	{
		this.animator = anim;
		this.interval = 1.0f;
	}
}

public class ManagerGenerators : MonoBehaviour {

	public GameObject generatorToDown;
	public GameObject generatorToUp;
	public GameObject generatorToRight;
	public GameObject generatorToLeft;

	private Animator animToDown;
	private Animator animToUp;
	private Animator animToRight;
	private Animator animToLeft;
	
	float timeElapsed = 0.0f;
	private float intervalLevel1, intervalLevel2, intervalLevel3, intervalLevel4;

	private List<GeneratorInfo> listGeneratorsInfo;
		
	void InitRandomIntervals(){
		for (int i = 0; i < listGeneratorsInfo.Count; ++i) {
			listGeneratorsInfo[i].interval = Random.Range(1.0f + (0.5f * i), (2.0f * i));
		}
	}

	void InitListGenerators()
	{
		listGeneratorsInfo = new List<GeneratorInfo> ();
		listGeneratorsInfo.Add (new GeneratorInfo(animToDown));
		listGeneratorsInfo.Add (new GeneratorInfo(animToUp));
		listGeneratorsInfo.Add (new GeneratorInfo(animToLeft));
		listGeneratorsInfo.Add (new GeneratorInfo(animToRight));

		// Shuffle list randomly
		Utilities.Shuffle (listGeneratorsInfo);

		// Random intervals in the list
		InitRandomIntervals ();
	}

	void InitAnimators() {
		animToDown = generatorToDown.GetComponent<Animator> ();
		animToUp = generatorToUp.GetComponent<Animator> ();
		animToRight = generatorToRight.GetComponent<Animator> ();
		animToLeft = generatorToLeft.GetComponent<Animator> ();
	}

	void Start () {
		InitAnimators ();
		InitListGenerators ();
	}
	
	void Update () {
		timeElapsed += Time.deltaTime;
		for (int i = 0; i < listGeneratorsInfo.Count; ++i) {
			if (timeElapsed > listGeneratorsInfo[i].interval) {
				listGeneratorsInfo[i].animator.speed += Random.Range (0.01f,0.05f);
				listGeneratorsInfo[i].interval += Random.Range (1.0f, 4.0f);
			}
		}
	}
}
