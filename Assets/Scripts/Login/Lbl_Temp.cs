using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using Facebook.Unity;

public class Lbl_Temp : MonoBehaviour {

	// Use this for initialization
	void Start () {
//		TextAsset ta = Resources.Load("Liveball - sheet1", typeof(TextAsset)) as TextAsset;
//		Localization.LoadCSV(ta);
//		Localization.language = "Korean";//"Korean";
//		FB.Init(onInitComplete, onHideUnity);
//		Debug.Log("Start");
	}

//	void onInitComplete(){
//		Debug.Log("FB Init Complete");
//		List<string> permissions = new List<string>();
//		permissions.Add("email.publish_actions");
//		FB.LogInWithPublishPermissions(permissions, AuthCallback);
//	}

//	ILoginResult AuthCallback = new ILoginResult(){
//
//	};

//	void AuthCallback(ILoginResult result){
//
//	}

	void onHideUnity(bool isUnityShown){
		Debug.Log("Unity is Shown "+isUnityShown);
	}

	void Awake(){
		TextAsset ta = Resources.Load("Liveball - sheet1", typeof(TextAsset)) as TextAsset;
		Localization.LoadCSV(ta);

		if(Application.systemLanguage == SystemLanguage.Korean)
			Localization.language = "Korean";
		else
			Localization.language = "English";

	}
	
	// Update is called once per frame
	void Update () {

	}

	public void ChangeLanguage(){
		if(Localization.language.Equals("English"))
		   Localization.language = "Korean";
		else
		   Localization.language = "English";
	}
}
