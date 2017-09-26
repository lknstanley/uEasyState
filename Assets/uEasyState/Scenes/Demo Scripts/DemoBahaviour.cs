using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DemoBahaviour : MonoBehaviour {

	public DemoStateModel[] states;
	int curState = 0;

	// uGUI Reference
	public Text stateName;
	public Text stateId;
	public Text stateMsg;
	public Text stateResult;
	public Text currentStateLbl;
	

	void Awake() {
		SetupCallbacks ();

		InitUI ();
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

	void InitUI () {
		currentStateLbl.text = curState.ToString ();
		LoadState (curState);
	}

	#region uGUI Callbacks
	public void OnNextStateClicked () {
		if(curState + 1 >= states.Length) {
			curState = 0;
		} else {
			curState ++;
		}

		LoadState (curState);
	}

	public void OnPreviousStateClicked () {
		if(curState - 1 <= 0) {
			curState = states.Length - 1;
		} else {
			curState --;
		}

		LoadState (curState);
	}

	public void OnOkClicked() {
		StateEventTrigger.OnStateFinished (new StateBaseEvent ());
	}

	public void OnFailClicked() {
		StateEventTrigger.OnStateFailed (new StateBaseEvent ());
	}

	public void OnRestartClicked () {
		StateEventTrigger.OnStateRestarted (new StateBaseEvent ());
	}
	#endregion

	#region State Event Setup / Remove / Load
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

	#region State Demo Implemetation
	void LoadState (int stateIndex) {
		DemoStateModel model = states [stateIndex];
		currentStateLbl.text = stateIndex.ToString ();
		stateName.text = model.stateName;
		stateId.text = model.id.ToString ();
		stateMsg.text = model.msg;
		stateResult.text = "Please press right top coner to trigger event.";
	}

	void OnStateFinished (StateBaseEvent eventData) {
		stateResult.text = "State Finished";
	}

	void OnStateFailed(StateBaseEvent eventData) {
		stateResult.text = "State Failed";
	}

	void OnStateRestarted(StateBaseEvent eventData) {
		stateResult.text = "State Restarted";
	}
	#endregion
}
