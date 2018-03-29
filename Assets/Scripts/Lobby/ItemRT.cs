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
			UtilMgr.LoadImage(mEventInfo.currentHitterId,
		                  transform.FindChild("Players").FindChild("Left").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());		
		
			UtilMgr.LoadImage(mEventInfo.currentPitcherId,
		                  transform.FindChild("Players").FindChild("Right").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		} else{
			UtilMgr.LoadImage(mEventInfo.currentHitterId,
		                  transform.FindChild("Players").FindChild("Right").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		
			UtilMgr.LoadImage(mEventInfo.currentPitcherId,
		                  transform.FindChild("Players").FindChild("Left").FindChild("Frame")
		                  .FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>());
		}
	}

	public void EnterClick(){
//		UtilMgr.AddBackState(UtilMgr.STATE.Bingo);
//		UtilMgr.AnimatePageToLeft("Lobby", "Bingo");
		UserMgr.eventJoined = mEventInfo;
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().Init();
	}

	public void LeftClick(){
		if(mEventInfo.inningHalf.Equals("T")){
			if(mEventInfo.currentHitterId < 1)
				return;

			PlayerInfo info = UserMgr.PlayerDic[mEventInfo.currentHitterId];
//			foreach( in UserMgr.PlayerList){
//				if(info.playerId == ){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Left").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
//					break;
//				}
//			}
		} else{
			if(mEventInfo.currentPitcherId < 1)
				return;

			PlayerInfo info = UserMgr.PlayerDic[mEventInfo.currentPitcherId];
//			foreach( in List){
//				if(info.playerId == ){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Left").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
//					break;
//				}
//			}
		}
	}

	public void RightClick(){
		if(mEventInfo.inningHalf.Equals("T")){
			if(mEventInfo.currentPitcherId < 1)
				return;

			PlayerInfo info = UserMgr.PlayerDic[mEventInfo.currentPitcherId];
//			foreach( in List){
//				if(info.playerId == ){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
//					break;
//				}
//			}
		} else{
			if(mEventInfo.currentHitterId < 1)
				return;
			PlayerInfo info = UserMgr.PlayerDic[mEventInfo.currentHitterId];
//			foreach( in List){
//				if(info.playerId == ){
					transform.root.FindChild("PlayerCard").GetComponent<PlayerCard>().Init(
						info,
						transform.FindChild("Players").FindChild("Right").FindChild("Frame")
						.FindChild("Photo").FindChild("TxtPlayer").GetComponent<UITexture>().mainTexture);	
//					break;
//				}
//			}
		}
	}
}
