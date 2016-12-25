using UnityEngine;
using System.Collections;

public class SelfieStick : MonoBehaviour {

	public float panSpeed = 10f;

	private GameObject _player;
	private Vector3 _armRotation;

	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
		_armRotation = transform.rotation.eulerAngles;
	}
	
	// Update is called once per frame
	void Update () {
		_armRotation.y += Input.GetAxis("RHoriz")*panSpeed;
		_armRotation.x += Input.GetAxis("RVertic")*panSpeed;

		transform.position = _player.transform.position;
		transform.rotation = Quaternion.Euler(_armRotation);

	}
}
