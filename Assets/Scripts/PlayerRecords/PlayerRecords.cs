using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerRecords : MonoBehaviour {

	List<PlayerInfo> mSortedList;

	public enum TYPE{
		PITCHER,
		HITTER
	}
	public TYPE mType = TYPE.PITCHER;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(){
		transform.localPosition = new Vector3(2000f, 2000f);
		transform.gameObject.SetActive(true);

		Buildup();

		UtilMgr.AddBackState(UtilMgr.STATE.PlayerRecords);
		UtilMgr.AnimatePageToLeft("Lobby", "PlayerRecords");
	}

	public void Buildup(){
		mSortedList = new List<PlayerInfo>();
		Transform tf = null;
		if(mType == TYPE.PITCHER){
			transform.FindChild("Top").FindChild("Pitcher").gameObject.SetActive(true);
			transform.FindChild("Top").FindChild("Hitter").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrPitcherRecords");
			transform.FindChild("Top").FindChild("BtnSwitch").FindChild("Label")
				.GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrSwitchToHitter");

			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.positionNo == 1)
					mSortedList.Add(info);
			}

			tf = transform.FindChild("Top").FindChild("Pitcher");
		} else{
			transform.FindChild("Top").FindChild("Pitcher").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("Hitter").gameObject.SetActive(true);
			transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrHitterRecords");
			transform.FindChild("Top").FindChild("BtnSwitch").FindChild("Label")
				.GetComponent<UILabel>().text = UtilMgr.GetLocalText("StrSwitchToPitcher");

			foreach(PlayerInfo info in UserMgr.PlayerList){
				if(info.positionNo > 1)
					mSortedList.Add(info);
			}

			tf = transform.FindChild("Top").FindChild("Hitter");
		}

		if(tf.FindChild("BtnFP").GetComponent<BtnsColumn>().mSort == BtnsColumn.SORT.DESC){
			mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
				return x.fppg.CompareTo(y.fppg);
			});
		} else{
			mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
				return y.fppg.CompareTo(x.fppg);
			});
		}
//		if(SubInSub.SelectedPeople == SubInSub.PeopleSorting.PeopleAsc){
//			infoList.Sort(delegate(ContestListInfo x, ContestListInfo y) {
//				return x.totalPreset.CompareTo(y.totalPreset);
//			});
//		} else if(SubInSub.SelectedPeople == SubInSub.PeopleSorting.PeopleDesc){
//			infoList.Sort(delegate(ContestListInfo x, ContestListInfo y) {
//				return y.totalPreset.CompareTo(x.totalPreset);
//			});


		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().RemoveAll();
		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().Init(
			mSortedList.Count, delegate(UIListItem item, int index) {
			item.Target.transform.FindChild("LblName").GetComponent<UILabel>()
				.text = Localization.language.Equals("English")
					? mSortedList[index].firstName.Substring(0, 1) + ". " + mSortedList[index].lastName
					: mSortedList[index].korName;

			if(mType == TYPE.PITCHER){
				item.Target.transform.FindChild("5").GetComponent<UILabel>()
					.text = string.Format("{0:F1}", mSortedList[index]._IP);
				item.Target.transform.FindChild("2").GetComponent<UILabel>()
					.text = mSortedList[index]._PH+"";
				item.Target.transform.FindChild("3").GetComponent<UILabel>()
					.text = mSortedList[index]._BB+"";
				item.Target.transform.FindChild("1").GetComponent<UILabel>()
					.text = mSortedList[index]._SO+"";
				item.Target.transform.FindChild("6").GetComponent<UILabel>()
					.text = string.Format("{0:F2}", mSortedList[index]._ER);
				item.Target.transform.FindChild("4").GetComponent<UILabel>()
					.text = mSortedList[index]._W+"";

			} else{
				item.Target.transform.FindChild("1").GetComponent<UILabel>()
					.text = mSortedList[index]._AB+"";
				item.Target.transform.FindChild("2").GetComponent<UILabel>()
					.text = mSortedList[index]._H+"";
				item.Target.transform.FindChild("3").GetComponent<UILabel>()
					.text = mSortedList[index]._HR+"";
				item.Target.transform.FindChild("5").GetComponent<UILabel>()
					.text = string.Format("{0:F3}", mSortedList[index]._OBP);
				item.Target.transform.FindChild("6").GetComponent<UILabel>()
					.text = string.Format("{0:F3}", mSortedList[index]._AVG);
				item.Target.transform.FindChild("4").GetComponent<UILabel>()
					.text = mSortedList[index]._K+"";
			}
			item.Target.transform.FindChild("LblFP").GetComponent<UILabel>()
				.text = string.Format("{0:F1}", mSortedList[index].fppg);
		});

		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().ResetPosition();
	}

	public void Switch(){
		if(mType == TYPE.PITCHER){
			mType = TYPE.HITTER;
		} else{
			mType = TYPE.PITCHER;
		}

		Buildup();
	}
}
