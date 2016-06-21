using UnityEngine;
using System.Collections;

public class BtnExpand : MonoBehaviour {
	ExpandInvenEvent mExpandEvent;
	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("LblMoreCards3"),
		                         string.Format(UtilMgr.GetLocalText("StrExpand"), UserMgr.LobbyInfo.expandPriceOfCard)
		                         ,DialogueMgr.DIALOGUE_TYPE.YesNo, DiagExpand);
	}

	void DiagExpand(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			mExpandEvent = new ExpandInvenEvent(ReceivedExpand);
			NetMgr.ExpandCardInven(mExpandEvent);
		}
	}

	void ReceivedExpand(){
//		DialogueMgr.ShowDialogue(mExpandEvent.Response.data.userInvenOfCard
		if(mExpandEvent.Response.code == 0)
			UserMgr.LobbyInfo.userInvenOfCard = mExpandEvent.Response.data.userInvenOfCard;

		mCardEvent = new GetCardInvenEvent(ReceivedCards);
		NetMgr.GetCardInven(mCardEvent);
	}
	
	void ReceivedCards(){
		mMailEvent = new GetMailEvent(ReceivedMails);
		NetMgr.GetUserMailBox(mMailEvent);
	}
	
	void ReceivedMails(){
		UserMgr.CardList = mCardEvent.Response.data;
		transform.root.FindChild("MyCards").GetComponent<MyCards>().Init(mCardEvent,
		                                                                 mMailEvent);
	}
}
