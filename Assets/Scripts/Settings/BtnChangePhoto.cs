using UnityEngine;
using System.Collections;

public class BtnChangePhoto : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void OnClick(){
		if(Application.platform == RuntimePlatform.Android){
			AndroidMgr.OpenGallery(new EventDelegate(OpenGallery));
		} else if(Application.platform == RuntimePlatform.IPhonePlayer){
			IOSMgr.OpenGallery(new EventDelegate(OpenGallery));
		}
	}

	void OpenGallery(){
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
		
//		tempTex = UtilMgr.ScaleTexture (tempTex, (int)UsetPhotoSize.x, (int)UsetPhotoSize.y);
//		SettingPage.transform.FindChild ("Panel").FindChild ("Photo").GetComponent<UITexture> ().mainTexture = tempTex;
		byte[] bytes = tempTex.EncodeToPNG();
//		SetMemberPhoto (bytes);
	}
}
