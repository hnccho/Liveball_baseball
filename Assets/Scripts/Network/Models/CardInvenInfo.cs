using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardInvenInfo {

//	int _memberNo;
	long _totalPoint;
	
	public long totalPoint {
		get {
			return _totalPoint;
		}
		set {
			_totalPoint = value;
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

	List<CardInfo> _item;

	public List<CardInfo> item {
		get {
			return _item;
		}
		set {
			_item = value;
		}
	}
}
