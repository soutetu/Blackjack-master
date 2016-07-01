using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class PlayerScore : MonoBehaviour {

	public int plscore = 0;

	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = plscore.ToString();
	}
}
