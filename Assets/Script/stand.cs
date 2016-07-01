using UnityEngine;
using System.Collections;

public class stand : MonoBehaviour {

	public GameObject hitbu;
	public string encard;
	public int endrow = 0;
	public string burstCan = "Canvas/burstCan";
	public judge judgeobj;
	public EnemyScore enemyScore;

	// Use this for initialization
	public void StandButton () {

		hitbu = GameObject.Find ("hit");
		Destroy (hitbu);
		Destroy (gameObject);
		Manager.Aflag = 0;

		while (Manager.enSco <= Manager.plSco) {
			Debug.Log ("standwhile");
			float firstcard = -2.0f;
			float secondcard = -1.0f;
			float thirdcard = 0.0f;
			float fourthcard = 1.0f;
			float fifthcard = 2.0f;
			float sixthcard = 3.0f;
			float seventhcard = 4.0f;
			int n = Manager.plNum + 3;
		
			encard = Manager.List [n];
		
			Manager.plNum ++;
			endrow++;
		
			GameObject drowcard = (GameObject)Resources.Load (encard);
		
			switch (endrow)
			{
			case 1:
				Instantiate (drowcard, new Vector3 (firstcard, 3.0f, 0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;
		
			case 2:
				Instantiate(drowcard, new Vector3(secondcard,3.0f,0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;
		
			case 3:
				Instantiate(drowcard, new Vector3(thirdcard,3.0f,0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;
		
			case 4:
				Instantiate(drowcard, new Vector3(fourthcard,3.0f,0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;
		
			case 5:
				Instantiate(drowcard, new Vector3(fifthcard,3.0f,0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;
		
			case 6:
				Instantiate (drowcard, new Vector3 (sixthcard, 3.0f, 0.0f), transform.rotation);
		
				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);
		
				break;

			case 7:
				Instantiate (drowcard, new Vector3 (seventhcard, 3.0f, 0.0f), transform.rotation);

				EnScoreAdd (encard);
				//yield return new WaitForSeconds (3);

				break;
			}


		}
		if (Manager.enSco == 21) {

			judgeobj.GetComponent<judge> ().judgeflag = 3;
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);
		
		} else if (Manager.enSco == Manager.plSco) {

			judgeobj.GetComponent<judge> ().judgeflag = 6;
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);

		} else if (Manager.enSco < Manager.plSco) {

			judgeobj.GetComponent<judge> ().judgeflag = 4;
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);

		} else if (Manager.enSco > Manager.plSco){

			judgeobj.GetComponent<judge> ().judgeflag = 5;
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);

		}
	}


	public void EnScoreAdd(string tmp)
	{

		int aaa = int.Parse(tmp.Remove (0, 8));

		Debug.Log ("enscobf=" + aaa.ToString());

		if (aaa >= 10) {
			aaa = 10;
		}

		if (aaa == 1) {
			aaa = 11;
			Manager.Aflag++;;
		}

		Debug.Log ("enscoaft=" + aaa.ToString());

		Manager.enSco = Manager.enSco + aaa;

		while(Manager.enSco >= 22){
			if (Manager.Aflag > 0) {
				Manager.plSco = Manager.plSco - 10;
			} else {
				judgeobj.GetComponent<judge> ().judgeflag = 0;
				GameObject burstMSG = (GameObject)Resources.Load (burstCan);
				Instantiate (burstMSG, transform.position, transform.rotation);
				break;
			}

		}

		Debug.Log (Manager.enSco);

		enemyScore.GetComponent<EnemyScore> ().enscore = Manager.enSco;
	}
}

