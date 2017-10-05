using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateUI : MonoBehaviour {


	public Text testText;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		testText.text = GameController.Instance.score.ToString();
	}
}
