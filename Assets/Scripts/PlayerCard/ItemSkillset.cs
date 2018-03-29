using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemSkillset : MonoBehaviour {
	SkillsetInfo mInfo;
	SetSkillEvent mOffEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetEmpty(){
		mInfo = null;
		transform.FindChild("LblName").gameObject.SetActive(false);
		transform.FindChild("LblLv").gameObject.SetActive(false);
		transform.FindChild("LblAddPoint").gameObject.SetActive(false);
		transform.FindChild("SprIcon").gameObject.SetActive(false);
		transform.FindChild("LblDesc").gameObject.SetActive(false);
		transform.FindChild("SprEmpty").gameObject.SetActive(true);
		transform.FindChild("LblEmpty").gameObject.SetActive(true);
		transform.FindChild("Button").FindChild("SprPlus").gameObject.SetActive(true);
		transform.FindChild("Button").FindChild("SprUnlock").gameObject.SetActive(false);
	}

	public void Set(SkillsetInfo skill){
		mInfo = skill;
		transform.FindChild("LblName").gameObject.SetActive(true);
		transform.FindChild("LblLv").gameObject.SetActive(true);
		transform.FindChild("LblAddPoint").gameObject.SetActive(true);
		transform.FindChild("SprIcon").gameObject.SetActive(true);
		transform.FindChild("LblDesc").gameObject.SetActive(true);
		transform.FindChild("SprEmpty").gameObject.SetActive(false);
		transform.FindChild("LblEmpty").gameObject.SetActive(false);
		transform.FindChild("Button").FindChild("SprPlus").gameObject.SetActive(false);
		transform.FindChild("Button").FindChild("SprUnlock").gameObject.SetActive(true);

		transform.FindChild("SprIcon").GetComponent<UISprite>().spriteName
			= "skill_icon_bg_"+skill.itemClass;
		transform.FindChild("SprIcon").FindChild("Icon").GetComponent<UISprite>().spriteName
			= SkillsetInfo.GetSkillImgDic()[skill.itemCode];
		transform.FindChild("SprIcon").FindChild("Level").GetComponent<UISprite>().spriteName
			= "skill_icon_lv_"+skill.itemLevel;

		transform.FindChild("LblLv").FindChild("Label").GetComponent<UILabel>().text = skill.itemClass+"";
		transform.FindChild("LblAddPoint").FindChild("Label").GetComponent<UILabel>().text = skill.addPoint;
		transform.FindChild("LblName").GetComponent<UILabel>().text
			= UtilMgr.IsMLB() ? skill.itemName : Localization.language.Equals("English") ? skill.itemName : skill.itemNameKor;
		transform.FindChild("LblDesc").GetComponent<UILabel>().text
			= UtilMgr.IsMLB() ? skill.itemDesc : Localization.language.Equals("English") ? skill.itemDesc : skill.itemDescKor;
	}

	public void OnClick(){
		int slot = int.Parse(transform.name.Substring(transform.name.Length-1, 1));
		if(mInfo == null){
			transform.root.FindChild("SkillList").GetComponent<SkillList>().Init(
				transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().mCardInfo, slot);
			transform.root.FindChild("PlayerCard").gameObject.SetActive(false);
			return;
		}
		string name = UtilMgr.IsMLB() ? mInfo.itemName : Localization.language.Equals("English") ? mInfo.itemName : mInfo.itemNameKor;
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("LblSkillset"),
		                         string.Format(UtilMgr.GetLocalText("StrOffSkill"), name, 50),
		                         DialogueMgr.DIALOGUE_TYPE.YesNo, DiagHandler);
	}

	void DiagHandler(DialogueMgr.BTNS btn){
		if(btn == DialogueMgr.BTNS.Btn1){
			if(UserMgr.UserInfo.gold < 50){
				DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrError"), UtilMgr.GetLocalText("StrNotEnoughGold2"), DialogueMgr.DIALOGUE_TYPE.Alert, null);
				return;
			}
			mOffEvent = new SetSkillEvent(ReceivedOff);
			NetMgr.OffSkill(transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().mCardInfo, mInfo,
			                int.Parse(transform.name.Substring(transform.name.Length-1, 1)), mOffEvent);

		}
	}

	void ReceivedOff(){
		if(mOffEvent.Response.code == 0){
			UserMgr.UserInfo.gold -= 50;
			List<SkillsetInfo> dock = transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().mCardInfo.dockingSkill;
			int slot = int.Parse(transform.name.Substring(transform.name.Length-1, 1));
			foreach(SkillsetInfo info in dock){
				if(info.dockingCardSlot == slot){
					dock.Remove(info);
					break;
				}
			}
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().InitCardInfo();
		}
	}
}
