using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

namespace Assets._GAME {
	public class GameManager : MonoBehaviour {

		public bool recording = true;
		private float _initialFixedDelta;

		private bool _isPaused;

		// Use this for initialization
		void Start () {
			PlayerPrefsManager.UnlockLevel(2);
			print(PlayerPrefsManager.IsLevelUnlocked(1));
			print(PlayerPrefsManager.IsLevelUnlocked(2));

			_initialFixedDelta = Time.fixedDeltaTime;
		}
	
		// Update is called once per frame
		void Update () {
			if (CrossPlatformInputManager.GetButton("Fire1")) {
				recording = false;
			}
			else {
				recording = true;
			}
			if (Input.GetKeyDown(KeyCode.P) && _isPaused) {
				_isPaused = false;
				ResumeGame();
			}
			else if (Input.GetKeyDown(KeyCode.P) && !_isPaused) {
				_isPaused = true;
				PauseGame();
			}
			
			print("Update");
		}

		private void ResumeGame() {
			Time.timeScale = 1f;
			Time.fixedDeltaTime =_initialFixedDelta;
		}

		void PauseGame() {
			Time.timeScale = 0;
			Time.fixedDeltaTime = 0f;
		}

		void OnApplicationPause(bool pauseStatus) {
			_isPaused = pauseStatus;
		}
	}
}
