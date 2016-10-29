using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "Action/GameKit/",
	icon = "CharacterController")]
public class MoveTo : ActionNode {

	public GameObjectVar objectToMove;
	public FloatVar tStart;
	public FloatVar durationSec;
	public Vector3Var moveFrom;
	public Vector3Var moveTo;
	public FsmEvent onCompleteEvent;

	private Rigidbody r;

	public override void Reset () {
		objectToMove 	= new ConcreteGameObjectVar();
		durationSec 	= new ConcreteFloatVar();
		moveTo 			= new ConcreteVector3Var();
		onCompleteEvent = new ConcreteFsmEvent();
	}

	public override Status Update () {

		if(objectToMove.Value == null) {
			return Status.Error;
		}
		if(durationSec.Value <= 0.0f ) {
			return Status.Error;
		}

		var startPos = moveFrom.Value;
		var targetPos = moveTo.Value;

		var t = Mathf.Clamp01( (Time.time - tStart) / durationSec.Value);
		//Debug.Log("t:" + t + " dur:" + durationSec.Value + "now:" + (Time.time - tStart));

		var v = Vector3.Lerp(startPos, targetPos, t);

		objectToMove.Value.transform.position = v;

		if(t >= 1.0f) {
			var m = self.GetComponent<StateMachine>();
			m.SendEvent(onCompleteEvent.id);
		}

		return Status.Success;
	}
}
