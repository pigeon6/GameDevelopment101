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

		if(scores[0] > gameTime.Value) {
			Text t = firstText.Value.GetComponent<Text>();
			scores[0] = gameTime.Value;
			t.text = string.Format("1st {0:F2} sec.", gameTime.Value);
			t.color = updatedColor.Value;
			PlayerPrefs.SetFloat(levelName + ".1st", gameTime.Value);
		}

		else if(scores[1] > gameTime.Value) {
			Text t = secondText.Value.GetComponent<Text>();
			scores[1] = gameTime.Value;
			t.text = string.Format("2nd {0:F2} sec.", gameTime.Value);
			t.color = updatedColor.Value;
			PlayerPrefs.SetFloat(levelName + ".2nd", gameTime.Value);
		}

		else if(scores[2] > gameTime.Value) {
			Text t = thirdText.Value.GetComponent<Text>();
			scores[2] = gameTime.Value;
			t.text = string.Format("3rd {0:F2} sec.", gameTime.Value);
			t.color = updatedColor.Value;
			PlayerPrefs.SetFloat(levelName + ".3rd", gameTime.Value);
		}

		else if(scores[3] > gameTime.Value) {
			Text t = forthText.Value.GetComponent<Text>();
			scores[3] = gameTime.Value;
			t.text = string.Format("4th {0:F2} sec.", gameTime.Value);
			t.color = updatedColor.Value;
			PlayerPrefs.SetFloat(levelName + ".4th", gameTime.Value);
		}

		else if(scores[4] > gameTime.Value) {
			Text t = fifthText.Value.GetComponent<Text>();
			scores[4] = gameTime.Value;
			t.text = string.Format("5th {0:F2} sec.", gameTime.Value);
			t.color = updatedColor.Value;
			PlayerPrefs.SetFloat(levelName + ".5th", gameTime.Value);
		}

		return Status.Success;
	}
}
