using UnityEngine;
using System.Collections;
using System.Text;

public class GetPlayerListRequest : BaseRequest {

	public GetPlayerListRequest(int positionNo)
	{
		Add ("positionNo", positionNo);

		mDic = this;

	}

	public override string GetType ()
	{
		return "apps.ginfo";
	}

	public override string GetQueryId()
	{
		return "getPlayerListMLB";
	}

}
