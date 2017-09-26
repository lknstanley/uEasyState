using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateEventTrigger : MonoBehaviour {
	
	public delegate void StateEventHandler (StateBaseEvent eventData);

	public static event StateEventHandler onStateFinished;
	public static event StateEventHandler onStateFailed;
	public static event StateEventHandler onStateRestarted;

	#region State Base Event
	public static void OnStateFinished(StateBaseEvent eventData) {
		if (onStateFinished != null) {
			onStateFinished (eventData);
		}
	}

	public static void OnStateFailed(StateBaseEvent eventData) {
		if (onStateFailed != null) {
			onStateFailed (eventData);
		}
	}

	public static void OnStateRestarted(StateBaseEvent eventData) {
		if (onStateRestarted != null) {
			onStateRestarted (eventData);
		}
	}
	#endregion
}
