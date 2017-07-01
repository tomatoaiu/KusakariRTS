using UnityEngine;
using System.Collections;

public class Attack : MonoBehaviour {

	Status status;

	void Start () {
		status = transform.root.GetComponent<Status> ();
	}

	public class AttackInfo {
		public float attackPower; // この攻撃の攻撃力
		public float attackInterval; // この攻撃の間隔
		public Transform attacker; // 攻撃力
	}

	AttackInfo GetAttackInfo(){
		AttackInfo attackinfo = new AttackInfo ();
		attackinfo.attackPower = status.power;
		attackinfo.attackInterval = status.attackInterval;

		attackinfo.attacker = transform.root;

		return attackinfo;
	}

	void OnTriggerEnter(Collider other){
		other.SendMessage ("Damage", GetAttackInfo());
		status.lastAttackTarget = other.transform.root.gameObject;
	}
}
