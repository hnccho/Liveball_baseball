using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

	public GameObject mItemShop;
	public GameObject mItemCard;
	public static int GOLD = 5;
	public static int TICKET = 4;
	public static int CARD = 2;
	public static int SKILL = 3;
	public int mCategory;

	List<ItemShopGoldInfo> mItemList;
	List<ShopGoldInfo> mGoldList;
	InAppPurchaseEvent mIAPEvent;

	#if(UNITY_ANDROID)
	GooglePurchase mPurchase;
	#endif
	bool IsSupported;
	string mItemname;
	string mItemcode;

	// Use this for initialization
	void Start () {
		SetDelegates();
		IsSupported = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDestory(){
		ClearDelegates();
	}

	public void InitGoldShop(string title, int category, GetGoldShopEvent goldEvent){
		mGoldList = goldEvent.Response.data;
		transform.FindChild("Top").FindChild("LblShop").GetComponent<UILabel>().text = title;
		mCategory = category;

		InitGoldList();

		if(Application.platform == RuntimePlatform.IPhonePlayer){
			IOSMgr.InAppInit();
		} else if(Application.platform == RuntimePlatform.Android){
			#if(UNITY_ANDROID)
			GoogleIAB.init(Constants.GOOGLE_PUBLIC_KEY);
			#endif
		}
	}

	public void InitItemShop(string title, int category, GetItemShopGoldEvent goldEvent){
		mItemList = goldEvent.Response.data;
		transform.FindChild("Top").FindChild("LblShop").GetComponent<UILabel>().text = title;
		mCategory = category;
		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Scroll View"));

		if(category == GOLD){
			InitGoldList();
		} else if(category == TICKET){
			InitTicketList();
		} else if(category == CARD){
			InitCardList();
		} else{
			InitSkillList();
		}

	}

	void InitGoldList(){
		UtilMgr.ClearList(transform.FindChild("Body").FindChild("Scroll View"));
		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mGoldList.Count; i++){
			ShopGoldInfo shopInfo = mGoldList[i];
			GameObject go = Instantiate(mItemShop);
			height = -136f;
			go.transform.parent = scrollview.transform;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.localPosition = new Vector3(0, height*i, 0);
			go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = shopInfo.productName;
			go.transform.FindChild("LblDesc").GetComponent<UILabel>().text = shopInfo.productDesc;
			if(shopInfo.productDesc.IndexOf("BONUS") > -1)
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(true);
			else
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(false);
			
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_gold_number_"+(i+1);
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().height = 108;
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().width = 108;
			go.transform.FindChild("BtnPhoto").FindChild("SprTicket").gameObject.SetActive(false);

			if(IsSupported){
				go.transform.FindChild("LblPrice").gameObject.SetActive(true);
				go.transform.FindChild("LblPrice").GetComponent<UILabel>().text
					= mGoldList[i].priceDesc;
			} else
				go.transform.FindChild("LblPrice").gameObject.SetActive(false);
			go.transform.FindChild("LblPrice").FindChild("Sprite").gameObject.SetActive(false);
//			int width = go.transform.FindChild("LblPrice").GetComponent<UILabel>().width;
//			Vector3 oriVec = go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition;
//			go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition
//				= new Vector3(width + 5f, oriVec.y);
			
			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mGoldInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}

	void InitTicketList(){		
		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mItemList.Count; i++){
			ItemShopGoldInfo shopInfo = mItemList[i];
			GameObject go = Instantiate(mItemShop);
			height = -136f;
			go.transform.parent = scrollview.transform;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.localPosition = new Vector3(0, height*i, 0);
			go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = shopInfo.productName;
			go.transform.FindChild("LblDesc").GetComponent<UILabel>().text = shopInfo.productDesc;
			if(shopInfo.productDesc.IndexOf("BONUS") > -1)
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(true);
			else
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(false);

			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_tc_ticket";
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().height = 108;
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().width = 108;
			go.transform.FindChild("BtnPhoto").FindChild("SprTicket").gameObject.SetActive(true);
			go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().spriteName
				= "shop_tc_number_"+(i+1);
			go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().height = 37;			
			switch(i){
			case 0: go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().width = 84; break;
			case 1: go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().width = 92; break;
			case 2: go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().width = 93; break;
			case 3: go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().width = 93; break;
			case 4: go.transform.FindChild("BtnPhoto").FindChild("SprTicket").GetComponent<UISprite>().width = 104; break;
			}

			go.transform.FindChild("LblPrice").GetComponent<UILabel>().text
				= UtilMgr.AddsThousandsSeparator(shopInfo.price);
			int width = go.transform.FindChild("LblPrice").GetComponent<UILabel>().width;
			Vector3 oriVec = go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition;
			go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition
				= new Vector3(width + 5f, oriVec.y);
			
			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mItemInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}

	void InitCardList(){
		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mItemList.Count; i++){
			ItemShopGoldInfo shopInfo = mItemList[i];
			GameObject go = Instantiate(mItemCard);
			height = -172f;
			go.transform.parent = scrollview.transform;
			go.transform.localScale = new Vector3(1f, 1f, 1f);
			go.transform.localPosition = new Vector3(0, height*i, 0);
			go.transform.FindChild("LblTitle").GetComponent<UILabel>().text = shopInfo.productName;
			go.transform.FindChild("LblDesc").GetComponent<UILabel>().text = shopInfo.productDesc;
			if(shopInfo.productDesc.IndexOf("+") > -1)
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(true);
			else
				go.transform.FindChild("BtnPhoto").FindChild("Bonus").gameObject.SetActive(false);

			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().width = 63;
			go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().height = 108;
			switch(i){
			case 0: go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_card_pack_bronze";break;
			case 1: go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_card_pack_silver";break;
			case 2: go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_card_pack_gold";break;
			case 3: go.transform.FindChild("BtnPhoto").FindChild("Item").GetComponent<UISprite>().spriteName
				= "shop_card_pack_vip";break;
			}

			go.transform.FindChild("LblPrice").GetComponent<UILabel>().text
				= UtilMgr.AddsThousandsSeparator(shopInfo.price);
			int width = go.transform.FindChild("LblPrice").GetComponent<UILabel>().width;
			Vector3 oriVec = go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition;
			go.transform.FindChild("LblPrice").FindChild("Sprite").localPosition
				= new Vector3(width + 5f, oriVec.y);
			
			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mItemInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}

	void InitSkillList(){

	}

	void SetDelegates(){
		#if(UNITY_ANDROID)
		GoogleIABManager.billingSupportedEvent += billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent += billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent += queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent += queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent += purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent += purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent += purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent += consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent += consumePurchaseFailedEvent;
		#else
		IOSMgr.PurchaseSucceededEvent += purchaseSucceededEvent;
		IOSMgr.PurchaseFailedEvent += purchaseFailedEvent;
		#endif
	}
	
	void ClearDelegates(){
		#if(UNITY_ANDROID)
		GoogleIABManager.billingSupportedEvent -= billingSupportedEvent;
		GoogleIABManager.billingNotSupportedEvent -= billingNotSupportedEvent;
		GoogleIABManager.queryInventorySucceededEvent -= queryInventorySucceededEvent;
		GoogleIABManager.queryInventoryFailedEvent -= queryInventoryFailedEvent;
		GoogleIABManager.purchaseCompleteAwaitingVerificationEvent -= purchaseCompleteAwaitingVerificationEvent;
		GoogleIABManager.purchaseSucceededEvent -= purchaseSucceededEvent;
		GoogleIABManager.purchaseFailedEvent -= purchaseFailedEvent;
		GoogleIABManager.consumePurchaseSucceededEvent -= consumePurchaseSucceededEvent;
		GoogleIABManager.consumePurchaseFailedEvent -= consumePurchaseFailedEvent;
		#else
		IOSMgr.PurchaseSucceededEvent -= purchaseSucceededEvent;
		IOSMgr.PurchaseFailedEvent -= purchaseFailedEvent;
		#endif
	}

//	public void prime31(string id,string code,string product,string buyruby,string addruby,string addgold){
//		Debug.Log ("id : " + id + " code : " + code);
//		itemid = int.Parse(id);
//		itemcode = code;
//		mItemname = product;
//		Bruby = float.Parse(buyruby);
//		Aruby = float.Parse(addruby);
//		Agold = float.Parse(addgold);
//		RequestIAP(code);
//	}
	
	public void RequestIAP(string itemcode, string itemname){
		mItemname = itemname;
		mItemcode = itemcode;
		#if(UNITY_ANDROID)
		GoogleIAB.purchaseProduct(itemcode);
		#else
		IOSMgr.BuyItem(itemcode);
		#endif
	}
	
	void billingSupportedEvent()
	{
		Debug.Log( "billingSupportedEvent" );
		//Try to Get Item Inven
		#if(UNITY_ANDROID)
		string[] skus = new string[mGoldList.Count];
		int i = 0;
		foreach(ShopGoldInfo info in mGoldList){
			skus[i++] = info.productCode;
		}			
		
		GoogleIAB.queryInventory(skus);
		#endif
	}
	
	
	void billingNotSupportedEvent( string error )
	{
//		DialogueMgr.ShowDialogue("초기화 오류", "결제 초기화에 실패하여\n상품을 구매할 수 없습니다.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		Debug.Log( "billingNotSupportedEvent: " + error );
	}
	
	#if(UNITY_ANDROID)
	void queryInventorySucceededEvent( List<GooglePurchase> purchases, List<GoogleSkuInfo> skus )
	{
		Debug.Log( string.Format( "queryInventorySucceededEvent. total purchases: {0}, total skus: {1}", purchases.Count, skus.Count ) );
		for(int i = 0; i < skus.Count; i++){
			GoogleSkuInfo sku = skus[i];
			foreach(ShopGoldInfo info in mGoldList){
				if(info.productCode.Equals(sku.productId))
					info.priceDesc = sku.price;
			}
		}
		IsSupported = true;
		InitGoldList();
//		Prime31.Utils.logObject( purchases );
//		Prime31.Utils.logObject( skus );
//		if(purchases.Count > 0){
//			mPurchase = purchases[0];
//			foreach(ItemShopRubyInfo info in getruby.Response.data){
//				if(info.productCode.Equals(mPurchase.productId)){
//					itemcode = info.productCode;
//					mItemname = "루비 " + info.productValue+"개";
//					purchaseSucceededEvent(mPurchase);
//					break;
//				}
//			}			
//			
//		}
	}
	
//	public void CheckOrderNo(){
//		Debug.Log("DeveloperPayload Status : "+mPurchase.developerPayload);
//		foreach(InAppHistoryInfo info in mHistoryEvent.Response.data){
//			Debug.Log("purchase key : "+info.purchaseKey+", Status : "+info.purchaseStatus);
//			if(info.purchaseKey.Equals(mPurchase.developerPayload)){
//				orderNo = info.orderNo;
//				itemcode = info.productCode;
//				mItemname = "루비 " + info.productValue+"개";
//				purchaseSucceededEvent(mPurchase);
//				break;
//			}
//		}
//	}
	
	
	void queryInventoryFailedEvent( string error )
	{
		Debug.Log( "queryInventoryFailedEvent: " + error );
	}
	
	
	void purchaseCompleteAwaitingVerificationEvent( string purchaseData, string signature )
	{
		Debug.Log( "purchaseCompleteAwaitingVerificationEvent. purchaseData: " + purchaseData + ", signature: " + signature );
	}
	
	void purchaseSucceededEvent( GooglePurchase purchase )
	{		
		mIAPEvent = new InAppPurchaseEvent(FinishIAP);
		
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(purchase.originalJson);
		string basedJson = System.Convert.ToBase64String(bytes);
		Debug.Log("purchase.signature : "+purchase.signature);
		bytes = System.Text.Encoding.UTF8.GetBytes(purchase.signature);
		string basedSign = System.Convert.ToBase64String(bytes);
		NetMgr.InAppPurchase(false, purchase.productId, basedJson, basedSign, mIAPEvent);
		
		Debug.Log( "purchaseSucceededEvent: " + purchase );
	}
	
	void purchaseFailedEvent( string error, int response )
	{
		Debug.Log( "purchaseFailedEvent: " + error + ", response: " + response );
	}
	
	void mCancelIAP(){
		DialogueMgr.ShowDialogue("구매 실패", mItemname + " 구매를 실패 했습니다.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		Debug.Log ("FailedEvent");		
	}
	
	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		mDoneIAP();
	}
	
	
	void consumePurchaseFailedEvent( string error )
	{
		DialogueMgr.ShowDialogue("컨슘 실패", mItemname + " 컨슘을 실패 했습니다.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		Debug.Log ("FailedConsume");
	}
	
	#else	
	void purchaseSucceededEvent(string receipt)
	{	
		byte[] bytes = System.Text.Encoding.UTF8.GetBytes(receipt);
		mIAPEvent = new InAppPurchaseEvent(FinishIAP);
		NetMgr.InAppPurchase(false, mItemcode, System.Convert.ToBase64String(bytes), "", mIAPEvent);
	}
	
	void purchaseFailedEvent(string receipt)
	{		
	}
	
	void mCancelIAP(){
		DialogueMgr.ShowDialogue("구매 실패", mItemname + " 구매를 실패 했습니다.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		Debug.Log ("FailedEvent");
	}
	
	#endif
	
	public void mDoneIAP(){
//		mProfileEvent = new GetProfileEvent (new EventDelegate (this, "addruby"));
//		NetMgr.GetProfile (UserMgr.UserInfo.memSeq,mProfileEvent);
//		UserMgr.UserMailCount += 1;
		DialogueMgr.ShowDialogue("구매 성공", mItemname + " 구매가 완료 되었습니다.\n우편함을 확인해주세요.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		
		Debug.Log ("All PurchaseSucceeded");
		
	}
	
	public void FinishIAP(){
		if(mIAPEvent.Response.code == 0){
			#if(UNITY_ANDROID)
			GoogleIAB.consumeProduct (mItemcode);
			#else
			mDoneIAP();
			#endif
			
		} else{
			//failed
			DialogueMgr.ShowDialogue("구매 실패", mItemname + " 구매를 실패 했습니다.", DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
	}
}
