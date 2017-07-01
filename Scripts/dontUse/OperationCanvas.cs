using UnityEngine;
using System.Collections;

public class OperationCanvas : MonoBehaviour {

	public Camera rotateCamera;

	// Use this for initialization
	void Start () {
		rotateCamera = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = rotateCamera.transform.rotation;
	}

	void Disable(){
		this.gameObject.SetActive(false);
	}
}
