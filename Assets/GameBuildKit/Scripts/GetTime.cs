using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "Action/Time/",
	icon = "CharacterController")]
public class GetTime : ActionNode {

	public FloatVar newTime;

	public override void Reset () {
		newTime 	= new ConcreteFloatVar();
	}

	public override Status Update () {

		newTime.Value = Time.time;

		return Status.Success;
	}
}
