using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CardPackListInfo {

	string _mail_title;

	public string mail_title {
		get {
			return _mail_title;
		}
		set {
			_mail_title = value;
		}
	}

	string _token;

	public string token {
		get {
			return _token;
		}
		set {
			_token = value;
		}
	}

	string _mail_desc;

	public string mail_desc {
		get {
			return _mail_desc;
		}
		set {
			_mail_desc = value;
		}
	}

	int _mailType;

	public int mailType {
		get {
			return _mailType;
		}
		set {
			_mailType = value;
		}
	}

	int _outCode;

	public int outCode {
		get {
			return _outCode;
		}
		set {
			_outCode = value;
		}
	}

	List<CardPackInfo> _item;

	public List<CardPackInfo> item {
		get {
			return _item;
		}
		set {
			_item = value;
		}
	}
}
