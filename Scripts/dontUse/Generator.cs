using UnityEngine;
using System.Collections;

public class Generator : MonoBehaviour {

	public GameObject chara;

	GameObject[] existCharas;

	public int maxChara = 10;

	// Use this for initialization
	void Start () {
		existCharas = new GameObject[maxChara];
		StartCoroutine (Exec ());
	}

	IEnumerator Exec(){
		while(true){
			Generate ();
			yield return new WaitForSeconds (3.0f);
		}
	}

	void Generate(){
		for(int charaCount = 0; charaCount < existCharas.Length; ++charaCount){
			if (existCharas [charaCount] == null) {
				existCharas [charaCount] = Instantiate (chara, transform.position, transform.rotation) as GameObject;
				return;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
