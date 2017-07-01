using UnityEngine;
using System.Collections;

public class Soldier : MonoBehaviour {

	MyUnit myUnit;

	// Use this for initialization
	void Start () {
		myUnit = GetComponent<MyUnit> ();
	}

	// Update is called once per frame
	void Update () {
		if (myUnit.isDuringAttack) {
			GetComponent<Animator> ().SetBool ("run", false);
			GetComponent<Animator> ().SetBool ("idle", true);
		} else {
			GetComponent<Animator> ().SetBool ("idle", false);
			GetComponent<Animator> ().SetBool ("run", true);
		}
	}
}
