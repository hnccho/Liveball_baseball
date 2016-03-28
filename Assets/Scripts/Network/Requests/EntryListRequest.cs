using UnityEngine;
using System.Collections;
using System.Text;

public class EntryListRequest : BaseRequest {

	public EntryListRequest(int contestSeq)
	{
		Add ("contestSeq", contestSeq);

		mDic = this;
	}

	public override string GetType ()
	{
		return "apps.contest";
	}

	public override string GetQueryId()
	{
		return "contestGetEntryList";
	}

}
