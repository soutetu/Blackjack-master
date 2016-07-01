using UnityEngine;
using System.Collections;

public class drow : MonoBehaviour {

	public static string plcard;
	public PlayerScore playerScore;
	public string burstCan = "Canvas/burstCan";
	public judge judgeobj;
	public GameObject standbu;

	// Use this for initialization
	public void ButtonPush () {

		float firstcard = -1.0f;
		float secondcard = 0.0f;
		float thirdcard = 1.0f;
		float fourthcard = 2.0f;
		float fifthcard = 3.0f;
		float sixthcard = 4.0f;
		int n = Manager.plNum + 3;

		drow.plcard = Manager.List [n];

		Manager.plNum ++;

		GameObject drowcard = (GameObject)Resources.Load (plcard);

		switch (Manager.plNum)
		{
		case 1:
			Instantiate (drowcard, new Vector3 (firstcard, -3.0f, 0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		case 2:
			Instantiate(drowcard, new Vector3(secondcard,-3.0f,0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		case 3:
			Instantiate(drowcard, new Vector3(thirdcard,-3.0f,0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		case 4:
			Instantiate(drowcard, new Vector3(fourthcard,-3.0f,0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		case 5:
			Instantiate(drowcard, new Vector3(fifthcard,-3.0f,0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		case 6:
			Instantiate (drowcard, new Vector3 (sixthcard, -3.0f, 0.0f), transform.rotation);

			PlScoreAdd (drow.plcard);

			break;

		}
	}
	public void PlScoreAdd(string tmp)
	{

		int aaa = int.Parse(tmp.Remove (0, 8));

		Debug.Log (aaa);

		if (aaa >= 10) {
			aaa = 10;
		}

		if (aaa == 1) {
			aaa = 11;
			Manager.Aflag++;;
		}
			
		Manager.plSco = Manager.plSco + aaa;

		if (Manager.plSco == 21) {
			judgeobj.GetComponent<judge> ().judgeflag = 2;
			standbu = GameObject.Find ("stand");
			Destroy (standbu);
			Destroy (gameObject);
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);
		}

		while(Manager.plSco >= 22){
			if (Manager.Aflag > 0) {
				Manager.plSco = Manager.plSco - 10;
			} else {
				judgeobj.GetComponent<judge> ().judgeflag = 1;
				standbu = GameObject.Find ("stand");
				Destroy (standbu);
				Destroy (gameObject);
				GameObject burstMSG = (GameObject)Resources.Load (burstCan);
				Instantiate (burstMSG, transform.position, transform.rotation);
				break;
			}

		}

		Debug.Log (Manager.plSco);

		playerScore.GetComponent<PlayerScore> ().plscore = Manager.plSco;
	}
}