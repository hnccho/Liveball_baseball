using UnityEngine;
using System.Collections;
using System.Text;

public class GetDoneMailboxRequset : BaseRequest {

	public GetDoneMailboxRequset(int memSeq,int mailSeq,int attachSeq)
	{
		Add ("memSeq", memSeq);
		Add ("mailSeq", mailSeq);
		Add ("attachSeq", attachSeq);

//		mParams = JsonFx.Json.JsonWriter.Serialize (this);
		mDic = this;

	}

	public override string GetType ()
	{
		return "apps";
	}

	public override string GetQueryId()
	{
		return "doneMailbox";
	}

}
