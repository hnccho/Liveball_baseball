using UnityEngine;
using System.Collections;

public class ItemPosition : MonoBehaviour {

	public PlayerInfo mPlayerInfo;
	public BtnPosition.STATE mState;
	bool mNeedPhoto;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(mNeedPhoto){
//			StartCoroutine(LoadImage(mPlayerInfo.photoUrl, transform.FindChild("Photo").GetComponent<UITexture>()));
			UtilMgr.LoadImage(mPlayerInfo.playerId, transform.FindChild("Photo").GetComponent<UITexture>());
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

		if(Localization.language.Equals("English")){
			transform.FindChild("Designated").FindChild("LblTeam")
				.GetComponent<UILabel>().text = info.city + " " + info.teamName;
			transform.FindChild("Designated").FindChild("LblName")
				.GetComponent<UILabel>().text = info.firstName + " " + info.lastName;
			if(transform.FindChild("Designated").FindChild("LblName").GetComponent<UILabel>().width > 232)
				transform.FindChild("Designated").FindChild("LblName").GetComponent<UILabel>().text
					= info.firstName.Substring(0, 1) + ". " +info.lastName;
		} else{
			transform.FindChild("Designated").FindChild("LblTeam")
				.GetComponent<UILabel>().text = info.korTeamName;
			transform.FindChild("Designated").FindChild("LblName")
				.GetComponent<UILabel>().text = info.korName;
		}

		TeamScheduleInfo schedule = null;
		foreach(TeamScheduleInfo team in UserMgr.ScheduleList){
			if(info.team == team.awayTeamId
			   || info.team == team.homeTeamId){
				if(team.dateTime.Equals(
					transform.root.FindChild("RegisterEntry").GetComponent<RegisterEntry>().mContestInfo.startTime)){
					schedule = team;
					break;
				}
			}
		}
		
		if(schedule != null){
			transform.FindChild("Designated").FindChild("LblYear").GetComponent<UILabel>().text			
				= schedule.awayTeam + "  @  " + schedule.homeTeam;
		} else
			transform.FindChild("Designated").FindChild("LblYear").gameObject.SetActive(false);
	}

	public void SetUndesignated(){
		mPlayerInfo = null;
		mState = BtnPosition.STATE.Undesignated;
		if(Localization.language.Equals("English")){
			transform.FindChild("Undesignated").FindChild("LblDesignated")
				.GetComponent<UILabel>().text = "[333333]" + UtilMgr.GetLocalText("StrSelect2") + " [-][006AD8][b]"
					+ UtilMgr.GetPosition(int.Parse(transform.FindChild("Label").GetComponent<UILabel>().text));
		} else{
			transform.FindChild("Undesignated").FindChild("LblDesignated")
				.GetComponent<UILabel>().text ="[006AD8][b]"
					+ UtilMgr.GetPosition(int.Parse(transform.FindChild("Label").GetComponent<UILabel>().text))
					+  "[-][333333] " + UtilMgr.GetLocalText("StrSelect");
		}
		transform.FindChild("Designated").gameObject.SetActive(false);
		transform.FindChild("Undesignated").gameObject.SetActive(true);
	}

//	IEnumerator LoadImage(string url, UITexture texture){
//		WWW www = new WWW(url);
//		yield return www;
//		
//		Texture2D temp = new Texture2D(0, 0, TextureFormat.ARGB4444, false);
//		www.LoadImageIntoTexture(temp);
//		texture.mainTexture = temp;
//		texture.width = 130;
//		www.Dispose();
//	}

	public PlayerInfo GetPlayerInfo(){
		return mPlayerInfo;
	}
}
