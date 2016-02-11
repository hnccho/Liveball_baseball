using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseCSRequest : List<CSParamItem>{

	public string ToRequestString()
	{
		string param = "UserKey="+UserMgr.UserInfo.memSeq+"&AppKey="+Constants.CS_APP_KEY;

		foreach(CSParamItem pi in this){
			param += ("&" + pi.Key + "=" + pi.Value);
		}

		return param;
	}

	public virtual string GetQueryId(){return null;}

}
