using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public enum TestCase {
	SameGameObject, 
	ParentObject, 
	ChildObject, 
	GetObjectByName,
	GetObjectByTag,
	GetAllObjectsByTag,
	DraggedNDropped,
};


public class TestScript : MonoBehaviour {

	public TestCase testCase;

	public GameObject draggedAndDropped;

	public string nameOfObject;

	private PositionMover pMover;

	// Use this for initialization
	public void DoRoutine () {

		if (draggedAndDropped != null){
			Debug.Log("Drag'd 'n' drop'd");
			testCase = TestCase.DraggedNDropped;
		}

		switch(testCase){
		//getting a component that's sister to this component
		case TestCase.SameGameObject:
			Debug.Log("Same game object test");
			pMover = gameObject.GetComponent<PositionMover>();
			break;
		case TestCase.ChildObject:
			Debug.Log("child game object test");
			pMover = gameObject.GetComponentInChildren<PositionMover>();
			break;
		case TestCase.ParentObject:
			Debug.Log("parent game object test");
			pMover = gameObject.GetComponentInParent<PositionMover>();
			break;
		case TestCase.DraggedNDropped:
			pMover = draggedAndDropped.GetComponent<PositionMover>();
			break;
		case TestCase.GetObjectByName:
			GameObject g = GameObject.Find(nameOfObject);
			pMover = g.GetComponent<PositionMover>();
			break;
		case TestCase.GetObjectByTag:
			pMover = GameObject.FindGameObjectWithTag("MovePositions").GetComponent<PositionMover>();
			break;
		case TestCase.GetAllObjectsByTag:
			GameObject[] gs = GameObject.FindGameObjectsWithTag("MovePositions");
//			for (int i = 0; i < gs.Length; i++){
//				gs[i].GetComponent<PositionMover>().Move(Random.onUnitSphere);
//			}
			foreach(GameObject go in gs){
				go.GetComponent<PositionMover>().Move(Random.onUnitSphere);
			}
			break;
		default:
			break;
		}

		if (pMover != null){
			pMover.Move(new Vector3(1f, 0f, 0f));
		}
		else{
			Debug.LogWarning("A suitable PositionMover wasn't found!");
		}
	}


	public void DestroyAll(){
//////////////////////////////////////////////////////////////////////////////////
		List<PositionMover> movers = new List<PositionMover>();
		GameObject[] gs = GameObject.FindGameObjectsWithTag("MovePositions");

		for (int i = 0; i < gs.Length; i++){
			movers.Add(gs[i].GetComponent<PositionMover>());
		}
//////////////////////////////////////////////////////////////////////////////////
		for (int i = 0; i < movers.Count; i++){
			float destroyTime = i * .1f;
			Destroy(movers[i].rigidbody, destroyTime);
			Destroy(movers[i],			 destroyTime);
		}
//////////////////////////////////////////////////////////////////////////////////
	}

	// Update is called once per frame
	void Update () {
	
	}
}
