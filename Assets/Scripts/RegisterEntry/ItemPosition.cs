using UnityEngine;
using System.Collections;

public class ItemPosition : MonoBehaviour {

	PlayerInfo mPlayerInfo;
	public BtnPosition.STATE mState;
	bool mNeedPhoto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(mNeedPhoto){
			StartCoroutine(LoadImage(mPlayerInfo.photoUrl, transform.FindChild("Photo").GetComponent<UITexture>()));
			mNeedPhoto = false;
		}
	}

	void OnEnable(){

	}

	public void SetDesignated(PlayerInfo info){
		mPlayerInfo = info;
		mState = BtnPosition.STATE.Designated;
		transform.FindChild("Designated").gameObject.SetActive(true);
		transform.FindChild("Undesignated").gameObject.SetActive(false);

//		StartCoroutine(LoadImage(info.photoUrl, transform.FindChild("Photo").GetComponent<UITexture>()));
		mNeedPhoto = true;
		transform.FindChild("Designated").FindChild("LblPosition").GetComponent<UILabel>().text = info.position;
		transform.FindChild("Designated").FindChild("LblSalary").GetComponent<UILabel>().text = info.salary+"";
		transform.FindChild("Designated").FindChild("LblName")
			.GetComponent<UILabel>().text = info.firstName + " " + info.lastName;
	}

	public void SetUndesignated(){
		mPlayerInfo = null;
		mState = BtnPosition.STATE.Undesignated;
		transform.FindChild("Undesignated").FindChild("LblDesignated")
			.GetComponent<UILabel>().text = "[333333]Select [-][006AD8][b]"
				+ UtilMgr.GetPosition(int.Parse(transform.FindChild("Label").GetComponent<UILabel>().text));
		transform.FindChild("Designated").gameObject.SetActive(false);
		transform.FindChild("Undesignated").gameObject.SetActive(true);
	}

	IEnumerator LoadImage(string url, UITexture texture){
		WWW www = new WWW(url);
		yield return www;
		
		Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
		www.LoadImageIntoTexture(temp);
		texture.mainTexture = temp;
		texture.width = 130;
		www.Dispose();
	}

	public PlayerInfo GetPlayerInfo(){
		return mPlayerInfo;
	}
}
