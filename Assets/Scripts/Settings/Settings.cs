using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Reset(){
		transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.GetComponent<UILabel>().text = UserMgr.UserInfo.nick;
		int width = transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.GetComponent<UILabel>().width;
		transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.FindChild("BtnEdit").localPosition = new Vector3(width + 40, 0);
		transform.FindChild("Body").FindChild("Rename").gameObject.SetActive(false);
		transform.FindChild ("Body").FindChild("Rename").FindChild("Box").FindChild("Input")
			.GetComponent<UIInput>().value = UserMgr.UserInfo.nick;
		UtilMgr.LoadUserImage(UserMgr.UserInfo.photoUrl,
		                  transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("Photo")
		                  .FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
	}

	public void Init(){
		transform.localPosition = new Vector3(2000f, 0);
		transform.gameObject.SetActive(true);

		Reset();

		transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();


		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);
		UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Settings");
		UtilMgr.AddBackState(UtilMgr.STATE.Settings);

//		UtilMgr.AnimatePageToLeft(UtilMgr.
	}
}
