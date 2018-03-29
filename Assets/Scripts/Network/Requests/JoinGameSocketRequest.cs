using UnityEngine;
using System.Collections;
using System.Text;

public class JoinGameSocketRequest : BaseSocketRequest {

	public JoinGameSocketRequest()
	{
		Add ("type", ConstantsSocketType.REQ.TYPE_JOIN);
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		Add ("gameId", UserMgr.eventJoined.gameId);
		mDic = this;
	}
}
