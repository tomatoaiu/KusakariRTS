using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.AI;

/**
 * unitクラスを継承を
 * 自軍のユニット
 */
public class MyUnit : Unit {

	/**
	 * <summary>敵ボスの情報を自分にインプット
	 * </summary>
	 * <param name="col">コライダー</param>
	 */
	protected void SetBossInformaiton(Collider col){
		enemyBoss = col.gameObject;
		agent.SetDestination (enemyBoss.transform.position);
	}
		
	/**
	 * <summary>敵ユニットの情報を自分にインプット
	 * </summary>
	 * <param name="col">コライダー</param>
	 */
	protected void SetUnitInformaiton(Collider col){
		enemyUnit = col.gameObject;
		agent.SetDestination (enemyUnit.transform.position);
	}

	/**
	 * <summary>接敵したオブジェクトの取得
	 * </summary>
	 * <param name="col">コライダー</param>
	 */
	protected void StoreNearingEnemy(Collider col){
		if (col.tag == "EnemyUnitHitArea") {
			SetUnitInformaiton (col);
		}
		targets.Add (col); // 接触した敵の情報を保存
	}
}
