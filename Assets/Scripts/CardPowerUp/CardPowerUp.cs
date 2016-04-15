using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardPowerUp : MonoBehaviour {

	public enum TYPE{
		RANKUP,
		LEVELUP
	}
	public TYPE mType;
	public CardInfo mTargetCard;
	Texture mTargetTxt;
//	CardInfo[] mCardsFeed;
	public List<CardInfo> mCardFeedList;
//	Texture2D mDefaultTxt;
	string[][] LevelUpRate = new string[6][]{
		new string[]{"100%", "100%", "100%", "100%", "100%", "100%"},
		new string[]{"50%", "100%", "100%", "100%", "100%", "100%"},
		new string[]{"25%", "50%", "100%", "100%", "100%", "100%"},
		new string[]{"10%", "25%", "50%", "100%", "100%", "100%"},
		new string[]{"5%", "10%", "25%", "50%", "100%", "100%"},
		new string[]{"1%", "5%", "10%", "25%", "50%", "100%"}
	};

	int[] LevelUpFee = new int[]{
		20, 40, 70, 100, 140, 180
	};

	int[] RankUpFee = new int[]{
		50, 100, 150, 200, 300
	};

	public int mFee;

	// Use this for initialization
	void Start () {
//		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Init(CardInfo cardInfo, Texture targetTxt, string title, TYPE type){
		mType = type;
		mTargetCard = cardInfo;
		mTargetTxt = targetTxt;
		if(mCardFeedList != null)
			mCardFeedList.Clear();
		mCardFeedList = new List<CardInfo>();

		transform.FindChild("Top").FindChild("LblCardPowerUp").GetComponent<UILabel>().text = title;

		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		tf.FindChild("TargetCard").FindChild("FG").GetComponent<UISprite>().spriteName = "upgrade_bg_target_"
			+ mTargetCard.cardClass;
		if(Localization.language.Equals("English"))
			tf.FindChild("TargetCard").FindChild("LblName").GetComponent<UILabel>().text = mTargetCard.playerName;
		else
			tf.FindChild("TargetCard").FindChild("LblName").GetComponent<UILabel>().text = mTargetCard.korName;
		tf.FindChild("TargetCard").FindChild("Level").FindChild("LvV").
			GetComponent<UILabel>().text = mTargetCard.cardLevel+"";
		for(int i = 0; i < 6; i++){
			tf.FindChild("TargetCard").FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>().color
				= new Color(102f/255f, 102f/255f, 102f/255f);
		}
		for(int i = 0; i < mTargetCard.cardClass; i++){
			tf.FindChild("TargetCard").FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>().color
				= new Color(252f/255f, 133f/255f, 53f/255f);
		}
		tf.FindChild("TargetCard").FindChild("Pos").FindChild("SprPos").FindChild("Label").
			GetComponent<UILabel>().text = mTargetCard.position;
		tf.FindChild("TargetCard").FindChild("Frame").FindChild("Panel").FindChild("Texture").
			GetComponent<UITexture>().mainTexture = mTargetTxt;
		if(mType == TYPE.LEVELUP){
			tf.FindChild("LabelsInfo").FindChild("InfoCardPowerUp").gameObject.SetActive(true);
			tf.FindChild("LabelsInfo").FindChild("InfoCardUpgrade").gameObject.SetActive(false);
			tf.FindChild("Btm").FindChild("CardPowerUp").gameObject.SetActive(true);
			tf.FindChild("Btm").FindChild("CardUpgrade").gameObject.SetActive(false);
			tf.FindChild("SprPowerUp").gameObject.SetActive(true);
			tf.FindChild("SprUpgrade").gameObject.SetActive(false);
			tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").gameObject.SetActive(true);
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").gameObject.SetActive(false);

//			for(int i = 0; i < 4; i++){
//				InitFeedsToBlank(i);
//			}
		} else{
			tf.FindChild("LabelsInfo").FindChild("InfoCardPowerUp").gameObject.SetActive(false);
			tf.FindChild("LabelsInfo").FindChild("InfoCardUpgrade").gameObject.SetActive(true);
			tf.FindChild("Btm").FindChild("CardPowerUp").gameObject.SetActive(false);
			tf.FindChild("Btm").FindChild("CardUpgrade").gameObject.SetActive(true);
			tf.FindChild("SprPowerUp").gameObject.SetActive(false);
			tf.FindChild("SprUpgrade").gameObject.SetActive(true);
			tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").gameObject.SetActive(false);
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").gameObject.SetActive(true);

//			InitsFeedToBlank();
		}
		LoadFeedsInfo();

	}

	public void LoadFeedsInfo(){
//		float successRate = 0;
		mFee = 0;
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		if(mType == TYPE.LEVELUP){
			int i = 0;
			for(; i < mCardFeedList.Count; i++){
				InitFeedsToPlayer(i);
			}

			for(; i < 4; i++){
				InitFeedsToBlank(i);
			}

			string successRate = "";
			for(i = mCardFeedList.Count -1; i > -1; i--){
				if(mCardFeedList.Count < 1) break;

				CardInfo info = mCardFeedList[i];
				successRate += LevelUpRate[mTargetCard.cardClass-1][info.cardClass-1] + " /";
				mFee += LevelUpFee[mTargetCard.cardClass-1];
			}
			if(mCardFeedList.Count > 0){
				tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
					.text = successRate.Substring(0, successRate.Length -2);
				tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
					.text = mFee + "G";
			} else{
				tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
					.text = "0%";
				tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
					.text = "0G";
			}


		} else{
			if(mCardFeedList.Count > 0){
				InitsFeedToPlayer();
				tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
					.text = "100%";
				tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
					.text = RankUpFee[mTargetCard.cardClass-1] + "G";
			} else{
				InitsFeedToBlank();
				tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
					.text = "0%";
				tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
					.text = "0G";
			}


		}
	}

	void InitFeedsToPlayer(int i){
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		CardInfo info = mCardFeedList[i];
//		Debug.Log("cardClass is "+info.cardClass);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("FG").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("FG").GetComponent<UISprite>().spriteName = "upgrade_frame_feed_"+info.cardClass;
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Star").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Star").FindChild("Label").GetComponent<UILabel>().text = info.cardClass+"";
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("LvlLv").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("LvlLv").FindChild("Label").GetComponent<UILabel>().text = info.cardLevel+"";
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel2").FindChild("Button").gameObject.SetActive(false);
		UtilMgr.LoadImage(info.photoUrl,
		                  tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
		                  FindChild("Panel").FindChild("Photo").GetComponent<UITexture>());
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Sprite").GetComponent<UISprite>().color
				= new Color(51f/255f, 51f/255f, 51f/255f);
	}

	void InitFeedsToBlank(int i){
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("FG").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Star").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("LvlLv").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel2").FindChild("Button").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture
				= UtilMgr.GetTextureDefault();
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().color
				= new Color(1f, 1f, 1f, 50f/255f);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Sprite").GetComponent<UISprite>().color
				= new Color(102f/255f, 102f/255f, 102f/255f);
	}

	void InitsFeedToBlank(){
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("FG").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblName").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Level").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Pos").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Button").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblSelectPlayer2").gameObject.SetActive(true);
	}

	void InitsFeedToPlayer(){
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		CardInfo info = mCardFeedList[0];
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("FG").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("FG").GetComponent<UISprite>().spriteName
			= "upgrade_bg_target_"+info.cardClass;
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblName").gameObject.SetActive(true);
		if(Localization.language.Equals("English"))
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblName").GetComponent<UILabel>().text = info.playerName;
		else
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblName").GetComponent<UILabel>().text = info.korName;
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Level").gameObject.SetActive(true);
		for(int i = 0; i < 6; i++){
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>().color
				= new Color(102f/255f, 102f/255f, 102f/255f);
		}
		for(int i = 0; i < info.cardClass; i++){
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Level").FindChild("Star"+(i+1)).GetComponent<UISprite>().color
				= new Color(252f/255f, 133f/255f, 53f/255f);
		}
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Level").FindChild("LvV").GetComponent<UILabel>()
			.text = info.cardLevel+"";
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Pos").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Pos").FindChild("SprPos").FindChild("Label").
			GetComponent<UILabel>().text = info.position;
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Button").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("LblSelectPlayer2").gameObject.SetActive(false);

		UtilMgr.LoadImage(info.photoUrl,
			tf.FindChild("FeedingCardPowerUp").FindChild("RankUp").FindChild("Frame").FindChild("Panel")
		                  .FindChild("Texture").GetComponent<UITexture>());
	}
}
