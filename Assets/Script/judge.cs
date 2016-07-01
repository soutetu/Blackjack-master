using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class judge : MonoBehaviour {

	public int judgeflag = 0;

	// Update is called once per frame
	void Start () {

		switch (judgeflag)
		{
		//if (judgeflag == 1) {
		case 0:
			this.GetComponent<Text> ().text = "Bust!\nYou Win!";
			break;

		//} else {

		case 1:
			this.GetComponent<Text> ().text = "Bust!\nYou Lose!";
			break;

		case 2:
			this.GetComponent<Text> ().text = "Black Jack!\nYou Win!";
			break;

		case 3:
			this.GetComponent<Text> ().text = "Black Jack!\nYou Lose!";
			break;

		case 4:
			this.GetComponent<Text> ().text = "You Win!";
			break;

		case 5:
			this.GetComponent<Text> ().text = "You Lose!";
			break;

		case 6:
			this.GetComponent<Text> ().text = "Drow!";
			break;


		}
	}
}

