using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MailBoxinfo {
	
	private int _mailSeq;
	public int mailSeq {
		get {
			return _mailSeq;
		}
		set {
			_mailSeq = value;
		}
	}
	
	private int _attachSeq;
	public int attachSeq {
		get {
			return _attachSeq;
		}
		set {
			_attachSeq = value;
		}
	}
	
	private int _attachType;
	public int attachType {
		get {
			return _attachType;
		}
		set {
			_attachType = value;
		}

	}
	private int _attachValue;
	public int attachValue {
		get {
			return _attachValue;
		}
		set {
			_attachValue = value;
		}
	}

	private int _useYN;
	public int useYN {
		get {
			return _useYN;
		}
		set {
			_useYN = value;
		}
	}
	private int _useDate;
	public int useDate {
		get {
			return _useDate;
		}
		set {
			_useDate = value;
		}
	}
	private string _useDateTime;
	public string useDateTime {
		get {
			return _useDateTime;
		}
		set {
			_useDateTime = value;
		}
	}

	private int _limitDate;
	public int limitDate {
		get {
			return _limitDate;
		}
		set {
			_limitDate = value;
		}
	}


	private string _limitDateTime;
	public string limitDateTime {
		get {
			return _limitDateTime;
		}
		set {
			_limitDateTime = value;
		}
	}

	
	private int _attachOption;
	public int attachOption {
		get {
			return _attachOption;
		}
		set {
			_attachOption = value;
		}
	}

	private string _attachDesc;
	public string attachDesc {
		get {
			return _attachDesc;
		}
		set {
			_attachDesc = value;
		}
	}
	private string _attachCode;
	public string attachCode {
		get {
			return _attachCode;
		}
		set {
			_attachCode = value;
		}
	}


}
