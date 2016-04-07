using UnityEngine;
using System.Collections;

public class BtnPosition : MonoBehaviour {

	PlayerInfo mPlayerInfo;
	public enum STATE{
		Undesignated,
		Designated
	}
	public STATE mState;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void SetUndesignated(){
		transform.FindChild("Undesignated").gameObject.SetActive(true);
		transform.FindChild("Designated").gameObject.SetActive(false);
		mState = STATE.Undesignated;
	}

	public void SetDesignated(PlayerInfo info){
		mPlayerInfo = info;
		transform.FindChild("Undesignated").gameObject.SetActive(false);
		transform.FindChild("Designated").gameObject.SetActive(true);
		mState = STATE.Designated;

		transform.FindChild("Designated").FindChild("LblLF").GetComponent<UILabel>().text = mPlayerInfo.position;
		transform.FindChild("Designated").FindChild("LblSaraly").GetComponent<UILabel>().text
			= "$" + UtilMgr.AddsThousandsSeparator(mPlayerInfo.salary);
		if(Localization.language.Equals("English")){
			transform.FindChild("Designated").FindChild("LblName").GetComponent<UILabel>().text
				= mPlayerInfo.firstName.Substring(0, 1) + ". " + mPlayerInfo.lastName;
		} else{
			transform.FindChild("Designated").FindChild("LblName").GetComponent<UILabel>().text
				= mPlayerInfo.korName;
		}

	}

	public void OnClick(){
		UtilMgr.AddBackState(UtilMgr.STATE.SelectPlayer);
		UtilMgr.AnimatePageToLeft("RegisterEntry", "SelectPlayer");
		transform.root.FindChild("SelectPlayer").GetComponent<SelectPlayer>()
			.Init(int.Parse(transform.FindChild("Label").GetComponent<UILabel>().text));
	}
}
