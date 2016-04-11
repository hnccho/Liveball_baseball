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

	public void LeftClick(){
		if(mEventInfo.inningHalf.Equals("T")){
			if(mEventInfo.currentHitterId < 1)
				return;

			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.playerId == mEventInfo.currentHitterId){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Left").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
					break;
				}
			}
		} else{
			if(mEventInfo.currentPitcherId < 1)
				return;

			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.playerId == mEventInfo.currentPitcherId){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Left").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
					break;
				}
			}
		}
	}

	public void RightClick(){
		if(mEventInfo.inningHalf.Equals("T")){
			if(mEventInfo.currentPitcherId < 1)
				return;
			
			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.playerId == mEventInfo.currentPitcherId){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
					break;
				}
			}
		} else{
			if(mEventInfo.currentHitterId < 1)
				return;
			
			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.playerId == mEventInfo.currentHitterId){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
					break;
				}
			}
		}
	}
}
