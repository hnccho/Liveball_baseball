using UnityEngine;
using System.Collections;

public class TopMenuBtns : MonoBehaviour {

	GetCardInvenEvent mCardEvent;
	GetMailEvent mMailEvent;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){

		if(name.Equals("BtnMyCards")){
			mCardEvent = new GetCardInvenEvent(ReceivedCards);
			NetMgr.GetCardInven(mCardEvent);
		} else if(name.Equals("BtnUpcoming")){
			
		} else if(name.Equals("BtnLive")){
			
		} else if(name.Equals("BtnRecent")){
			
		}
	}

	void ReceivedCards(){
		mMailEvent = new GetMailEvent(ReceivedMail);
		NetMgr.GetUserMailBox(mMailEvent);
	}

	void ReceivedMail(){
		UtilMgr.AddBackState(UtilMgr.STATE.MyCards);
		UtilMgr.AnimatePage(UtilMgr.DIRECTION.ToLeft,
		                    transform.root.FindChild("Lobby").gameObject,
		                    transform.root.FindChild("MyCards").gameObject);
		transform.root.FindChild("MyCards").GetComponent<MyCards>().Init(mCardEvent, mMailEvent);
	}
}
