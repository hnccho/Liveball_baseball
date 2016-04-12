using UnityEngine;
using System.Collections;

public class BtnChangePhoto : MonoBehaviour {

	string mTempFile;
	GetProfileEvent mProfileEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(Application.platform == RuntimePlatform.Android){
			AndroidMgr.OpenGallery(new EventDelegate(ReceivedGallery));
		} else if(Application.platform == RuntimePlatform.IPhonePlayer){
			IOSMgr.OpenGallery(new EventDelegate(ReceivedGallery));
		}
	}

	void ReceivedGallery(){
		Debug.Log("ReceivedGallery");
		string image = "";
		if(Application.platform == RuntimePlatform.Android){
			image = "file://"+ AndroidMgr.GetMsg();
		} else{
			image = "file://"+ IOSMgr.GetMsg();
		}
		WWW www = new WWW(image);
		StartCoroutine(LoadImage(www));
	}

	IEnumerator LoadImage(WWW www)
	{
		yield return www;
		Texture2D tempTex= new Texture2D(0, 0);
		www.LoadImageIntoTexture(tempTex);
		www.Dispose ();

		int width = tempTex.width;
		int height = tempTex.height;
		float targetWidth = 0;
		float targetHeight = 0;
		if(width > height){
			float ratio = 200f / width;
			targetWidth = width * ratio;
			targetHeight = height * ratio;
		} else{
			float ratio = 200f / height;
			targetWidth = width * ratio;
			targetHeight = height * ratio;
		}
		Debug.Log("width : "+targetWidth+", height : "+targetHeight);
		tempTex = UtilMgr.ScaleTexture (tempTex, (int)targetWidth, (int)targetHeight);
		byte[] bytes = tempTex.EncodeToPNG();
		mTempFile = UtilMgr.GetDateTimeNow("yyyyMMddHHmmss.png");
		mTempFile = Application.temporaryCachePath + "/" + mTempFile;
		try{
			System.IO.File.WriteAllBytes(mTempFile, bytes);
		} catch{
			mTempFile = "";
		}

		UploadFile();
	}

	void UploadFile(){
		Debug.Log("file name is "+mTempFile);
		if(mTempFile == null || mTempFile.Length < 1){

			return;
		}

		mProfileEvent = new GetProfileEvent(new EventDelegate(ReceivedProfile));
		JoinMemberInfo memberInfo = new JoinMemberInfo();
		memberInfo.Photo = mTempFile;
		NetMgr.UpdateMemberInfo(memberInfo, mProfileEvent, false, true);
	}

    void ReceivedProfile(){
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrRegSucceed")
		                         , UtilMgr.GetLocalText("StrSuccessPhoto"), DialogueMgr.DIALOGUE_TYPE.Alert, null);
		System.IO.File.Delete(mTempFile);
		UserMgr.UserInfo.photoUrl = mProfileEvent.Response.data.photoUrl;
//		Debug.Log("imageName : "+mProfileEvent.Response.data.imageName);
		transform.root.FindChild("Settings").GetComponent<Settings>().Reset();
	}
}
