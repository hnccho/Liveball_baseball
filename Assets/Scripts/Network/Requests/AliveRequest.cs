using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class AliveRequest : BaseSocketRequest {

	public AliveRequest()
	{
		Dictionary<string, object> data = new Dictionary<string, object>();
		data.Add("time", 0);
		Add ("type", ConstantsSocketType.REQ.TYPE_ALIVE);
		Add ("code", 0);
		Add ("msg", "");
		Add ("data", data);
		mDic = this;
	}
}
