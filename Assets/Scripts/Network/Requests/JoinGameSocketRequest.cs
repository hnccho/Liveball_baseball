using UnityEngine;
using System.Collections;
using System.Text;

public class JoinGameSocketRequest : BaseSocketRequest {

	public JoinGameSocketRequest()
	{
		Add ("type", ConstantsSocketType.REQ.TYPE_JOIN);
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("memberEamil", UserMgr.UserInfo.memberEmail);
		Add ("memberName", UserMgr.UserInfo.memberName);
		Add ("imagePath", "");
		Add ("imageName", "");
//		Add ("gameSeq", UserMgr.GameSeq);
		Add ("gameSeq", UserMgr.Schedule.gameSeq);
		Debug.Log ("JoinGameSocketRequest");
		Debug.Log (UserMgr.Schedule.gameSeq);
		mDic = this;
	}
}
