using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/*
 * MyUnitクラスを継承した
 * Clownクラス
 */
public class Clown : MyUnit {

//	MyUnit myUnit;
//	UnitData unitData;


	// Use this for initialization
	protected void Start () {
//		myUnit = GetComponent<MyUnit> ();
//		unitData = GetComponent<UnitData> ();

//		unitName = "Clown";
//		attackPoint = 30;
//		unitSpeed = 3f;
//		life = 100f;
//		maxLife = 100f;
//		attackInterval = 4f;
		base.Start();
//		UnitInit();
//		Debug.Log (sphereColliderRadius);
		gameObject.GetComponent<SphereCollider> ().radius = sphereColliderRadius;
	}

	// Update is called once per frame
	protected void Update () {
//		UnitSet ();
		base.Update();
		UnitMove (); // unitを動かす
		AIAttackFirstTarget();
	}

	protected override void SetUpUnitStatus ()
	{
		unitName = "Clown";
		attackPoint = 20;
		unitSpeed = 4f;
		life = 80f;
		maxLife = 80f;
		attackInterval = 2f;
		sphereColliderRadius = 15f;
	}

	/// <summary>
	/// ユニットのアニメーターを動かす
	/// </summary>
	void UnitMove(){
		if (isDuringAttack) {
			GetComponent<Animator> ().SetBool ("run", false);
			GetComponent<Animator> ().SetBool ("idle", true);
		} else {
			GetComponent<Animator> ().SetBool ("idle", false);
			GetComponent<Animator> ().SetBool ("run", true);
		}
	}

	// 敵の検知
	void OnTriggerEnter(Collider col){
		StoreNearingEnemy (col); // 接敵したオブジェクトを保存

	}

	// 敵が範囲内にいる間
	void OnTriggerStay(Collider col){

//		if (isDuringAttack) { // 攻撃中の間
//			return;
//		}

//		Debug.Log (col);
	}
		

}
