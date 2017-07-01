using UnityEngine;
using System.Collections;

public class CreateSol : MonoBehaviour {

	public GameObject chara;

	GameObject[] existCharas;

	public int maxChara = 10;

	private RaycastHit hit;
	private Ray ray;

	private int count;

	// Use this for initialization
	void Start () {
		existCharas = new GameObject[maxChara];
	}
	
	// Update is called once per frame
	void Update () {/*
		if (Input.GetMouseButtonDown(0)){
			ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit, 100f)){
				//agent.SetDestination(hit.point);
				if(count < existCharas.Length){
					existCharas [count] = Instantiate (chara, hit.point, transform.rotation) as GameObject;
					count++;
				}
			}       
		}*/
	}
}
