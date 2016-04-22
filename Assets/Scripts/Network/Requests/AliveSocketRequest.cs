using UnityEngine;
using System.Collections;
using System.Text;

public class AliveSocketRequest : BaseSocketRequest {

	public AliveSocketRequest()
	{
		Add ("type", ConstantsSocketType.REQ.TYPE_ALIVE);
		Add ("memSeq", UserMgr.UserInfo.memSeq);
		mDic = this;
	}
}
