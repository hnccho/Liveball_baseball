using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SkillList : MonoBehaviour {
	SkillsetListEvent mSkillEvent;
	public CardInfo mCardInfo;
	public int mIdx;
	List<SkillsetInfo> mList;

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

	public void Reload(){
		if(mCardInfo == null)
			Init ();
		else
			Init (mCardInfo, mIdx);
	}

	public void Init(){
		mIdx = 0;
		mCardInfo = null;
		mSkillEvent = new SkillsetListEvent(ReceivedSkill);
		NetMgr.SkillsetList(mSkillEvent);
	}

	public void Init(CardInfo info, int idx){
		mIdx = idx;
		mCardInfo = info;
		mSkillEvent = new SkillsetListEvent(ReceivedSkill);
		NetMgr.SkillsetList(mSkillEvent);
	}

	void ReceivedSkill(){
		transform.gameObject.SetActive(true);

		mList = new List<SkillsetInfo>();
		foreach(SkillsetInfo skill in mSkillEvent.Response.data){
			if(skill.dockingYn == 0)
				mList.Add(skill);
		}

		transform.FindChild("Top").FindChild("Skills").FindChild("LblSkillsV").GetComponent<UILabel>().text
			= mList.Count+" / "+UserMgr.LobbyInfo.userInvenOfSkill;

		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().RemoveAll();
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().Init(
			mList.Count, delegate(UIListItem item, int index) {
			SkillsetInfo info = mList[index];
			item.Target.transform.GetComponent<ItemSkill>().Init(info);

			if(mCardInfo == null){
				item.Target.transform.FindChild("BtnRight").gameObject.SetActive(false);
			} else{
				item.Target.transform.FindChild("BtnRight").gameObject.SetActive(true);
			}
		});
		transform.FindChild("Body").FindChild("Draggable").GetComponent<UIDraggablePanel2>().ResetPosition();

		if(UtilMgr.GetLastBackState() != UtilMgr.STATE.SkillList){
			UtilMgr.AddBackState(UtilMgr.STATE.SkillList);
			UtilMgr.AnimatePageToLeft("MyCards", "SkillList");
		}
	}
}
