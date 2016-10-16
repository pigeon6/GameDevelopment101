using UnityEngine;
using System.Collections;
using BehaviourMachine;

[NodeInfo ( category = "Action/Math/",
	icon = "CharacterController")]
public class QuaternionAngleAxis : ActionNode {

	public FloatVar angle;
	public Vector3Var angleVector;
	public Vector3Var setVector;
	public FloatVar angleMultiplier;

	public override void Reset () {
		angle 		= new ConcreteFloatVar();
		angleVector = new ConcreteVector3Var();
		setVector 	= new ConcreteVector3Var();
		angleMultiplier = new ConcreteFloatVar();
	}

	public override void Awake () {
	}

	public override Status Update () {

		setVector.Value = Quaternion.AngleAxis (angle.Value * angleMultiplier.Value, angleVector.Value) * setVector.Value;

		return Status.Success;
	}
}
