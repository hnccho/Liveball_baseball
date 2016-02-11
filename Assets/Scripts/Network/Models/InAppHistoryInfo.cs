using UnityEngine;
using System.Collections;

public class InAppHistoryInfo {
	int _orderNo;

	public int orderNo {
		get {
			return _orderNo;
		}
		set {
			_orderNo = value;
		}
	}

	int _productNo;

	public int productNo {
		get {
			return _productNo;
		}
		set {
			_productNo = value;
		}
	}

	int _productId;

	public int productId {
		get {
			return _productId;
		}
		set {
			_productId = value;
		}
	}

	int _purchaseStatus;

	public int purchaseStatus {
		get {
			return _purchaseStatus;
		}
		set {
			_purchaseStatus = value;
		}
	}

	int _productPrice;

	public int productPrice {
		get {
			return _productPrice;
		}
		set {
			_productPrice = value;
		}
	}

	string _productCode;

	public string productCode {
		get {
			return _productCode;
		}
		set {
			_productCode = value;
		}
	}

	string _purchaseKey;

	public string purchaseKey {
		get {
			return _purchaseKey;
		}
		set {
			_purchaseKey = value;
		}
	}

	string _productValue;

	public string productValue {
		get {
			return _productValue;
		}
		set {
			_productValue = value;
		}
	}

	string _registTime;

	public string registTime {
		get {
			return _registTime;
		}
		set {
			_registTime = value;
		}
	}
}
