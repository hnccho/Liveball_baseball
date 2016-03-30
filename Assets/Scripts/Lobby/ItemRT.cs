using UnityEngine;
using System.Collections;

public class ItemRT : MonoBehaviour {

	public EventInfo mEventInfo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadImage(){
		if(mEventInfo.inningHalf.Equals("T")){
			UtilMgr.LoadImage(mEventInfo.hitterPhoto,
		                  transform.FindChild("Players").FindChild("Left").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());		
		
			UtilMgr.LoadImage(mEventInfo.pitcherPhoto,
		                  transform.FindChild("Players").FindChild("Right").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		} else{
			UtilMgr.LoadImage(mEventInfo.hitterPhoto,
		                  transform.FindChild("Players").FindChild("Right").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		
			UtilMgr.LoadImage(mEventInfo.pitcherPhoto,
		                  transform.FindChild("Players").FindChild("Left").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		}
	}

	public void EnterClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.Bingo);
		UtilMgr.AnimatePageToLeft("Lobby", "Bingo");
	}
}
