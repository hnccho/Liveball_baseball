using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using UnityEngine.Purchasing;
using System;

public class Shop : MonoBehaviour{//, IStoreListener {

//	private static IStoreController mStoreController;
//	private static IAppleExtensions mAppleExtensions;

	private static string kProductIDConsumable =    "consumable";                                                         // General handle for the consumable product.
	private static string kProductIDNonConsumable = "nonconsumable";                                                  // General handle for the non-consumable product.
	private static string kProductIDSubscription =  "subscription";                                                   // General handle for the subscription product.

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

	string[] mProductCodes = new string[]{"com.liveball.cash5000", "com.liveball.cash10000", "com.liveball.cash20000",
		"com.liveball.cash30000", "com.liveball.cash50000"};

	// Use this for initialization
	void Start () {
		SetDelegates();
		IsSupported = false;

//		if(mStoreController == null){
//			InitializePurchasing();
//		}
	}

	void InitializePurchasing(){
//		if (IsInitialized()) return;
//
//		var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());
//
//		if(UtilMgr.IsMLB())
//			builder.Configure<IGooglePlayConfiguration>().SetPublicKey(Constants.GOOGLE_PUBLIC_KEY_MLB);
//		else
//			builder.Configure<IGooglePlayConfiguration>().SetPublicKey(Constants.GOOGLE_PUBLIC_KEY_KBO);
//
//		// Add a product to sell / restore by way of its identifier, associating the general identifier with its store-specific identifiers.
//		builder.AddProduct(mProductCodes[0], ProductType.Consumable, 
//			new IDs(){{ mProductCodes[0], AppleAppStore.Name},{ mProductCodes[0],  GooglePlay.Name },});
//		builder.AddProduct(mProductCodes[1], ProductType.Consumable, 
//			new IDs(){{ mProductCodes[1], AppleAppStore.Name},{ mProductCodes[1],  GooglePlay.Name },});
//		builder.AddProduct(mProductCodes[2], ProductType.Consumable, 
//			new IDs(){{ mProductCodes[2], AppleAppStore.Name},{ mProductCodes[2],  GooglePlay.Name },});
//		builder.AddProduct(mProductCodes[3], ProductType.Consumable, 
//			new IDs(){{ mProductCodes[3], AppleAppStore.Name},{ mProductCodes[3],  GooglePlay.Name },});
//		builder.AddProduct(mProductCodes[4], ProductType.Consumable, 
//			new IDs(){{ mProductCodes[4], AppleAppStore.Name},{ mProductCodes[4],  GooglePlay.Name },});
//
//		UnityPurchasing.Initialize(this, builder);
	}

	bool IsInitialized()
	{
//		return mStoreController != null && mAppleExtensions != null;
		return false;
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
			if(UtilMgr.IsMLB())
				GoogleIAB.init(Constants.GOOGLE_PUBLIC_KEY_MLB);
			else
				GoogleIAB.init(Constants.GOOGLE_PUBLIC_KEY_KBO);
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
	
	public void RequestIAP(string itemcode, string itemname){
		mItemname = itemname;
		mItemcode = itemcode;
		#if(UNITY_ANDROID)
		GoogleIAB.purchaseProduct(itemcode);
		#else
		IOSMgr.BuyItem(itemcode);
		#endif
	}

	public void BuyProduct(string itemCode, string itemName){
//		mItemname = itemName;
//		mItemcode = itemCode;
//		try
//		{
//			if (IsInitialized())
//			{
//				// ... look up the Product reference with the general product identifier and the Purchasing system's products collection.
//				Product product = mStoreController.products.WithID(mItemcode);
//
//				// If the look up found a product for this device's store and that product is ready to be sold ... 
//				if (product != null && product.availableToPurchase)
//				{
//					Debug.Log (string.Format("Purchasing product asychronously: '{0}'", product.definition.id));// ... buy the product. Expect a response either through ProcessPurchase or OnPurchaseFailed asynchronously.
//					mStoreController.InitiatePurchase(product);
//				}
//				// Otherwise ...
//				else
//				{
//					// ... report the product look-up failure situation  
//					Debug.Log ("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
//				}
//			}
//			// Otherwise ...
//			else
//			{
//				// ... report the fact Purchasing has not succeeded initializing yet. Consider waiting longer or retrying initiailization.
//				Debug.Log("BuyProductID FAIL. Not initialized.");
//			}
//		}
//		// Complete the unexpected exception handling ...
//		catch (Exception e)
//		{
//			// ... by reporting any unexpected exception for later diagnosis.
//			Debug.Log ("BuyProductID: FAIL. Exception during purchase. " + e);
//		}
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
		if(purchases.Count > 0){
			mPurchase = purchases[0];
			foreach(ShopGoldInfo info in mGoldList){
				if(info.productCode.Equals(mPurchase.productId)){
					mItemcode = info.productCode;
					mItemname = info.productName;
					purchaseSucceededEvent(mPurchase);
					break;
				}
			}						
		}
	}	
	
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
		bytes = System.Text.Encoding.UTF8.GetBytes(purchase.signature);
		string basedSign = System.Convert.ToBase64String(bytes);
//		NetMgr.InAppPurchase(false, purchase.productId, basedJson, basedSign, mIAPEvent);
		NetMgr.InAppPurchase(false, purchase.productId, "", basedJson, mIAPEvent);
		
		Debug.Log( "purchaseSucceededEvent: " + purchase );
	}
	
	void purchaseFailedEvent( string error, int response )
	{
		Debug.Log( "purchaseFailedEvent: " + error + ", response: " + response );
	}
	
	void mCancelIAP(){
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseFailed"),
			string.Format(UtilMgr.GetLocalText("StrPurchaseFailed2"), mItemname),
			DialogueMgr.DIALOGUE_TYPE.Alert, null);
//		Debug.Log ("FailedEvent");		
	}
	
	void consumePurchaseSucceededEvent( GooglePurchase purchase )
	{
		mDoneIAP();
	}
	
	
	void consumePurchaseFailedEvent( string error )
	{
		DialogueMgr.ShowDialogue("Consume Failed", mItemname + " Consume Failed", DialogueMgr.DIALOGUE_TYPE.Alert, null);
//		Debug.Log ("FailedConsume");
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
		DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseSuccess"),
			string.Format(UtilMgr.GetLocalText("StrPurchaseSuccess2"), mItemname), DialogueMgr.DIALOGUE_TYPE.Alert, null);
		
		Debug.Log ("All PurchaseSucceeded");
		
	}
	
	public void FinishIAP(){
		if(mIAPEvent.Response.code == 0){
			#if(UNITY_ANDROID)
			GoogleIAB.consumeProduct (mItemcode);
			#else
			mDoneIAP();
			#endif
//			mDoneIAP();
		} else{
			//failed
					DialogueMgr.ShowDialogue(UtilMgr.GetLocalText("StrPurchaseFailed"),
						string.Format(UtilMgr.GetLocalText("StrPurchaseFailed2"), mItemname),
						DialogueMgr.DIALOGUE_TYPE.Alert, null);
		}
	}

	// IstoreListener
//	public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
//	{
//		mStoreController = controller;
//		mAppleExtensions = extensions.GetExtension<IAppleExtensions>();
//
//		Debug.Log("Available items:");
//		foreach (var item in controller.products.all)
//		{
//			if (item.availableToPurchase)
//			{
//				Debug.Log(string.Join(" - ",
//					new[]
//					{
//						item.metadata.localizedTitle,
//						item.metadata.localizedDescription,
//						item.metadata.isoCurrencyCode,
//						item.metadata.localizedPrice.ToString(),
//						item.metadata.localizedPriceString
//					}));
//			}
//		}
//
//		if (null != mStoreController)
//		{
//			// Prepare model for purchasing
////			if (mStoreController.products.all.Length > 0) 
////			{
////				m_SelectedItemIndex = 0;
////			}
//
//			// Populate the product menu now that we have Products
//			for (int t = 0; t < mStoreController.products.all.Length; t++)
//			{
//				var item = mStoreController.products.all[t];
//				var description = string.Format("{0} - {1}", item.metadata.localizedTitle, item.metadata.localizedPriceString);
//
//				// NOTE: my options list is created in InitUI
////				GetDropdown().options[t] = new Dropdown.OptionData(description);
//			}
//
//			// Ensure I render the selected list element
////			GetDropdown().RefreshShownValue();
//
//			// Now that I have real products, begin showing product purchase history
////			UpdateHistoryUI();
//		}
//	}
//
//
//	public void OnInitializeFailed(InitializationFailureReason error)
//	{
//		// Purchasing set-up has not succeeded. Check error for reason. Consider sharing this reason with the user.
//		Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
//	}
//
//
//	public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) 
//	{
//		// A consumable product has been purchased by this user.
//		if (string.Equals(args.purchasedProduct.definition.id, kProductIDConsumable, StringComparison.Ordinal))
//		{
//			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));//If the consumable item has been successfully purchased, add 100 coins to the player's in-game score.
////			ScoreManager.score += 100;
//			mIAPEvent = new InAppPurchaseEvent(FinishIAP);
//
//			byte[] bytes = System.Text.Encoding.UTF8.GetBytes(args.purchasedProduct.receipt);
//			string basedJson = System.Convert.ToBase64String(bytes);
//			Debug.Log("receipt : " + args.purchasedProduct.receipt);
////			bytes = System.Text.Encoding.UTF8.GetBytes(purchase.signature);
////			string basedSign = System.Convert.ToBase64String(bytes);
//			NetMgr.InAppPurchase(false, args.purchasedProduct.definition.id, basedJson, "", mIAPEvent);
//
////			Debug.Log( "purchaseSucceededEvent: " + purchase );
//		}
//
//		// Or ... a non-consumable product has been purchased by this user.
//		else if (String.Equals(args.purchasedProduct.definition.id, kProductIDNonConsumable, StringComparison.Ordinal))
//		{
//			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));}// Or ... a subscription product has been purchased by this user.
//		else if (String.Equals(args.purchasedProduct.definition.id, kProductIDSubscription, StringComparison.Ordinal))
//		{
//			Debug.Log(string.Format("ProcessPurchase: PASS. Product: '{0}'", args.purchasedProduct.definition.id));}// Or ... an unknown product has been purchased by this user. Fill in additional products here.
//		else 
//		{
//			Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));}// Return a flag indicating wither this product has completely been received, or if the application needs to be reminded of this purchase at next app launch. Is useful when saving purchased products to the cloud, and when that save is delayed.
//		return PurchaseProcessingResult.Complete;
//	}
//
//
//	public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
//	{
//		// A product purchase attempt did not succeed. Check failureReason for more detail. Consider sharing this reason with the user.
//		Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}",product.definition.storeSpecificId, failureReason));
//	}
}
