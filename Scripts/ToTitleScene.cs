using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ToTitleScene : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ToTitle(){
		SceneManager.LoadScene ("Title");
	}
}
