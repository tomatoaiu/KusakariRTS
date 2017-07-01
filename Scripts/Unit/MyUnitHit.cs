/*

hitareaの処理

*/

using UnityEngine;
using System.Collections;

public class MyUnitHit : MonoBehaviour {

	MyUnit cMyUnit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "EnemyUnitHitArea") {
			cMyUnit =  gameObject.transform.parent.GetComponent<MyUnit>();
			cMyUnit.TargetEnemyUnit = col.transform.parent.gameObject;
			cMyUnit.inEnemyHitArea = true;

		}

	}

}
