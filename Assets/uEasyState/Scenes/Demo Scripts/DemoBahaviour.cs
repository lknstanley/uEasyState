using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DemoBahaviour : MonoBehaviour {

	void Awake() {
		SetupCallbacks ();
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnDestroy() {
		RemoveCallbacks ();
	}

	#region State Event Setup / Remove
	public void SetupCallbacks() {
		// Set state trigger events
		StateEventTrigger.onStateFinished += OnStateFinished;
		StateEventTrigger.onStateFailed += OnStateFailed;
		StateEventTrigger.onStateRestarted += OnStateRestarted;
	}

	public void RemoveCallbacks() {
		// Remove state trigger events
		StateEventTrigger.onStateFinished -= OnStateFinished;
		StateEventTrigger.onStateFailed -= OnStateFailed;
		StateEventTrigger.onStateRestarted -= OnStateRestarted;
	}
	#endregion

	#region State Event Implemetation
	void OnStateFinished (StateBaseEvent eventData) {
		Debug.Log ("State Finished.");
	}

	void OnStateFailed(StateBaseEvent eventData) {
		Debug.Log ("State Failed.");
	}

	void OnStateRestarted(StateBaseEvent eventData) {
		Debug.Log ("State Restarted.");
	}
	#endregion
}
