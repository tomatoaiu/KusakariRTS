using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine;

public class NextSceneButton : ToNextScene {

	// Use this for initialization
	void Start () {
		scene = transform.name;
		var childText =  this.gameObject.GetComponentInChildren<Text>(); // Buttonの子要素のtextコンポーネントのtext
		childText.text = scene;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public override void ToNext(){
		SceneManager.LoadScene (scene);
		Debug.Log("Children");
	}
}
