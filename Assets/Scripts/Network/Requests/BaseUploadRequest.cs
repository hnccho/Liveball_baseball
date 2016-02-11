using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BaseUploadRequest{

	WWWForm mForm = new WWWForm();

	public void AddField(string key, string value){
		mForm.AddField (key, value);
	}

	public void AddField(string key, int value){
		mForm.AddField (key, value);
	}

	public void AddBinaryData(string key, byte[] bytes, string fileName, string mimeType)
	{
		mForm.AddBinaryData(key, bytes, fileName, mimeType);
	}

	public WWWForm GetRequestWWWForm()
	{
		AddField("type", GetType());
		AddField("id", GetQueryId());

		return mForm;
	}

	public virtual string GetType(){return null;}
	public virtual string GetQueryId(){return null;}

}
