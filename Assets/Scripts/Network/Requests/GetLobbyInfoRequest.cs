using UnityEngine;
using System.Collections;
using System.Text;

public class GetLobbyInfoRequest : BaseRequest {

	public GetLobbyInfoRequest(int memSeq)
	{
		Add ("memSeq", memSeq);

		mDic = this;

	}

	public override string GetType ()
	{
		return "apps.ginfo";
	}

	public override string GetQueryId()
	{
		return "getMainInfo";
	}

}
