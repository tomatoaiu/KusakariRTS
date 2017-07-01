using UnityEngine;
using System.Collections;

public class EnemyUnitHit : MonoBehaviour {

	EnemyUnit cEnemyUnit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){

		if (col.tag == "MyUnitHitArea") {
			cEnemyUnit = gameObject.transform.parent.GetComponent<EnemyUnit> ();
			cEnemyUnit.TargetEnemyUnit = col.transform.parent.gameObject;
			cEnemyUnit.inEnemyHitArea = true;
		}


			Debug.Log ("aiueo");


	}
}
