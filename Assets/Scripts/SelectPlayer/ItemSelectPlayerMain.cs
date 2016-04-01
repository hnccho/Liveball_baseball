using UnityEngine;
using System.Collections;

public class ItemSelectPlayerMain : MonoBehaviour {

	public PlayerInfo mPlayerInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadImage(){
		UtilMgr.LoadImage(mPlayerInfo.photoUrl
	      , transform.FindChild("BtnPhoto")
              .FindChild("Panel").FindChild("TxtPlayer").GetComponent<UITexture>());
	}

	public void OnBtnRightClick(){
		transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().SetDesignated(mPlayerInfo);
		UtilMgr.OnBackPressed();
	}
	
	public void OnBtnPhotoClick(){
		transform.root.FindChild("PlayerCard").localPosition = Vector3.zero;
		if(UtilMgr.IsMLB()){
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(mPlayerInfo,
				transform.FindChild("MLB").FindChild("BtnPhoto").FindChild("Panel").FindChild("TxtPlayer").
				GetComponent<UITexture>().mainTexture);	
		} else{
			transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(mPlayerInfo,
				transform.FindChild("KBO").FindChild("BtnPhoto").FindChild("Panel").FindChild("TxtPlayer").
				GetComponent<UITexture>().mainTexture);	
		}

	}
}
