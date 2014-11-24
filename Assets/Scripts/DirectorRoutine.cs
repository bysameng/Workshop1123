using UnityEngine;
using System.Collections;

public class DirectorRoutine : MonoBehaviour {

	#region class vars

	public float delay = 2f;
	public TestScript testScript;

	private float timer;

	#endregion


	// Use this for initialization
	void Start () {
		StartCoroutine(Routine());
//		StartCoroutine("Routine");
//		Invoke("DoTests", delay);
//		timer = delay;
	}

	//as a side note
	//you can also use Destroy(gameObject, 5f);



	void Update(){

		//base timer type dealio
		if (timer > 0){
			timer = timer - Time.deltaTime;
//			timer -= Time.deltaTime; //another way to do it
			if (timer <= 0){
				DoTests();
				timer = 1f;
			}
		}

	}



	//use this one, it will time everything well!
	IEnumerator Routine(){
		yield return new WaitForSeconds(delay);
		DoTests();
		yield return new WaitForSeconds(delay);
		StopTests();
	}


	//will start the routine on testScript
	void DoTests(){
		testScript.DoRoutine();
	}


	//will stop the tests on testScript
	void StopTests(){
		testScript.DestroyAll();
	}




}
