using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using System;

public class ToNextScene : MonoBehaviour {

	public string scene; // 遷移先のシーン名

	// Use this for initialization
	void Start () {
//		scene = transform.name;
//		var childText =  this.gameObject.GetComponentInChildren<Text>(); // Buttonの子要素のtextコンポーネントのtext
//		childText.text = scene;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual void ToNext(){
//		Debug.Log ("Parent");
		SceneManager.LoadScene (scene);
	}
}
