using UnityEngine;
using System.Collections;

public class BtnOpenPack : MonoBehaviour {

//	public Mailinfo mMail;
	OpenCardPackEvent mOpenEvent;
	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		Mailinfo info = transform.parent.parent.GetComponent<ItemInvenCard>().mCardInfo.mMailinfo;
		mOpenEvent = new OpenCardPackEvent(ReceivedPack);
		NetMgr.OpenCardPack(info.mailSeq, info.itemFK, mOpenEvent);
	}

	void ReceivedPack(){
		DialogueMgr.ShowDialogue("Success", "Cards Received!", DialogueMgr.DIALOGUE_TYPE.Alert, ReloadHandler);
	
	}

	void ReloadHandler(DialogueMgr.BTNS btn){
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
