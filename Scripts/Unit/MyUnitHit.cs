/*

hitareaの処理

*/

using UnityEngine;
using System.Collections;

public class MyUnitHit : MonoBehaviour {

	Unit unit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider col){
		if (col.tag == "EnemyUnitHitArea") {
			unit =  gameObject.transform.parent.GetComponent<Unit>(); // 自分の親オブジェクトのUnitクラス取得
			unit.TargetEnemyUnit = col.transform.parent.gameObject; // 接触した相手の親（敵ユニット）を取得
			unit.inEnemyHitArea = true;
		}
	}
}
