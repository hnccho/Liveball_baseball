using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseSocketRequest : Dictionary<string, object>{
	protected Dictionary<string, object> mDic;

	public string ToRequestString()
	{

//	{"type":5001,"memSeq":222,"memberEmail":"aaaa@aaaa.com","memberName":"afafdasdf","imagePath":"eee/","imageName":"aaaa.png","gameSeq":0}
		string str = "";

//		str = JsonFx.Json.JsonWriter.Serialize (mDic);
		str = Newtonsoft.Json.JsonConvert.SerializeObject(mDic);

		return str;
	}

}
