using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBoss : Unit {

	// Use this for initialization
	void Start () {
		UnitInit();
	}
	
	// Update is called once per frame
	void Update () {
		UnitSet ();
	}

	protected override void SetUpUnitStatus ()
	{
		unitName = "BossWeed";
		attackPoint = 20;
		unitSpeed = 0;
		life = 300f;
		maxLife = 300f;
		attackInterval = 5f;
	}
}
