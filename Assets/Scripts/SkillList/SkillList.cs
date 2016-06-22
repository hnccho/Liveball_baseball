using UnityEngine;
using System.Collections;

public class SkillList : MonoBehaviour {
	SkillsetListEvent mSkillEvent;
	CardInfo mCardInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public bool OnClose(){
		if(mCardInfo != null){
			return true;
		} else
			return false;
	}

	public void Init(){
		mCardInfo = null;
		mSkillEvent = new SkillsetListEvent(ReceivedSkill);
		NetMgr.SkillsetList(mSkillEvent);
	}

	public void Init(CardInfo info){
		mCardInfo = info;
		mSkillEvent = new SkillsetListEvent(ReceivedSkill);
		NetMgr.SkillsetList(mSkillEvent);
	}

	void ReceivedSkill(){
		transform.gameObject.SetActive(true);
		transform.FindChild("Top").FindChild("Skills").FindChild("LblSkillsV").GetComponent<UILabel>().text
			= mSkillEvent.Response.data.Count+" / "+UserMgr.LobbyInfo.userInvenOfSkill;

		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().Init(
			mSkillEvent.Response.data.Count, delegate(UIListItem item, int index) {
			SkillsetInfo info = mSkillEvent.Response.data[index];
			item.Target.transform.GetComponent<ItemSkill>().Init(info);

			if(mCardInfo == null){
				item.Target.transform.FindChild("BtnRight").gameObject.SetActive(false);
			} else{
				item.Target.transform.FindChild("BtnRight").gameObject.SetActive(true);
			}
		});

		if(UtilMgr.GetLastBackState() != UtilMgr.STATE.SkillList){
			UtilMgr.AddBackState(UtilMgr.STATE.SkillList);
			UtilMgr.AnimatePageToLeft("MyCards", "SkillList");
		}
	}
}
