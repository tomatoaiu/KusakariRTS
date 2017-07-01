/*

カメラをアローキ-で動かすC#

*/

using UnityEngine;
using System.Collections;

public class CameraControll : MonoBehaviour {

	
	// Update is called once per frame
	void Update () {

		if (Input.GetKey(KeyCode.LeftArrow)) {
			Vector3 v = this.transform.position;
			v.z += -0.5f;
			this.transform.position = v;
		}

		if (Input.GetKey(KeyCode.RightArrow)) {
			Vector3 v = this.transform.position;
			v.z += 0.5f;
			this.transform.position = v;
		}

		if (Input.GetKey(KeyCode.UpArrow)) {
			Vector3 v = this.transform.position;
			v.x += -0.5f;
			this.transform.position = v;
		}

		if (Input.GetKey(KeyCode.DownArrow)) {
			Vector3 v = this.transform.position;
			v.x += 0.5f;
			this.transform.position = v;
		}
	}
}
