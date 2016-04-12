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

	public void Reset(){
		for(int i = 0; i < 4; i++){
			transform.parent.GetChild(i).FindChild("Sprite").gameObject.SetActive(false);
			transform.parent.GetChild(i).GetComponentInChildren<UILabel>().color
				= new Color(153f/255f, 153f/255f, 153f/255f);
			mChangeables.transform.GetChild(i).gameObject.SetActive(false);
		}
		transform.FindChild("Sprite").gameObject.SetActive(true);
		transform.GetComponentInChildren<UILabel>().color = new Color(1f, 1f, 1f);
	}

	public void OnClick(){
		Reset();

		switch(name){
		case "BtnGameLog":
//			mChangeables.transform.FindChild("GameLog").gameObject.SetActive(true);
			SetGameLog();
			break;
		case "BtnAnalysis":
//			mChangeables.transform.FindChild("Analysis").gameObject.SetActive(true);
			SetAnalysis();
			break;
		case "BtnNews":
//			mChangeables.transform.FindChild("News").gameObject.SetActive(true);
			SetNews();
			break;
		case "BtnCard":
//			mChangeables.transform.FindChild("Card").gameObject.SetActive(true);
			SetCard();
			break;		
		}
	}

	public void SetNews(){
		Reset ();
		mChangeables.transform.FindChild("News").gameObject.SetActive(true);
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().SetNews();
	}

	public void SetAnalysis(){
		Reset ();
		mChangeables.transform.FindChild("Analysis").gameObject.SetActive(true);
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().SetAnalysis();
	}

	public void SetGameLog(){
		Reset ();
		mChangeables.transform.FindChild("GameLog").gameObject.SetActive(true);
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().SetGameLog();
	}

	public void SetCard(){
		Reset ();
		mChangeables.transform.FindChild("Card").gameObject.SetActive(true);
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().InitCardInfo();
	}
}
