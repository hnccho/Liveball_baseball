using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Shop : MonoBehaviour {

//	public enum TYPE{
//		GOLD,
//		TICKET,
//		CARD,
//		SKILL
//	}
	public GameObject mItemShop;
	public GameObject mItemCard;
	public static int GOLD = 5;
	public static int TICKET = 4;
	public static int CARD = 2;
	public static int SKILL = 3;
	int mCategory;

	List<ItemShopGoldInfo> mList;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void InitGoldShop(string title, int category, GetItemShopGoldEvent goldEvent){
		mList = goldEvent.Response.data;
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

	}

	void InitTicketList(){		
		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mList.Count; i++){
			ItemShopGoldInfo shopInfo = mList[i];
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
			
			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}

	void InitCardList(){
		float height = 0;
		UIScrollView scrollview = transform.FindChild("Body").FindChild("Scroll View").GetComponent<UIScrollView>();
		for(int i = 0; i < mList.Count; i++){
			ItemShopGoldInfo shopInfo = mList[i];
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
			
			go.transform.FindChild("BtnRight").GetComponent<ShopItemBtns>().mInfo = shopInfo;
		}
		scrollview.ResetPosition();
	}

	void InitSkillList(){

	}
}
