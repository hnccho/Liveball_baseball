using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mailinfo {

	string _mail_title;

	public string mail_title {
		get {
			return _mail_title;
		}
		set {
			_mail_title = value;
		}
	}



	long _itemFK;

	public long itemFK {
		get {
			return _itemFK;
		}
		set {
			_itemFK = value;
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
	
	private int _mailSeq;
	public int mailSeq {
		get {
			return _mailSeq;
		}
		set {
			_mailSeq = value;
		}
	}
	
	private int _memSeq;
	public int memSeq {
		get {
			return _memSeq;
		}
		set {
			_memSeq = value;
		}
	}
	
	private long _senderNo;
	public long senderNo {
		get {
			return _senderNo;
		}
		set {
			_senderNo = value;
		}

	}

	private long _sendDate;
	public long sendDate {
		get {
			return _sendDate;
		}
		set {
			_sendDate = value;
		}
	}

	string _imageName;

	public string imageName {
		get {
			return _imageName;
		}
		set {
			_imageName = value;
		}
	}

	string _imagePath;

	public string imagePath {
		get {
			return _imagePath;
		}
		set {
			_imagePath = value;
		}
	}

	long _nRemain;

	public long nRemain {
		get {
			return _nRemain;
		}
		set {
			_nRemain = value;
		}
	}

	int _itemType;

	public int itemType {
		get {
			return _itemType;
		}
		set {
			_itemType = value;
		}
	}

	private string _receiveDate;
	public string recvDateTime {
		get {
			return _receiveDate;
		}
		set {
			_receiveDate = value;
		}
	}

	string _expireDate;

	public string expireDate {
		get {
			return _expireDate;
		}
		set {
			_expireDate = value;
		}
	}

	string _sRemain;

	public string sRemain {
		get {
			return _sRemain;
		}
		set {
			_sRemain = value;
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

	int _bundle;

	public int bundle {
		get {
			return _bundle;
		}
		set {
			_bundle = value;
		}
	}

	private int _mailStatus;
	public int mailStatus {
		get {
			return _mailStatus;
		}
		set {
			_mailStatus = value;
		}
	}

	private long _readDate;
	public long readDate {
		get {
			return _readDate;
		}
		set {
			_readDate = value;
		}
	}

	private string _readDateTime;
	public string readDateTime {
		get {
			return _readDateTime;
		}
		set {
			_readDateTime = value;
		}
	}
	private string _currentDateTime;
	public string currentDateTime {
		get {
			return _currentDateTime;
		}
		set {
			_currentDateTime = value;
		}
	}

	private List<MailBoxinfo> _attach;
	public List<MailBoxinfo> attach {
		get {
			return _attach;
		}
		set {
			_attach = value;
		}
	}
	private int _code;
	public int code {
		get {
			return _code;
		}
		set {
			_code = value;
		}
	}

}
