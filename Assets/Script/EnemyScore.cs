using UnityEngine;
using System.Collections;
using UnityEngine.UI; 

public class EnemyScore : MonoBehaviour {

	public int enscore = 0;

	// Update is called once per frame
	void Update () {
		this.GetComponent<Text>().text = enscore.ToString();
	}
}
