using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseNanooRequest{
	protected string mParam;

	public enum API_TYPE{
		EVENT,
		NOTICE
	}

	public API_TYPE mType;

	public string ToRequestString()
	{
//		string str = mParam + "key=" + Constants.NANOO_API_KEY;
//		string str = "key=" + Constants.NANOO_API_KEY;
//		string str = "http://partner.liveball.kr/comu/nanoo.php";
		string str = "";
		if(UtilMgr.IsTestServer()){
			if(mType == API_TYPE.EVENT)
				str = Constants.TEST_EVENT_URL;
			else{
				str = Constants.TEST_NOTICE_URL;
				if(Application.platform == RuntimePlatform.IPhonePlayer){
					str += "/nanoo/2";
				} else{
					str += "/nanoo/1";
				}
			}
		}			
		else{
			if(mType == API_TYPE.EVENT)
				str = Constants.EVENT_URL;
			else{
				str = Constants.NOTICE_URL;
				if(Application.platform == RuntimePlatform.IPhonePlayer){
					str += "/nanoo/2";
				} else{
					str += "/nanoo/1";
				}
			}
		}
			

		return str;
	}

	public string GetParam(){
		return mParam;
	}
}
