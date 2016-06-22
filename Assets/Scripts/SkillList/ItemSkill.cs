using UnityEngine;
using System.Collections;

public class ItemSkill : MonoBehaviour {
	SkillsetInfo mInfo;

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
}
