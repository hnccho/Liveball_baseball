using UnityEngine;
using System.Collections;
using System.Text;

public class GetCheckMailboxRequset : BaseRequest {

	public GetCheckMailboxRequset(int memSeq,int mailSeq)
	{
		Add ("memSeq", memSeq);
		Add ("mailSeq", mailSeq);
	

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "checkMailbox";
	}

}
