using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "Action/Cursor/",
	icon = "CharacterController")]
public class HideCursor : ActionNode {

	public BoolVar hideCursor;

	public override void Reset () {
		hideCursor 	= new ConcreteBoolVar();
	}

	public override void Awake () {
		Cursor.visible = !hideCursor.Value;
	}

	public override Status Update () {

		Cursor.visible = !hideCursor.Value;

		return Status.Success;
	}
}
