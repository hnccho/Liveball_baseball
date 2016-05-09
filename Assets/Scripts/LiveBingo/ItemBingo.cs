using UnityEngine;
using System.Collections;

public class ItemBingo : MonoBehaviour {

//	public Color BGColor = Color.white;
	public BingoInfo.BingoBoard mBingoBoard;
	public BingoInfo.BingoBoard mNewBingoBoard;
	public bool IsCorrected;
	public bool IsAnimate;
	public bool IsBlink;
	public bool IsIdle;
	public bool IsPower;
	GetBingoEvent mPowerEvent;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(IsBlink){
			IsBlink = false;
			transform.FindChild("Sprite").GetComponent<Animator>().SetTrigger("Blink");
		} else if(IsIdle){
			IsIdle = false;
			transform.FindChild("Sprite").GetComponent<Animator>().SetTrigger("Idle");
		} else if(IsPower){
			IsPower = false;
			transform.FindChild("Sprite").GetComponent<Animator>().SetTrigger("Power");
		}
//		if(IsCorrected && !IsAnimate){
//			transform.FindChild("Background").GetComponent<UISprite>().color = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().defaultColor = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().hover = new Color(28f/255f, 150f/255f, 212f/255f);
//			transform.GetComponent<UIButton>().pressed = new Color(28f/255f, 150f/255f, 212f/255f);
//			if(mBingoBoard.playerId > 0){
//				transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
//			} else{
//				transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
//			}
//		}

	}

	public void Init(bool isReload){
		transform.GetComponent<Animator>().SetTrigger("Idle");

		if(mNewBingoBoard.successYn.Equals("Y")){
			if(isReload && mBingoBoard.successYn.Equals("N")){
				mBingoBoard = mNewBingoBoard;
				Correct();
			} else{
				mBingoBoard = mNewBingoBoard;
				SetCorrected();
			}
		}
		mBingoBoard = mNewBingoBoard;
		if(mBingoBoard.powerCheck > 0){
			SetTilePower();
		} else if(mBingoBoard.playerId > 0){
			SetTilePlayer();
			if(mBingoBoard.walkYn.Equals("Y"))
				SetGuess(0);
			if(mBingoBoard.outYn.Equals("Y"))
				SetGuess(1);
		} else{
			SetTileTeam();
		}


	}

	void SetTilePower(){
		transform.FindChild("Player").gameObject.SetActive(false);
		transform.FindChild("Team").gameObject.SetActive(true);
		
		transform.FindChild("Team").FindChild("LblName").GetComponent<UILabel>().text
			= "FREE";//Localization.language.Equals("English") ? mBingoBoard.playerName : mBingoBoard.playerKorName;
		transform.FindChild("Team").FindChild("LblName").GetComponent<UILabel>().color = new Color(1f, 91f/255f, 16f/255f);

		transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().spriteName = "logo_title_bingo_power";
		transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().width = 126;
		transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().height = 72;
//		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 72;
//		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 72;
//		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>()
//			.mainTexture = UtilMgr.GetTextureDefault();
//		UtilMgr.LoadImage(mBingoBoard.photoUrl,
//		                  transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
		transform.FindChild("Team").FindChild("LblGuess").gameObject.SetActive(false);
	}

	void SetTilePlayer(){
		transform.FindChild("Player").gameObject.SetActive(true);
		transform.FindChild("Team").gameObject.SetActive(false);

		transform.FindChild("Player").FindChild("LblName").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.playerName : mBingoBoard.playerKorName;
		transform.FindChild("Player").FindChild("LblName").GetComponent<UILabel>().color = new Color(51f/255f, 51f/255f, 51f/255f);

		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().width = 72;
		transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>().height = 90;
		UtilMgr.LoadImage(mBingoBoard.photoUrl,
		                  transform.FindChild("Player").FindChild("Panel").FindChild("Texture").GetComponent<UITexture>());
		transform.FindChild("Team").FindChild("LblGuess").gameObject.SetActive(true);
	}

	void SetTileTeam(){
		transform.FindChild("Player").gameObject.SetActive(false);
		transform.FindChild("Team").gameObject.SetActive(true);

		if(!UtilMgr.IsMLB()){
			transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().width = 74;
			transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().height = 60;
		}
		transform.FindChild("Team").FindChild("SprEmblem").GetComponent<UISprite>().spriteName = mBingoBoard.teamId+"";
		transform.FindChild("Team").FindChild("LblName").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.teamName : mBingoBoard.teamKorName;
		transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().text
			= Localization.language.Equals("English") ? mBingoBoard.quizCondition : mBingoBoard.quizConditionKor;
	}

	public void Bingo(){
		transform.GetComponent<Animator>().SetTrigger("Bingo");
	}

	public void BingoFinish(){

	}

	public void Correct(){
		transform.GetComponent<Animator>().SetTrigger("Correct");
		transform.parent.parent.FindChild("Result").GetComponent<BingoResult>().Correct();
	}

	public void SetCorrected(){
		IsCorrected = true;
		transform.FindChild("Background").GetComponent<UISprite>().color = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().defaultColor = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().hover = new Color(28f/255f, 150f/255f, 212f/255f);
//		transform.GetComponent<UIButton>().pressed = new Color(28f/255f, 150f/255f, 212f/255f);
		if(mBingoBoard.playerId > 0){
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
		} else{
			transform.FindChild("Team").FindChild("LblGuess").GetComponent<UILabel>().color = Color.white;
		}
	}

	public void SetGuess(int checkValue){
		if(transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().text.Length > 0
			&& mBingoBoard.successYn.Equals("Y")) return;

		if(checkValue == 0)
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrGetOnBase");
		else
			transform.FindChild("Player").FindChild("LblGuess").GetComponent<UILabel>().text
				= UtilMgr.GetLocalText("StrOut");
	}

	public void BlastStar(){
		transform.FindChild("StarBlueBlast").gameObject.SetActive(true);
		transform.FindChild("StarBlueBlast").GetComponent<ParticleSystem>().Play();
	}

	public void BlastCoin(){
		transform.FindChild("CoinBlastCopper").gameObject.SetActive(true);
		transform.FindChild("CoinBlastCopper").GetComponent<ParticleSystem>().Play();
	}

	public void CorrectFinish(){
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().CheckBingo();
	}

	public void OnClick(){
		if(transform.root.FindChild("LiveBingo").GetComponent<LiveBingoAnimation>().mGaugeCnt < 10) return;

		mPowerEvent = new GetBingoEvent(ReceivedPower);
		NetMgr.UsePower(UserMgr.eventJoined.gameId, mBingoBoard.bingoId, mBingoBoard.tailId, mPowerEvent);
	}

	void ReceivedPower(){
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingoAnimation>().PowerUsed();
		transform.root.FindChild("LiveBingo").GetComponent<LiveBingo>().ReloadBoard();
	}

}
