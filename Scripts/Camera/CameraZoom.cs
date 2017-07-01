/*

カメラのズーム
マウスホイールで動かす

*/

using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraZoom : MonoBehaviour
{
	[SerializeField, Range(0.1f, 10f)]
	private float wheelSpeed = 3f;

	private void Update()
	{
		MouseUpdate();
		return;
	}

	private void MouseUpdate()
	{
		float scrollWheel = Input.GetAxis("Mouse ScrollWheel");
		if(scrollWheel != 0.0f)
			MouseWheel(scrollWheel);
	}

	private void MouseWheel(float delta)
	{
		transform.position += transform.forward * delta * wheelSpeed;
		return;
	}
}