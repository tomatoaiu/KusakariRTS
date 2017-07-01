using UnityEngine;
using System.Collections;

public class HitArea : MonoBehaviour {

	void Damage(Attack.AttackInfo attackinfo){
		transform.root.SendMessage ("Damage", attackinfo);
	}

	void OnTriggerEnter(Collider other) {
		
	}
}
