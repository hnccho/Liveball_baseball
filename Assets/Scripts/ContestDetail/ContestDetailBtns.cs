using UnityEngine;
using System.Collections;

public class ContestDetailBtns : MonoBehaviour {
	
	public GameObject mChangeables;
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void OnClick(){
		for(int i = 0; i < 4; i++){
			transform.parent.GetChild(i).FindChild("Sprite").gameObject.SetActive(false);
			transform.parent.GetChild(i).GetComponentInChildren<UILabel>().color
				= new Color(153f/255f, 153f/255f, 153f/255f);
			mChangeables.transform.GetChild(i).gameObject.SetActive(false);
		}
		transform.FindChild("Sprite").gameObject.SetActive(true);
		transform.GetComponentInChildren<UILabel>().color = new Color(1f, 1f, 1f);
		
		switch(name){
		case "BtnEntries":
			mChangeables.transform.FindChild("Entries").gameObject.SetActive(true);
			break;
		case "BtnGames":
			mChangeables.transform.FindChild("Games").gameObject.SetActive(true);
			break;
		case "BtnPrizes":
			mChangeables.transform.FindChild("Prizes").gameObject.SetActive(true);
			break;
		case "BtnRules":
			mChangeables.transform.FindChild("Rules").gameObject.SetActive(true);
			break;
		}
	}
}