using UnityEngine;
using System.Collections;

public class BtnDebugLiveBingo : MonoBehaviour {
	bool IsShow;
	string mStrLog;
	// Use this for initialization
	void Start () {
		mStrLog = "";
		transform.parent.FindChild("Log").gameObject.SetActive(IsShow);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void OnClick(){
		IsShow = !IsShow;
		transform.parent.FindChild("Log").gameObject.SetActive(IsShow);
		if(IsShow){
			Reposition();
		}

	}

	void Reposition(){
		transform.parent.FindChild("Log").FindChild("Scroll View").FindChild("Label").GetComponent<UILabel>().text = mStrLog;
		int height = transform.parent.FindChild("Log").FindChild("Scroll View").FindChild("Label").GetComponent<UILabel>().height;
		transform.parent.FindChild("Log").FindChild("Scroll View").FindChild("Label").GetComponent<BoxCollider2D>()
			.size = new Vector2(720f, (float)height);
		transform.parent.FindChild("Log").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}
	
	public void AddLog(string log){
		mStrLog += log;
		Reposition();
	}

	public void AddLog(SocketMsgInfo info){
//		mStrLog += log;
//		string msg = "\n[00ff00][" + UtilMgr.GetDateTimeNow("HH:mm:ss") + "]" + "Send:7000[-]";
		string value = "\n[" + UtilMgr.GetDateTimeNow("HH:mm:ss") + "]";
		switch(info.type){
		case ConstantsSocketType.RES.TYPE_JOIN: value += "[00ff00]Received:Join"; break;
		case ConstantsSocketType.RES.TYPE_ALIVE_OK: value += "[00ff00]Received:Alive"; break;
		case ConstantsSocketType.RES.RESULT_HITTER:
			value += "[ff0000]Received:ResultHitter(";
			PlayerInfo player = null;
			try{
				player = UserMgr.PlayerDic[info.data.playerId];
			} catch{
				player = new PlayerInfo();
				player.korName = "선수정보없음";
			}

			value += player.korName + "," + info.data.result + ","
				+ info.data.value + ")"; break;
		case ConstantsSocketType.RES.CHANGE_PLAYER: value += "[ff00ff]Received:ChangePlayer"; break;
		case ConstantsSocketType.RES.RELOAD_BINGO: value += "[ffff00]Received:UpdateBingo"; break;
		case ConstantsSocketType.RES.CHANGE_INNING: value += "[00ffff]Received:ChangeInning(";
			value += info.data.inning + "," + info.data.inningHalf + "," + info.data.inningState + ")"; break;
		default: value += "[ffffff]Recieved:"+info.type; break;
		}
		value += "[-],"+info.data.msgCount;
		mStrLog += value;

		Reposition();
	}
}
