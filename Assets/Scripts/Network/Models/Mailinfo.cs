using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mailinfo {
	
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
	private string _mailTitle;
	public string mailTitle {
		get {
			return _mailTitle;
		}
		set {
			_mailTitle = value;
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
	private string _recvDateTime;
	public string recvDateTime {
		get {
			return _recvDateTime;
		}
		set {
			_recvDateTime = value;
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
