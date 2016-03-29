using UnityEngine;
using System.Collections;

public class ShopGoldInfo {
	long _itemFK;
	public long itemFK {
		get {
			return _itemFK;
		}
		set {
			_itemFK = value;
		}
	}

//2000000500,
	int _price;
	public int price {
		get {
			return _price;
		}
		set {
			_price = value;
		}
	}

//5500,
	string _productCode;
	public string productCode {
		get {
			return _productCode;
		}
		set {
			_productCode = value;
		}
	}

//"com.liveball.cash5000",
	int _itemType;
	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

//1,
	string _path;
	public string path {
		get {
			return _path;
		}
		set {
			_path = value;
		}
	}

//"shop/",
	string _image;
	public string image {
		get {
			return _image;
		}
		set {
			_image = value;
		}
	}

//"item_ruby_50.png",
	string _productName;
	public string productName {
		get {
			return _productName;
		}
		set {
			_productName = value;
		}
	}

//"500 GOLD",
	string _productDesc;
	public string productDesc {
		get {
			return _productDesc;
		}
		set {
			_productDesc = value;
		}
	}

//"",
	int _storeFK;
	public int storeFK {
		get {
			return _storeFK;
		}
		set {
			_storeFK = value;
		}
	}

//10001,
	string _priceDesc;
	public string priceDesc {
		get {
			return _priceDesc;
		}
		set {
			_priceDesc = value;
		}
	}

//"5,500",
	int _productFK;//1001

	public int productFK {
		get {
			return _productFK;
		}
		set {
			_productFK = value;
		}
	}
}
