using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MyContests : MonoBehaviour {

	List<ContestListInfo> mList;

	public GameObject mItemLiveInfo;
	public GameObject mItemLiveSub;
	public GameObject mItemSettledInfo;
	public GameObject mItemSettledSub;
	public GameObject mItemUpcomingInfo;
	public GameObject mItemUpcomingSub;
	public GameObject mItemBlank;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(string title, ContestDataEvent contestEvent){
		mList = contestEvent.Response.data;
		transform.FindChild("Top").FindChild("LblTitle").GetComponent<UILabel>().text = title;

		int totalTickets = 0;
		long totalEarnedRP = 0;
		long totalEarnedGold = 0;
		long total1stPrize = 0;

		foreach(ContestListInfo info in mList){
			totalTickets += info.entryTicket;
			totalEarnedRP += info.myRewardRP;
			totalEarnedGold += info.myRewardGold;
			total1stPrize += info.firstRewardGold;
		}

		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Scroll View"));//,
//		                  Vector2.zero, new Vector3(0, -118f, 0));

		if(title.Equals(UtilMgr.GetLocalText("LblUpcomingContests"))){
			transform.FindChild("Top").FindChild("Upcoming").gameObject.SetActive(true);
			transform.FindChild("Top").FindChild("Live").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("Recent").gameObject.SetActive(false);

			transform.FindChild("Top").FindChild("Upcoming").FindChild("Entries").FindChild("LblEntriesV")
				.GetComponent<UILabel>().text = contestEvent.Response.data.Count+"";
			transform.FindChild("Top").FindChild("Upcoming").FindChild("EntryFees").FindChild("LblEntryFeesV")
				.GetComponent<UILabel>().text = totalTickets+"";

			InitUpcomingList();
		} else if(title.Equals(UtilMgr.GetLocalText("LblLive"))){
			transform.FindChild("Top").FindChild("Upcoming").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("Live").gameObject.SetActive(true);
			transform.FindChild("Top").FindChild("Recent").gameObject.SetActive(false);

			transform.FindChild("Top").FindChild("Live").FindChild("Entries").FindChild("LblEntriesV")
				.GetComponent<UILabel>().text = contestEvent.Response.data.Count+"";
			transform.FindChild("Top").FindChild("Live").FindChild("EntryFees").FindChild("LblEntryFeesV")
				.GetComponent<UILabel>().text = totalTickets+"";
			transform.FindChild("Top").FindChild("Live").FindChild("Winnings").FindChild("LblWinningsV")
				.GetComponent<UILabel>().text = total1stPrize+"G";

			InitLiveList ();
		} else{
			transform.FindChild("Top").FindChild("Upcoming").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("Live").gameObject.SetActive(false);
			transform.FindChild("Top").FindChild("Recent").gameObject.SetActive(true);

			transform.FindChild("Top").FindChild("Recent").FindChild("EntryFees").FindChild("LblEntryFeesV")
				.GetComponent<UILabel>().text = totalEarnedRP+"RP";
			transform.FindChild("Top").FindChild("Recent").FindChild("Winnings").FindChild("LblWinningsV")
				.GetComponent<UILabel>().text = totalEarnedGold+"G";

			InitRecentList();
		}


	}

	void InitUpcomingList(){
		float stackedHeight = 0f;
		GameObject go = Instantiate(mItemBlank);
		go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
		go.transform.localPosition = new Vector3(0, 0);
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		stackedHeight -= 12f;

		for(int i = 0; i < mList.Count; i++){
			ContestListInfo info = mList[i];

			if((i == 0) || (mList[i-1].startTime != info.startTime)){
				go = Instantiate(mItemUpcomingInfo);
				go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
				stackedHeight -= 30f;
				go.transform.localPosition = new Vector3(0, stackedHeight);
				stackedHeight -= 30f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);

				go.transform.FindChild("Time").FindChild("Label").GetComponent<UILabel>().text = info.gameDayString;
			}

			go = Instantiate(mItemUpcomingSub);
			go.transform.FindChild("BG").GetComponent<ItemMyContests>().mContestInfo = mList[i];
			go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
			stackedHeight -= 276f/2f;
			go.transform.localPosition = new Vector3(0, stackedHeight);
			stackedHeight -= 276/2f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);

			if(Localization.language.Equals("English"))
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestName;
			else
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestNameKor;

			go.transform.FindChild("LblEntries").FindChild("Label").GetComponent<UILabel>().text 
				= "[333333][b]"+ UtilMgr.AddsThousandsSeparator(info.totalJoin)
					+ "[/b][-][666666] / " + UtilMgr.AddsThousandsSeparator(info.totalEntry);
			go.transform.FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().text = info.entryTicket+"";
			go.transform.FindChild("LblBasicRP").FindChild("Label").GetComponent<UILabel>().text = "[333333]0";
			go.transform.FindChild("Lbl1stPrize").FindChild("Label").GetComponent<UILabel>().text = "[fc5034]"
				+info.firstRewardGold+"G";

			go.transform.FindChild("Lineup").FindChild("Label").GetComponent<UILabel>().text = info.entryPlayers;
			if((info.lineupName != null) && (info.lineupName.Length > 0)){
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(true);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -20f, 0);
				go.transform.FindChild("Lineup").FindChild("Sprite").FindChild("Label").GetComponent<UILabel>().text
					= info.lineupName;
			} else{
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(false);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -8f, 0);
			}
		}

		transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}

	void InitRecentList(){
		float stackedHeight = 0f;
		GameObject go = Instantiate(mItemBlank);
		go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
		go.transform.localPosition = new Vector3(0, 0);
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		stackedHeight -= 12f;
		float totalFP = 0;
		
		for(int i = 0; i < mList.Count; i++){
			ContestListInfo info = mList[i];
			
			if((i == 0) || (mList[i-1].startTime != info.startTime)){
				go = Instantiate(mItemSettledInfo);
				go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
				stackedHeight -= 36f;
				go.transform.localPosition = new Vector3(0, stackedHeight);
				stackedHeight -= 36f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
				
				go.transform.FindChild("Time").FindChild("Label").GetComponent<UILabel>().text = info.gameDayString;

				totalFP = 0;
				foreach(ContestListInfo info2 in mList){
					if(info.startTime == info2.startTime){
						totalFP += info2.totalFantasy;
					}
				}
				go.transform.FindChild("Time").FindChild ("SprArrow").FindChild("Label").GetComponent<UILabel>().text
					= string.Format("{0:F1}", totalFP);
			}
			
			go = Instantiate(mItemSettledSub);
			go.transform.FindChild("BG").GetComponent<ItemMyContests>().mContestInfo = mList[i];
			go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
			stackedHeight -= 276f/2f;
			go.transform.localPosition = new Vector3(0, stackedHeight);
			stackedHeight -= 276/2f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);

			if(Localization.language.Equals("English"))
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestName;
			else
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestNameKor;
			go.transform.FindChild("LblPosition").FindChild("Label").GetComponent<UILabel>().text 
				= "[333333][b]"+ UtilMgr.AddsThousandsSeparator(info.myRank)
					+ "[/b][-][666666] / " + UtilMgr.AddsThousandsSeparator(info.totalJoin);
			go.transform.FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().text = info.entryTicket+"";

			go.transform.FindChild("LblEarnedRP").FindChild("Label").GetComponent<UILabel>().text = "[333333]"
				+info.myRewardRP+"RP";
			go.transform.FindChild("LblEarnedGold").FindChild("Label").GetComponent<UILabel>().text = "[fc5034]"
				+info.myRewardGold+"G";
			
			go.transform.FindChild("Lineup").FindChild("Label").GetComponent<UILabel>().text = info.entryPlayers;
			if((info.lineupName != null) && (info.lineupName.Length > 0)){
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(true);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -20f, 0);
				go.transform.FindChild("Lineup").FindChild("Sprite").FindChild("Label").GetComponent<UILabel>().text
					= info.lineupName;
			} else{
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(false);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -8f, 0);
			}
		}
		
		transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}

	void InitLiveList(){
		float stackedHeight = 0f;
		GameObject go = Instantiate(mItemBlank);
		go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
		go.transform.localPosition = new Vector3(0, 0);
		go.transform.localScale = new Vector3(1f, 1f, 1f);
		stackedHeight -= 12f;
		float totalFP = 0;
		
		for(int i = 0; i < mList.Count; i++){
			ContestListInfo info = mList[i];
			
			if((i == 0) || (mList[i-1].startTime != info.startTime)){
				go = Instantiate(mItemLiveInfo);
				go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
				stackedHeight -= 36f;
				go.transform.localPosition = new Vector3(0, stackedHeight);
				stackedHeight -= 36f;
				go.transform.localScale = new Vector3(1f, 1f, 1f);
				
				go.transform.FindChild("Time").FindChild("Label").GetComponent<UILabel>().text = info.gameDayString;

				totalFP = 0;
				foreach(ContestListInfo info2 in mList){
					if(info.startTime == info2.startTime)
						totalFP += info2.totalFantasy;
				}
				go.transform.FindChild("Time").FindChild ("SprArrow").FindChild("Label").GetComponent<UILabel>().text
					= string.Format("{0:F1}", totalFP);

				float ratio = info.gameOverPlayers / 9f;
				int width = (int)(124 * ratio);
				go.transform.FindChild("Time").FindChild ("SprArrow").FindChild("Panel").FindChild("Sprite")
					.GetComponent<UISprite>().width = width;
				go.transform.FindChild("Time").FindChild ("SprArrow").FindChild("Panel").FindChild("Sprite")
					.localPosition = new Vector3(-((124 - width)/2), 0);

			}
			
			go = Instantiate(mItemLiveSub);
			go.transform.FindChild("BG").GetComponent<ItemMyContests>().mContestInfo = mList[i];
			go.transform.parent = transform.FindChild("Body").FindChild("Scroll View");
			stackedHeight -= 170f;
			go.transform.localPosition = new Vector3(0, stackedHeight);
			stackedHeight -= 170f;
			go.transform.localScale = new Vector3(1f, 1f, 1f);

			if(Localization.language.Equals("English"))
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestName;
			else
				go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = info.contestNameKor;
			go.transform.FindChild("LblPosition").FindChild("Label").GetComponent<UILabel>().text 
				= "[333333][b]"+ UtilMgr.AddsThousandsSeparator(info.myRank)
					+ "[/b][-][666666] / " + UtilMgr.AddsThousandsSeparator(info.totalJoin);
			float ratioLoc = ((float)info.myRank) / ((float)info.totalJoin);
			go.transform.FindChild("Gauge").FindChild("Panel2").FindChild("SprPin").localPosition
				= new Vector3(((-672f * ratioLoc) + 336f), 16f);

			go.transform.FindChild("LblTickets").FindChild("Label").GetComponent<UILabel>().text = info.entryTicket+"";
			go.transform.FindChild("LblBasicRP").FindChild("Label").GetComponent<UILabel>().text = "[333333]0";
			go.transform.FindChild("Lbl1stPrize").FindChild("Label").GetComponent<UILabel>().text = "[fc5034]"
				+info.firstRewardGold+"G";
			go.transform.FindChild("Gauge").FindChild("Panel2").FindChild("SprPin").FindChild("Label").
				GetComponent<UILabel>().text = info.totalFantasy+"";
			
			go.transform.FindChild("Lineup").FindChild("Label").GetComponent<UILabel>().text = info.entryPlayers;
			if((info.lineupName != null) && (info.lineupName.Length > 0)){
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(true);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -20f, 0);
				go.transform.FindChild("Lineup").FindChild("Sprite").FindChild("Label").GetComponent<UILabel>().text
					= info.lineupName;
			} else{
				go.transform.FindChild("Lineup").FindChild("Sprite").gameObject.SetActive(false);
				go.transform.FindChild("Lineup").FindChild("Label").localPosition = new Vector3(0, -8f, 0);
			}

			float rewardRatio = 0;
			if(info.contestType == 1){
				rewardRatio = 0.5f;
			} else{
				rewardRatio = ((float)info.rewardCount) / ((float)info.totalJoin);
				if(rewardRatio > 1f) rewardRatio = 1f;
			}
			
			float widthf = 672f * rewardRatio;
			float diff = (672f - widthf) / 2f;
			
			go.transform.FindChild("Gauge").FindChild("Panel").GetComponent<UIPanel>().SetRect(widthf, 70f);
			go.transform.FindChild("Gauge").FindChild("Panel").localPosition = new Vector3(diff, 26f);
			go.transform.FindChild("Gauge").FindChild("Panel")
				.FindChild("SprGaugeFront").localPosition = new Vector3(-diff, 0);
		}
		
		transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>().ResetPosition();
	}
}
