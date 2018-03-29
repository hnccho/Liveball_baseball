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
	int mSelectedIdxPit;
	int mSelectedIdxHit;

	// Use this for initialization
	void Start () {
		mSelectedIdxPit = 7;
		mSelectedIdxHit = 7;
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

			BtnsColumn[] btns = tf.FindChild("Btns").GetComponentsInChildren<BtnsColumn>();
			foreach(BtnsColumn btn in btns){
				btn.Init();
				if(btn.IsSelected){
					if(btn.transform.name.Equals("BtnFPpit")){
						mSelectedIdxPit = 7;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x.fppg.CompareTo(y.fppg);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y.fppg.CompareTo(x.fppg);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnIP")){
						mSelectedIdxPit = 5;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._IP.CompareTo(y._IP);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._IP.CompareTo(x._IP);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnPH")){
						mSelectedIdxPit = 2;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._PH.CompareTo(y._PH);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._PH.CompareTo(x._PH);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnBB")){
						mSelectedIdxPit = 3;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._BB.CompareTo(y._BB);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._BB.CompareTo(x._BB);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnSO")){
						mSelectedIdxPit = 1;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._SO.CompareTo(y._SO);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._SO.CompareTo(x._SO);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnW")){
						mSelectedIdxPit = 4;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._W.CompareTo(y._W);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._W.CompareTo(x._W);
							});							
						}	
					} else if(btn.transform.name.Equals("BtnER")){
						mSelectedIdxPit = 6;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._ER.CompareTo(y._ER);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._ER.CompareTo(x._ER);
							});							
						}	
					} 
					break;
				}
			}
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

			BtnsColumn[] btns = tf.FindChild("Btns").GetComponentsInChildren<BtnsColumn>();
			foreach(BtnsColumn btn in btns){
				btn.Init();
				if(btn.IsSelected){
					if(btn.transform.name.Equals("BtnFPhit")){
						mSelectedIdxHit = 7;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x.fppg.CompareTo(y.fppg);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y.fppg.CompareTo(x.fppg);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnAB")){
						mSelectedIdxHit = 1;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._AB.CompareTo(y._AB);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._AB.CompareTo(x._AB);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnH")){
						mSelectedIdxHit = 2;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._H.CompareTo(y._H);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._H.CompareTo(x._H);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnHR")){
						mSelectedIdxHit = 3;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._HR.CompareTo(y._HR);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._HR.CompareTo(x._HR);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnK")){
						mSelectedIdxHit = 4;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._K.CompareTo(y._K);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._K.CompareTo(x._K);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnOBP")){
						mSelectedIdxHit = 5;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._OBP.CompareTo(y._OBP);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._OBP.CompareTo(x._OBP);
							});
							
						}	
					} else if(btn.transform.name.Equals("BtnAVG")){
						mSelectedIdxHit = 6;
						if(btn.mSort == BtnsColumn.SORT.ASC){
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return x._AVG.CompareTo(y._AVG);
							});
						} else{
							mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
								return y._AVG.CompareTo(x._AVG);
							});
							
						}	
					} 
					break;
				}
			}
		}




//		if(tf.FindChild("BtnFP").GetComponent<BtnsColumn>().mSort == BtnsColumn.SORT.DESC){
//			mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
//				return x.fppg.CompareTo(y.fppg);
//			});
//		} else{
//			mSortedList.Sort(delegate(PlayerInfo x, PlayerInfo y) {
//				return y.fppg.CompareTo(x.fppg);
//			});
//		}
//		if(SubInSub.SelectedPeople == SubInSub.PeopleSorting.PeopleAsc){
//			infoList.Sort(delegate(ContestListInfo x, ContestListInfo y) {
//				return x.totalPreset.CompareTo(y.totalPreset);
//			});
//		} else if(SubInSub.SelectedPeople == SubInSub.PeopleSorting.PeopleDesc){
//			infoList.Sort(delegate(ContestListInfo x, ContestListInfo y) {
//				return y.totalPreset.CompareTo(x.totalPreset);
//			});

		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().SetDragAmount(0, 99f, false);
		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().RemoveAll();
		transform.FindChild("Body").FindChild("ScrollPlayer").GetComponent<UIDraggablePanel2>().Init(
			mSortedList.Count, delegate(UIListItem item, int index) {
			item.Target.transform.FindChild("LblName").GetComponent<UILabel>()
				.text = Localization.language.Equals("English")
					? mSortedList[index].firstName.Substring(0, 1) + ". " + mSortedList[index].lastName
					: mSortedList[index].korName;

			item.Target.transform.FindChild("LblName").GetComponent<BtnPlayerName>().mPlayerInfo
				= mSortedList[index];

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
				item.Target.transform.FindChild(mSelectedIdxPit+"").GetComponent<UILabel>()
					.color = new Color(0,160f/255f,233f/255f);
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
				item.Target.transform.FindChild(mSelectedIdxHit+"").GetComponent<UILabel>()
					.color = new Color(0,160f/255f,233f/255f);
			}
//			for(int i = 0; i < item.Target.transform.childCount; i++)
//				Debug.Log(""+item.Target.transform.GetChild(i).name);
			item.Target.transform.FindChild("7").GetComponent<UILabel>()
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
