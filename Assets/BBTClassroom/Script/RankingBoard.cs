using UnityEngine;
using System.Collections;
using BehaviourMachine;
using UnityEngine.UI;

[NodeInfo ( category = "Action/GameKit/",
	icon = "CharacterController")]
public class RankingBoard : ActionNode {

	public GameObjectVar firstText;
	public GameObjectVar secondText;
	public GameObjectVar thirdText;
	public GameObjectVar forthText;
	public GameObjectVar fifthText;
	public FloatVar gameTime;
	public ColorVar updatedColor;

	private Rigidbody r;

	private float[] scores;
	private bool firstInit;
	private string levelName;

	public override void Reset () {
		firstText 	= new ConcreteGameObjectVar();
		secondText 	= new ConcreteGameObjectVar();
		thirdText 	= new ConcreteGameObjectVar();
		forthText 	= new ConcreteGameObjectVar();
		fifthText 	= new ConcreteGameObjectVar();
		gameTime 	= new ConcreteFloatVar();
		updatedColor = new ConcreteColorVar();

		levelName = UnityEngine.SceneManagement.SceneManager.GetActiveScene().name;

		scores = new float[5];
	}

	public override Status Update () {

		if(firstText.Value == null) {
			return Status.Error;
		}
		if(secondText.Value == null) {
			return Status.Error;
		}
		if(thirdText.Value == null) {
			return Status.Error;
		}
		if(forthText.Value == null) {
			return Status.Error;
		}
		if(fifthText.Value == null) {
			return Status.Error;
		}

		if(!firstInit) {
			firstInit = true;
			scores[0] = PlayerPrefs.GetFloat(levelName + ".1st", 99.99f);
			scores[1] = PlayerPrefs.GetFloat(levelName + ".2nd", 99.99f);
			scores[2] = PlayerPrefs.GetFloat(levelName + ".3rd", 99.99f);
			scores[3] = PlayerPrefs.GetFloat(levelName + ".4th", 99.99f);
			scores[4] = PlayerPrefs.GetFloat(levelName + ".5th", 99.99f);
			firstText.Value.GetComponent<Text>().text = string.Format("1st {0:F2} sec.", scores[0]);
			secondText.Value.GetComponent<Text>().text = string.Format("2nd {0:F2} sec.", scores[1]);
			thirdText.Value.GetComponent<Text>().text = string.Format("3rd {0:F2} sec.", scores[2]);
			forthText.Value.GetComponent<Text>().text = string.Format("4th {0:F2} sec.", scores[3]);
			fifthText.Value.GetComponent<Text>().text = string.Format("5th {0:F2} sec.", scores[4]);
		}

		var oldValue = gameTime.Value;
		bool firstUpdated = false;

		if(scores[0] > oldValue) {
			Text t = firstText.Value.GetComponent<Text>();
			var s = scores[0];
			scores[0] = oldValue;
			t.text = string.Format("1st {0:F2} sec.", oldValue);
			if(!firstUpdated) {
				t.color = updatedColor.Value;
				firstUpdated = true;
			}
			PlayerPrefs.SetFloat(levelName + ".1st", oldValue);
			oldValue = s;
		}

		oldValue = Mathf.Max(oldValue, gameTime.Value);
		if(scores[1] > oldValue) {
			Text t = secondText.Value.GetComponent<Text>();
			var s = scores[1];
			scores[1] = oldValue;
			t.text = string.Format("2nd {0:F2} sec.", oldValue);
			if(!firstUpdated) {
				t.color = updatedColor.Value;
				firstUpdated = true;
			}
			PlayerPrefs.SetFloat(levelName + ".2nd", oldValue);
			oldValue = s;
		}

		oldValue = Mathf.Max(oldValue, gameTime.Value);
		if(scores[2] > oldValue) {
			Text t = thirdText.Value.GetComponent<Text>();
			var s = scores[2];
			scores[2] = oldValue;
			t.text = string.Format("3rd {0:F2} sec.", oldValue);
			if(!firstUpdated) {
				t.color = updatedColor.Value;
				firstUpdated = true;
			}
			PlayerPrefs.SetFloat(levelName + ".3rd", oldValue);
			oldValue = s;
		}

		oldValue = Mathf.Max(oldValue, gameTime.Value);
		if(scores[3] > oldValue) {
			Text t = forthText.Value.GetComponent<Text>();
			var s = scores[3];
			scores[3] = oldValue;
			t.text = string.Format("4th {0:F2} sec.", oldValue);
			if(!firstUpdated) {
				t.color = updatedColor.Value;
				firstUpdated = true;
			}
			PlayerPrefs.SetFloat(levelName + ".4th", oldValue);
			oldValue = s;
		}

		oldValue = Mathf.Max(oldValue, gameTime.Value);
		if(scores[4] > oldValue) {
			Text t = fifthText.Value.GetComponent<Text>();
			var s = scores[4];
			scores[4] = oldValue;
			t.text = string.Format("5th {0:F2} sec.", oldValue);
			if(!firstUpdated) {
				t.color = updatedColor.Value;
				firstUpdated = true;
			}
			PlayerPrefs.SetFloat(levelName + ".5th", oldValue);
			oldValue = s;
		}

		return Status.Success;
	}
}
