using UnityEngine;
using System.Collections;

public class EnemyUnitHit : MonoBehaviour {

	Unit unit;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
//		Debug.Log (col);
		if (col.tag == "MyUnitHitArea") {
			
			unit = gameObject.transform.parent.GetComponent<Unit> ();

//			var units = gameObject.transform.parent.GetComponents<Unit> ();
//			foreach(var a in units){
//				Debug.Log (a);
//			}

//			Debug.Log (unit);
			unit.TargetEnemyUnit = col.transform.parent.gameObject;
			unit.inEnemyHitArea = true;
//			Debug.Log (unit.inEnemyHitArea);

		}
	}
}
