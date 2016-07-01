using UnityEngine;
using System.Collections;

public class Manager : MonoBehaviour {

	public GameObject deck;
	public GameObject title;
	public GameObject startbu;
	public string Canv = "Canvas/Canvas";
	public string burstCan = "Canvas/burstCan";
	public static int plNum = 0;
	public static string[] List = new string[52];
	public PlayerScore playerScore;
	public EnemyScore enemyScore;
	public judge judgeobj;

	public static int plSco = 0;
	public static int enSco = 0;
	public static int Aflag = 0;

	// Use this for initialization
	public void Startbutton () {
		title = GameObject.Find ("TitleCan/Title");
		startbu = GameObject.Find ("TitleCan/Start");

		title.SetActive (false);
		startbu.SetActive (false);

		//string[] List = new string[52];

		List[0] = "Trumps/C01";
		List[1] = "Trumps/C02";
		List[2] = "Trumps/C03";
		List[3] = "Trumps/C04";
		List[4] = "Trumps/C05";
		List[5] = "Trumps/C06";
		List[6] = "Trumps/C07";
		List[7] = "Trumps/C08";
		List[8] = "Trumps/C09";
		List[9] = "Trumps/C10";
		List[10] = "Trumps/C11";
		List[11] = "Trumps/C12";
		List[12] = "Trumps/C13";
		List[13] = "Trumps/D01";
		List[14] = "Trumps/D02";
		List[15] = "Trumps/D03";
		List[16] = "Trumps/D04";
		List[17] = "Trumps/D05";
		List[18] = "Trumps/D06";
		List[19] = "Trumps/D07";
		List[20] = "Trumps/D08";
		List[21] = "Trumps/D09";
		List[22] = "Trumps/D10";
		List[23] = "Trumps/D11";
		List[24] = "Trumps/D12";
		List[25] = "Trumps/D13";
		List[26] = "Trumps/H01";
		List[27] = "Trumps/H02";
		List[28] = "Trumps/H03";
		List[29] = "Trumps/H04";
		List[30] = "Trumps/H05";
		List[31] = "Trumps/H06";
		List[32] = "Trumps/H07";
		List[33] = "Trumps/H08";
		List[34] = "Trumps/H09";
		List[35] = "Trumps/H10";
		List[36] = "Trumps/H11";
		List[37] = "Trumps/H12";
		List[38] = "Trumps/H13";
		List[39] = "Trumps/S01";
		List[40] = "Trumps/S02";
		List[41] = "Trumps/S03";
		List[42] = "Trumps/S04";
		List[43] = "Trumps/S05";
		List[44] = "Trumps/S06";
		List[45] = "Trumps/S07";
		List[46] = "Trumps/S08";
		List[47] = "Trumps/S09";
		List[48] = "Trumps/S10";
		List[49] = "Trumps/S11";
		List[50] = "Trumps/S12";
		List[51] = "Trumps/S13";

		System.Random rdm = new System.Random ();
		int n = 52;
		while (n > 1) {
			n--;
			int k = rdm.Next (n + 1);
			string tmp = List[k];
			List[k] = List[n];
			List[n] = tmp;
		}

		//Debug.Log (List[0]);

		GameObject first = (GameObject)Resources.Load ((string)List[0]);
		GameObject second = (GameObject)Resources.Load ((string)List[1]);
		GameObject third = (GameObject)Resources.Load ((string)List[2]);

		Instantiate(second, new Vector3(-2.0f,-3.0f,0.0f), transform.rotation);
		Instantiate(first, new Vector3(-3.0f,-3.0f,0.0f), transform.rotation);
		Instantiate(third, new Vector3(-3.0f,3.0f,0.0f), transform.rotation);

		int aaa = int.Parse(List [0].Remove (0, 8));
		int bbb = int.Parse(List [1].Remove (0, 8));
		enSco = int.Parse(List [2].Remove (0, 8));

		//Debug.Log (aaa);
		//Debug.Log (bbb);

		if (aaa >= 10) {
			aaa = 10;
		}

		if (aaa == 1) {
			aaa = 11;
			Aflag++;;
		}

		if (bbb >= 10) {
			bbb = 10;
		}

		if (bbb == 1) {
			bbb = 11;
			Aflag++;
		}

		if (enSco >= 10) {
			enSco = 10;
		}

		if (enSco == 1) {
			enSco = 11;
		}

		plSco = aaa + bbb;

		while (plSco >= 22) {
			if (Aflag > 0) {
				plSco = plSco - 10;
			} else {
				break;
			}
		}

		//Debug.Log (plSco);
		//plSco = 21;

		playerScore.GetComponent<PlayerScore> ().plscore = plSco;
		enemyScore.GetComponent<EnemyScore> ().enscore = enSco;

		if (plSco == 21) {
			judgeobj.GetComponent<judge> ().judgeflag = 2;
			GameObject burstMSG = (GameObject)Resources.Load (burstCan);
			Instantiate (burstMSG, transform.position, transform.rotation);
		}else{

			GameObject selectbu = (GameObject)Resources.Load (Canv);

			//Debug.logger.Log ("test",selectbu);

			Instantiate (selectbu, transform.position, transform.rotation);


			//Debug.Log (Manager.plNum);
		}
	}
		
		
	public void GameOver()
	{
		title.SetActive (true);
		startbu.SetActive (true);
	}
}
