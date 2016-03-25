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
	Texture2D mDefaultTxt;

	// Use this for initialization
	void Start () {
		mDefaultTxt = Resources.Load<Texture2D>("images/man_default_b");
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
		tf.FindChild("TargetCard").FindChild("LblName").GetComponent<UILabel>().text = mTargetCard.playerName;
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
			GetComponent<UILabel>().text = mTargetCard.posCode;
		tf.FindChild("TargetCard").FindChild("Frame").FindChild("Panel").FindChild("Texture").
			GetComponent<UITexture>().mainTexture = mTargetTxt;
		if(mType == TYPE.LEVELUP){
			tf.FindChild("FeedingCardPowerUp").gameObject.SetActive(true);
			tf.FindChild("FeedingCardUpgrade").gameObject.SetActive(false);
			tf.FindChild("LabelsInfo").FindChild("InfoCardPowerUp").gameObject.SetActive(true);
			tf.FindChild("LabelsInfo").FindChild("InfoCardUpgrade").gameObject.SetActive(false);
			tf.FindChild("Btm").FindChild("CardPowerUp").gameObject.SetActive(true);
			tf.FindChild("Btm").FindChild("CardUpgrade").gameObject.SetActive(false);
			for(int i = 0; i < 4; i++){
				InitFeedsToBlank(i);
			}
		} else{
			tf.FindChild("FeedingCardPowerUp").gameObject.SetActive(false);
			tf.FindChild("FeedingCardUpgrade").gameObject.SetActive(true);
			tf.FindChild("LabelsInfo").FindChild("InfoCardPowerUp").gameObject.SetActive(false);
			tf.FindChild("LabelsInfo").FindChild("InfoCardUpgrade").gameObject.SetActive(true);
			tf.FindChild("Btm").FindChild("CardPowerUp").gameObject.SetActive(false);
			tf.FindChild("Btm").FindChild("CardUpgrade").gameObject.SetActive(true);

		}


	}

	public void LoadFeedsInfo(){
		float successRate = 0;
		float fee = 0;
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		if(mType == TYPE.LEVELUP){
			int i = 0;
			for(; i < mCardFeedList.Count; i++){
				InitFeedsToPlayer(i);
			}

			for(; i < 4; i++){
				InitFeedsToBlank(i);
			}

			tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
				.text = successRate + "%";
			tf.FindChild("Btm").FindChild("CardPowerUp").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
				.text = successRate + "G";
		} else{


			tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprTop").FindChild("Label").GetComponent<UILabel>()
				.text = "100%";
			tf.FindChild("Btm").FindChild("CardUpgrade").FindChild("SprMid").FindChild("Label").GetComponent<UILabel>()
				.text = successRate + "G";
		}
	}

	void InitFeedsToPlayer(int i){
		Transform tf = transform.FindChild("Body").FindChild("Scroll").FindChild("ItemCardPowerUp");
		CardInfo info = mCardFeedList[i];
		Debug.Log("cardClass is "+info.cardClass);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("FG").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("FG").GetComponent<UISprite>().spriteName = "upgrade_frame_feed_"+info.cardClass;
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Star").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Star").FindChild("Label").GetComponent<UILabel>().text = info.cardClass+"";
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("LvlLv").gameObject.SetActive(false);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("LvlLv").FindChild("Label").GetComponent<UILabel>().text = info.cardLevel+"";
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Button").gameObject.SetActive(false);
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
			FindChild("Panel").FindChild("Button").gameObject.SetActive(true);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().mainTexture
				= mDefaultTxt;
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Photo").GetComponent<UITexture>().color
				= new Color(1f, 1f, 1f, 50f/255f);
		tf.FindChild("FeedingCardPowerUp").FindChild("PowerUp").FindChild(""+(i+1)).
			FindChild("Panel").FindChild("Sprite").GetComponent<UISprite>().color
				= new Color(102f/255f, 102f/255f, 102f/255f);
	}
}
