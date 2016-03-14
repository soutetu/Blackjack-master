using UnityEngine;
using System.Collections;

public class drow : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject card = (GameObject)Resources.Load ("Trumps/trump_0");
		//card = (GameObject)Resources.Load("./Trumps/trump_0");
		Instantiate(card, new Vector3(0,0,0), transform.rotation);
	}
}