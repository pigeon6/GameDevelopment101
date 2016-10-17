using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "Action/GameObject/",
	icon = "CharacterController")]
public class CountGameObjectsByTag : ActionNode {

	public StringVar tag;
	public IntVar count;

	public override void Reset () {
		tag 		= new ConcreteStringVar();
		count = new ConcreteIntVar();
	}

	public override void Awake () {
	}

	public override Status Update () {

		if(tag.Value == null) {
			return Status.Error;
		}

		GameObject[] objects = GameObject.FindGameObjectsWithTag(tag.Value);

		count.Value = objects.Length;

		return Status.Success;
	}
}
