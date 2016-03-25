using UnityEngine;
using System.Collections;

public class BtnSelectFeeding : MonoBehaviour {

	public CardInfo mCardInfo;
	public bool IsSelected;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ShowNomore(){
		DialogueMgr.ShowDialogue("Error", "You can't adds a card no more.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
	}

	public void OnClick(){
		if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mType == CardPowerUp.TYPE.LEVELUP){
			if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count >= 4){
				ShowNomore();
				return;
			}

			if(IsSelected){
				IsSelected = false;
				transform.GetComponent<UIButton>().defaultColor = new Color(0, 106f/255f, 206f/255f);
				transform.GetComponent<UIButton>().hover = new Color(0, 106f/255f, 206f/255f);
				for(int i = 0; i < transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count; i++){
					CardInfo info = transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList[i];
					if(info.playerFK == mCardInfo.playerFK){
						transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.RemoveAt(i);
						break;
					}
				}
			} else{
				IsSelected = true;
				transform.GetComponent<UIButton>().defaultColor = new Color(1f, 91f/255f, 16f/255f);
				transform.GetComponent<UIButton>().hover = new Color(1f, 91f/255f, 16f/255f);
				transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Add(mCardInfo);
				Debug.Log("CardInfo is "+mCardInfo.playerName);
			}

			transform.root.FindChild("SelectFeeding").FindChild("Top").FindChild("LblSelected").FindChild("Label")
				.GetComponent<UILabel>().text = 
					transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count+"/4";
		} else{
			if(transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count >= 1){
				ShowNomore();
				return;
			}

			transform.root.FindChild("SelectFeeding").FindChild("Top").FindChild("LblSelected").FindChild("Label")
				.GetComponent<UILabel>().text = 
					transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().mCardFeedList.Count+"/1";
		}


	}
}
