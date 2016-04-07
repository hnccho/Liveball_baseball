using UnityEngine;
using System.Collections;
using System.Text;
using System.Collections.Generic;
using System.IO;

public class TeamScheduleInfoRequest : BaseRequest {

	public TeamScheduleInfoRequest()
	{	
		mDic = this;
	}
	public override string GetType ()
	{
		return "apps.ginfo";
	}

	public override string GetQueryId()
	{
		return "getTeamScheduleMLB";
	}

}
