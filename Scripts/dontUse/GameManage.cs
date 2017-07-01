using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManage : MonoBehaviour {

	public GameObject Boss;
	public GameObject MyBoss;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Boss == null) {
			SceneManager.LoadScene ("Result");
		} else if(MyBoss == null){
			SceneManager.LoadScene ("Result");
		}
	}
}
