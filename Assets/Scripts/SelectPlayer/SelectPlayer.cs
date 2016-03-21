using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SelectPlayer : MonoBehaviour {

	List<PlayerInfo> mPlayerList;
	public int mSelectedNo;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(int positionNo){
		mSelectedNo = positionNo;
		string title = "";
		switch(positionNo){
		case 1: title = UtilMgr.GetLocalText("StrPitcher"); break;
		case 2: title = UtilMgr.GetLocalText("StrCatcher"); break;
		case 3: title = UtilMgr.GetLocalText("StrFirstBaseman"); break;
		case 4: title = UtilMgr.GetLocalText("StrSecondBaseman"); break;
		case 5: title = UtilMgr.GetLocalText("StrThirdBaseman"); break;
		case 6: title = UtilMgr.GetLocalText("StrShortstop"); break;
		case 7: title = UtilMgr.GetLocalText("StrLeftFielder"); break;
		case 8: title = UtilMgr.GetLocalText("StrCenterFielder"); break;
		case 9: title = UtilMgr.GetLocalText("StrRightFielder"); break;
		}
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>()
			.text = UtilMgr.GetLocalText("StrSelect") + " " + title;

		mPlayerList = new List<PlayerInfo>();
		List<int> posList = new List<int>();
		if(positionNo == 3){
			posList.Add(10);
			posList.Add(12);
		} else if((positionNo > 2) && (positionNo < 7)){
			posList.Add(12);
		} else if(positionNo > 6){
			posList.Add(11);
		}
		posList.Add(positionNo);
		foreach(PlayerInfo info in UserMgr.PlayerList){
			foreach(int no in posList){
				if(info.positionNo == no){
					mPlayerList.Add(info);
					//get CardInvenInfo then add them
				}
			}
		}

		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>()
			.Init(mPlayerList.Count, delegate(UIListItem item, int index) {
				PlayerInfo info = mPlayerList[index];
				if(info.IsCard){
					item.Target.transform.FindChild("Main").gameObject.SetActive(false);
					item.Target.transform.FindChild("Sub").gameObject.SetActive(true);
				} else{
					item.Target.transform.FindChild("Main").gameObject.SetActive(true);
					item.Target.transform.FindChild("Sub").gameObject.SetActive(false);

					Transform tf = item.Target.transform.FindChild("Main");
//					StartCoroutine(
//						LoadImage(info.photoUrl,
//					          tf.FindChild("BtnPhoto").FindChild("TxtPlayer").GetComponent<UITexture>()));
					UtilMgr.LoadImage(info.photoUrl
					                  , tf.FindChild("BtnPhoto").FindChild("TxtPlayer").GetComponent<UITexture>());
					tf.FindChild("BtnRight").GetComponent<BtnPlayerSelected>().mPlayerInfo = info;
					tf.FindChild("LblPosition").GetComponent<UILabel>().text = info.position;
					tf.FindChild("LblName").GetComponent<UILabel>().text = info.firstName + " " + info.lastName;
					tf.FindChild("LblTeam").GetComponent<UILabel>().text = info.teamName;
					tf.FindChild("LblYear").GetComponent<UILabel>().gameObject.SetActive(false);
					tf.FindChild("LblSalary").GetComponent<UILabel>().text = "$ "+UtilMgr.AddsThousandsSeparator(info.salary);

				}
			});
		transform.FindChild("Body").FindChild("Scroll").GetComponent<UIDraggablePanel2>().ResetPosition();
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
}
