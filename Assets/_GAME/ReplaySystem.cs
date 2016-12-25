using UnityEngine;

namespace Assets._GAME {
	public class ReplaySystem : MonoBehaviour {
		private const int BufferFrames = 1000;
		private readonly MyKeyFrame[] _keyFrames = new MyKeyFrame[BufferFrames];
		private Rigidbody _rigidBody;
		private GameManager _gameManager;

		private bool _playbackStarted;
		private int _lastFrameOfRecord;

		void Start () {

			_rigidBody = GetComponent<Rigidbody>();
			_gameManager = FindObjectOfType<GameManager>();
		}
	
		// Update is called once per frame
		void Update () {
			if (_gameManager.recording) {
				_playbackStarted = false;
				Record();
			}
			else {
				PlayBack();
			}
		}

		private void Record() {
			_rigidBody.isKinematic = false;
			int frame = Time.frameCount%BufferFrames;
			float time = Time.time;

			_keyFrames[frame] = new MyKeyFrame(time, transform.position, transform.rotation);
		}

		void PlayBack() {
			if (_playbackStarted == false) {
				_lastFrameOfRecord = Time.frameCount;
				_playbackStarted = true;
			}
			_rigidBody.isKinematic = true;

			int frame = (Time.frameCount -_lastFrameOfRecord) % BufferFrames;

			transform.position = _keyFrames[frame].position;
			transform.rotation = _keyFrames[frame].rotation;

		}
	}

	/// <summary>
	/// A structure for storing time, rotation and position.
	/// </summary>
	public struct MyKeyFrame {

		public  float frameTime;
		public  Vector3 position;
		public  Quaternion rotation;
	

		public MyKeyFrame(float frameTime,Vector3 position,Quaternion rotation) {
			this.frameTime = frameTime;
			this.position = position;
			this.rotation = rotation;
		}


	}
}