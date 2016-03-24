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

		if(mCardInfo.cardClass > 5){
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_compt";
			transform.FindChild("BtnRight").GetComponent<UIButton>().isEnabled = false;
		} else if(mCardInfo.cardLevel > 4){
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_upgrade";
		} else{
			transform.FindChild("BtnRight").GetComponent<UIButton>().normalSprite = "mycard_btn_powerup";
		}
	}

	public void OnBtnRightClick(){

	}

	public void OnBtnPhotoClick(){
		transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().InitWithCard(mCardInfo,
			transform.FindChild("BtnPhoto").FindChild("Panel").FindChild("Texture").
			GetComponent<UITexture>().mainTexture);
	}
}
