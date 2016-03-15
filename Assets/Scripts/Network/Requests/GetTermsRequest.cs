using UnityEngine;
using System.Collections;
using System.Text;

public class GetTermsRequest : BaseRequest {
	
	public GetTermsRequest()
	{
		mDic = this;		
	}
	
	public override string GetType ()
	{
		return "apps.ginfo";
	}
	
	public override string GetQueryId()
	{
		return "getEventListMLB";
	}

}
