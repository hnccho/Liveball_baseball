using UnityEngine;
using System.Collections;

public class ItemCard : MonoBehaviour {

	public CardInfo mCardInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(mCardInfo == null) return;

		if((mCardInfo.cardClass >= CardInfo.CLASS_MAX) && (mCardInfo.cardLevel >= CardInfo.LEVEL_MAX)){
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_compt";
			transform.FindChild("BtnRight").GetComponent<UIButton>().isEnabled = false;
		} else if(mCardInfo.cardLevel > 4){
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_upgrade";
		} else{
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_powerup";
		}
	}

	public void OnBtnRightClick(){
		if(mCardInfo.useYn > 0){
			DialogueMgr.ShowDialogue("InUse", "InUse", DialogueMgr.DIALOGUE_TYPE.Alert, null);
			return;
		}else if((mCardInfo.cardClass >= CardInfo.CLASS_MAX) && (mCardInfo.cardLevel >= CardInfo.LEVEL_MAX)){
			return;
		} else if(mCardInfo.cardLevel > 4){
			if(UtilMgr.IsMLB()){
				transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>()
					.Init(mCardInfo,transform.FindChild("MLB").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture")
					      .GetComponent<UITexture>().mainTexture, UtilMgr.GetLocalText("LblCardRankUp"), CardPowerUp.TYPE.RANKUP);
			} else{
				transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>()
					.Init(mCardInfo,transform.FindChild("KBO").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture")
					      .GetComponent<UITexture>().mainTexture, UtilMgr.GetLocalText("LblCardRankUp"), CardPowerUp.TYPE.RANKUP);
			}

		} else{
			if(UtilMgr.IsMLB()){
				transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>()
					.Init(mCardInfo, transform.FindChild("MLB").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture")
					      .GetComponent<UITexture>().mainTexture, UtilMgr.GetLocalText("LblCardPowerUp"), CardPowerUp.TYPE.LEVELUP);
			} else{
				transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>()
					.Init(mCardInfo, transform.FindChild("KBO").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture")
					      .GetComponent<UITexture>().mainTexture, UtilMgr.GetLocalText("LblCardPowerUp"), CardPowerUp.TYPE.LEVELUP);
			}
		}
		UtilMgr.AddBackState(UtilMgr.STATE.CardPowerUp);
		UtilMgr.AnimatePageToLeft("MyCards", "CardPowerUp");
	}

	public void OnBtnPhotoClick(){
		if(UtilMgr.IsMLB()){
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>()
				.InitWithCard(mCardInfo, transform.FindChild("MLB").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").
				GetComponent<UITexture>().mainTexture);
		} else{
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>()
				.InitWithCard(mCardInfo, transform.FindChild("KBO").FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").
				GetComponent<UITexture>().mainTexture);
		}
	}
}
