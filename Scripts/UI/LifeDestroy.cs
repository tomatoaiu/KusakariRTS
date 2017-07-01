/*

canvasの子要素になる
ライフメータを削除

*/


using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class LifeDestroy : MonoBehaviour {

	Slider slider;

	void Start(){
		slider = GetComponent<Slider> ();
	}

	void Update () {
		// 体力が0になったらライフメーターを削除
		if (slider.value == 0) {
			Destroy (gameObject);
		}
	}
}
