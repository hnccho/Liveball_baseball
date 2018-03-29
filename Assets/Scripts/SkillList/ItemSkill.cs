using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSkill : MonoBehaviour {
	SkillsetInfo mInfo;
	SetSkillEvent mSkillEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(SkillsetInfo info){
		mInfo = info;

		transform.FindChild("BtnPhoto").FindChild("BG").GetComponent<UISprite>().spriteName
			= "skill_icon_bg_"+info.itemClass;
		transform.FindChild("BtnPhoto").FindChild("Icon").GetComponent<UISprite>().spriteName
			= SkillsetInfo.GetSkillImgDic()[info.itemCode];
		transform.FindChild("BtnPhoto").FindChild("Grade").GetComponent<UISprite>().spriteName
			= "skill_icon_lv_"+info.itemLevel;

		transform.FindChild("LblTitle").GetComponent<UILabel>().text
			= UtilMgr.IsMLB() ? info.itemName :
				Localization.language.Equals("English") ? info.itemName : info.itemNameKor;

		transform.FindChild("LblDesc").GetComponent<UILabel>().text
			= UtilMgr.IsMLB() ? info.itemDesc :
				Localization.language.Equals("English") ? info.itemDesc : info.itemDescKor;
	}

	public void OnClick(){
		int positionNo = transform.root.FindChild("SkillList").GetComponent<SkillList>().mCardInfo.positionNo;
		if(positionNo == 1){
			if(mInfo.position == 1){
				DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"), UtilMgr.GetLocalText("StrPosError"),
			    	                     DialogueMgr.DIALOGUE_TYPE.Alert, null);
				return;
			}
		} else{
			if(mInfo.position == 2){
				DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"), UtilMgr.GetLocalText("StrPosError"),
			    	                     DialogueMgr.DIALOGUE_TYPE.Alert, null);
				return;
			}
		}

		string name = UtilMgr.IsMLB() ? mInfo.itemName : Localization.language.Equals("English") ? mInfo.itemName : mInfo.itemNameKor;
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("LblSkillset"),
		                         string.Format(UtilMgr.GetLocalText("StrSetSkill"), name), DialogueMgr.DIALOGUE_TYPE.YesNo, DiagHandler);
	}

	void DiagHandler(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			mSkillEvent = new SetSkillEvent(ReceivedSet);
			NetMgr.SetSkill(transform.root.FindChild("SkillList").GetComponent<SkillList>().mCardInfo,
			                mInfo, transform.root.FindChild("SkillList").GetComponent<SkillList>().mIdx, mSkillEvent);
		}
	}

	void ReceivedSet(){
		if(mSkillEvent.Response.code == 0){
			List<SkillsetInfo> dock = transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().mCardInfo.dockingSkill;
			int slot = transform.root.FindChild("SkillList").GetComponent<SkillList>().mIdx;
			foreach(SkillsetInfo info in dock){
				if(info.dockingCardSlot == slot){
					dock.Remove(info);
					break;
				}
			}
			mInfo.dockingYn = 1;
			mInfo.dockingCardSlot = slot;
			dock.Add(mInfo);
			UtilMgr.OnBackPressed();
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().InitCardInfo();
		}
	}
}
