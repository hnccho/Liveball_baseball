using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CSGetListResponse : BaseCSResponse{

	public string RecvCode;

	public List<CSAppInfo> mList = new List<CSAppInfo>();

	public class CSAppInfo{
		public string mName;
		public string mKey;
		public string mIcon;
		public string mText;
		public string mReward;
	}

	public CSGetListResponse(string data){
		string[] split1 = data.Split('|');
		RecvCode = split1[0];
		if(RecvCode.Equals("1")){
			for(int i = 1; i < split1.Length; i++){
				string[] split2 = split1[i].Split('&');
				CSAppInfo info = new CSAppInfo();
				try{
					info.mName = split2[0]; //Debug.Log("mName is "+split2[0]);
					info.mKey = split2[1]; //Debug.Log("mKey is "+split2[1]);
					info.mIcon = split2[2]; //Debug.Log("mIcon is "+split2[2]);
					info.mText = split2[3]; //Debug.Log("mText is "+split2[3]);
					info.mReward = split2[4]; //Debug.Log("mReward is "+split2[4]);
					mList.Add(info);
				} catch{
					break;
				}
			}
		} else
			LogError(split1);
	}
}
