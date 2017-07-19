using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonScene : MonoBehaviour {

	public string sceneName;
	public string buttonText;
	Text text;

	// Use this for initialization
	void Start () {
		text = gameObject.GetComponentInChildren<Text> ();
		text.text = buttonText;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void NextScene(){
		SceneManager.LoadScene (sceneName);
	}
}
