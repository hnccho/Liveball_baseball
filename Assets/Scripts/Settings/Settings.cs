using UnityEngine;
using System.Collections;

public class Settings : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		transform.localPosition = new Vector3(2000f, 0);
		transform.gameObject.SetActive(true);

		transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.GetComponent<UILabel>().text = UserMgr.UserInfo.nick;
		int width = transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.GetComponent<UILabel>().width;
		transform.FindChild("Body").FindChild("Scroll View").FindChild("User").FindChild("LblName")
			.FindChild("BtnEdit").localPosition = new Vector3(width + 40, 0);

		transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();

		UtilMgr.RemoveBackState(UtilMgr.STATE.Profile);
		UtilMgr.AnimatePageToLeft(UtilMgr.GetLastBackState().ToString(), "Settings");
		UtilMgr.AddBackState(UtilMgr.STATE.Settings);

//		UtilMgr.AnimatePageToLeft(UtilMgr.
	}
}
