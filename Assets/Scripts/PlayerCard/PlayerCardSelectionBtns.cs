using UnityEngine;
using System.Collections;

public class PlayerCardSelectionBtns : MonoBehaviour {

	public GameObject mChangeables;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		for(int i = 0; i < 3; i++){
			transform.parent.GetChild(i).FindChild("Sprite").gameObject.SetActive(false);
			mChangeables.transform.GetChild(i).gameObject.SetActive(false);
		}
		transform.FindChild("Sprite").gameObject.SetActive(true);

		switch(name){
		case "BtnGameLog":
			mChangeables.transform.FindChild("GameLog").gameObject.SetActive(true);
			break;
		case "BtnAnalysis":
			mChangeables.transform.FindChild("Analysis").gameObject.SetActive(true);
			break;
		case "BtnCard":
			mChangeables.transform.FindChild("Card").gameObject.SetActive(true);
			break;
		}
	}
}
