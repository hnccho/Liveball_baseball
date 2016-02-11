using UnityEngine;
using System.Collections;

public class IAPInfo {
	int _orderNo;
	public int orderNo {
		get {
			return _orderNo;
		}
		set {
			_orderNo = value;
		}
	}

//: 3,
	int _productNo;
	public int productNo {
		get {
			return _productNo;
		}
		set {
			_productNo = value;
		}
	}

//: 4,
	int _productId;
	public int productId {
		get {
			return _productId;
		}
		set {
			_productId = value;
		}
	}

//: 4,
	int _purchaseStatus;
	public int purchaseStatus {
		get {
			return _purchaseStatus;
		}
		set {
			_purchaseStatus = value;
		}
	}

//: 0,
	string _productCode;
	public string productCode {
		get {
			return _productCode;
		}
		set {
			_productCode = value;
		}
	}

//: "brand_1000_001",
	string _purchaseKey;//: "5d0bd1c9d1b44ad5c6250a8094968bc3"

	public string purchaseKey {
		get {
			return _purchaseKey;
		}
		set {
			_purchaseKey = value;
		}
	}
}
