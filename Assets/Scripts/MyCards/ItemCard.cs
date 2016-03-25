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
		if((mCardInfo.cardClass >= CardInfo.CLASS_MAX) && (mCardInfo.cardLevel >= CardInfo.LEVEL_MAX)){

		} else if(mCardInfo.cardLevel > 4){
			transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().Init(mCardInfo,
	             transform.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture,
	             UtilMgr.GetLocalText("LblCardRankUp"), CardPowerUp.TYPE.RANKUP);
		} else{
			transform.root.FindChild("CardPowerUp").GetComponent<CardPowerUp>().Init(mCardInfo,
	             transform.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().mainTexture,
	             UtilMgr.GetLocalText("LblCardLevelUp"), CardPowerUp.TYPE.LEVELUP);
		}
		UtilMgr.AddBackState(UtilMgr.STATE.CardPowerUp);
		UtilMgr.AnimatePageToLeft("MyCards", "CardPowerUp");
	}

	public void OnBtnPhotoClick(){
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().InitWithCard(mCardInfo,
			transform.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").
			GetComponent<UITexture>().mainTexture);
	}
}
