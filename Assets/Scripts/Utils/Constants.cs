using UnityEngine;
using System.Collections;

public class Constants {	
	public const float DEFAULT_SCR_RATIO = 1280f / 720f;
	public const string APPTAG = "StreetLab_Tuby";	
	public const bool IS_DEBUGGABLE = false;
	public const string CS_APP_KEY = "2gv515iiuby";	
	
	public const bool	IS_TSTORE = false;
	public const string	MARKET_URI_TSTORE = "PRODUCT_VIEW/0000308300/0";
	public const string GOOGLE_PUBLIC_KEY = "MIIBIjANBgkqhkiG9w0BAQEFAAOCAQ8AMIIBCgKCAQEAjGkEP5nvlwmRj60ulqwkvUV+DzylEtfrPUkeWOBoffMXwWFJKXWK88zYeSpJJfu0sAxMJ7u7Cumv3KYlV6uuG3pvmwQ/65qaYWoWxLvdx5RUpyrxOo4DjuDW3DfAbi9fr6TxoXHveN4Pm6gSnNuOwhQxYB9GsuODUkMAWdBvamvHHa97/dOED9VorP9C4SVWFiY13nhAjqm8uxZcFnw3Pwm1qHgFRSwKbw1cPSsbiBF6Pq03Gem/kNitoBf/2EcvkLX/h7CO3LHNvVMCImO2WdPH+1DgMw2AjCnUtMeqZw9Z4YoTbOV/Q1jOLhVgdt2JWMWxaAeTQhNVV1tFhgA3vwIDAQAB";
	
	public const string HOST					= 	"appif.liveball.kr";
	public const string TEST_HOST					= 	"192.168.0.5";
	
	public const string COMMUNITY_URL = "http://cafe.naver.com/tuby";
	
	public const string CASHSLIDE_APP_ID = "g73e1946";
	
	public const string DF_SPORTS_FOOTBALL = "DF_SPORTS_FOOTBALL";
	public const string DF_SPORTS_BASEBALL = "DF_SPORTS_BASEBALL";
	public const string DF_SPORTS_VOLLEYBALL = "DF_SPORTS_VOLLEYBALL";
	public const string DF_SPORTS_BASKETBALL = "DF_SPORTS_BASKETBALL";

	public static int SCREEN_HEIGHT_ORIGINAL = 0;
	public static int HEIGHT_STATUS_BAR = 0;

	public const string URL_CERT = "http://auth.friize.com/m/user_auth.php";
//	public const string URL_ATTENDANCE = "events/attendance_confirm/";
	public const string URL_ATTENDANCE = "events/daily_reward/";

	public const string STORE_GOOGLE ="market://details?id=com.streetlab.tuby";
	public const string STORE_IPHONE ="https://itunes.apple.com/kr/app/id1000138413?mt=8";

	/*/
	// Real
	public static string QUERY_SERVER_HOST 	= 	"http://" + HOST + ":5002/webTuby/query.frz";
	public static string IMAGE_SERVER_HOST 	= 	"http://" + HOST + ":5002/tuby_file/";
	
	public static string WITHDRAW_URL 				= 	"http://auth.liveball.kr/m/withdraw.php";
	public static string EVENT_URL 					= 	"http://tuby10.liveball.kr/events";
	public static string EVENT_ATTENDANCE_URL 		= 	"http://tuby10.liveball.kr/events/attendance/";
	public static string EVENT_ATTENDANCE_CONFIRM_URL = 	"http://tuby10.liveball.kr/events/attendance_confirm/";
	public static string EVENT_NOTI_URL 				= 	"http://tuby10.liveball.kr/events/T";
	public static string EVENT_NOTI_CONFIRM_URL 		= 	"http://tuby10.liveball.kr/events/noti";
	public static string MAIL_BOX_URL 				= 	"http://auth.liveball.kr/mailbox/";
	public static string MAIL_BOX_RECEIVE_REWARD_URL 	= 	"http://auth.liveball.kr/mailbox/receive.php";
	/*/

	public static float WEBVIEW_GAB_TOP = 96f;
//	public const string QUERY_SERVER_HOST 				= 	"http://" + TEST_HOST + ":5002/gameServer/query.frz";
	public static string NANOO_API_KEY					= 	"El1VRQgMG464OF0LRd1vPWGmRadCpfwyITK5ZpuNKLCBTIGSZE";
	public static string QUERY_SERVER_NANOO				= 	"https://api.nanoo.so";

	public static string CS_SERVER_HOST			 		= 	"http://www.crossshock.com:9696/Client/";
	public static string CS_ICON_HOST			 		= 	"http://www.crossshock.com/Icon/";

	public static string CHECK_TEST_SERVER_HOST 		= 	"http://" + HOST + ":4002/webTuby/query.frz";
	public static string CHECK_SERVER_HOST 				= 	"http://" + HOST + ":6002/webTuby/query.frz";
	public static string CHECK_SERVER_HOST2				= 	"http://" + HOST + ":600/webTuby/query.frz";

	public const string EULA_URL = "https://game.nanoo.so/liveball/notice/1714";
	public static int GAME_SERVER_PORT = 0;
	public static string EXT_SERVER_HOST = "";
	public static string AUTH_SERVER_HOST = "";
	public static string GAME_SERVER_HOST = "";
	public static string QUERY_SERVER_HOST 				= 	"http://" + HOST + ":6002/webTuby/query.frz";
//	public static string UPLOAD_TEST_SERVER_HOST 				= 	"http://" + HOST + ":4002/webTuby/query.frz";
	public static string UPLOAD_SERVER_HOST 				= 	"http://" + HOST + ":6002/webTuby/query.frz";
	public static string IMAGE_SERVER_HOST 				= 	"http://" + HOST + ":6002/tuby_file/";

	public static string WITHDRAW_URL 					= 	"http://auth.liveball.kr/m/withdraw.php";
	public static string TEST_EVENT_URL 				= 	"http://test.streetlab.co.kr/events";
	#if UNITY_EDITOR
	public static string EVENT_URL 						= 	"http://tuby10.friize.com/events";
#elif UNITY_IOS
	public static string EVENT_URL 						= 	"http://tuby10.friize.com/events/ios";
#else
	public static string EVENT_URL 						= 	"http://tuby10.friize.com/events";
#endif
	public static string TEST_NOTICE_URL 				= 	"http://test.streetlab.co.kr/notice";
	public static string NOTICE_URL 						= 	"http://tuby10.friize.com/notice";
	public static string EVENT_ATTENDANCE_URL 			= 	"http://test.streetlab.co.kr/events/attendance/";
	public static string EVENT_ATTENDANCE_CONFIRM_URL 	= 	"http://test.streetlab.co.kr/events/attendance_confirm/";
	public static string EVENT_NOTI_URL 				= 	"http://test.streetlab.co.kr/events/t/";
	public static string EVENT_NOTI_CONFIRM_URL 		= 	"http://test.streetlab.co.kr/events/noti";
	public static string MAIL_BOX_URL 					= 	"http://auth.liveball.kr/mailbox/";
	public static string MAIL_BOX_RECEIVE_REWARD_URL	= 	"http://auth.liveball.kr/mailbox/receive.php";
	//*/
	
	//	static string QUERY_SERVER_HOST_R 	= 	"http://" + HOST + ":5002/gameServer/query.frz";
	//	static string IMAGE_SERVER_HOST_R 	= 	"http://" + HOST + ":5002/tubyfiles/";
	//
	//	static string WITHDRAW_URL_R 				= 	"http://auth.liveball.kr/m/withdraw.php";
	//	static string EVENT_URL_R 					= 	"http://tuby10.liveball.kr/events";
	//	static string EVENT_ATTENDANCE_URL_R 		= 	"http://tuby10.liveball.kr/events/attendance/";
	//	static string EVENT_ATTENDANCE_CONFIRM_URL_R = 	"http://tuby10.liveball.kr/events/attendance_confirm/";
	//	static string EVENT_NOTI_URL_R 				= 	"http://tuby10.liveball.kr/events/T";
	//	static string EVENT_NOTI_CONFIRM_URL_R 		= 	"http://tuby10.liveball.kr/events/noti";
	//	static string MAIL_BOX_URL_R 				= 	"http://auth.liveball.kr/mailbox/";
	//	static string MAIL_BOX_RECEIVE_REWARD_URL_R 	= 	"http://auth.liveball.kr/mailbox/receive.php";
	
	static string QUERY_SERVER_HOST_T 				= 	"http://" + HOST + ":6002/gameServer/query.frz";
	static string IMAGE_SERVER_HOST_T 				= 	"http://" + HOST + ":6002/tubyfiles/";
	
	static string WITHDRAW_URL_T 				= 	"http://auth.liveball.kr/m/withdraw.php";
	static string EVENT_URL_T 						= 	"http://test.streetlab.co.kr/events";
	static string EVENT_ATTENDANCE_URL_T 			= 	"http://test.streetlab.co.kr/events/attendance/";
	static string EVENT_ATTENDANCE_CONFIRM_URL_T 	= 	"http://test.streetlab.co.kr/events/attendance_confirm/";
	static string EVENT_NOTI_URL_T 					= 	"http://test.streetlab.co.kr/events/t/";
	static string EVENT_NOTI_CONFIRM_URL_T 			= 	"http://test.streetlab.co.kr/events/noti";
	static string MAIL_BOX_URL_T 					= 	"http://auth.liveball.kr/mailbox/";
	static string MAIL_BOX_RECEIVE_REWARD_URL_T 		= 	"http://auth.liveball.kr/mailbox/receive.php";
	
	public const string IMAGE_HTTP_PREFIX 		= 	"http://";
	public const string IMAGE_ICON_URL_PREFIX 	= 	"icon_";
	public const string IMAGE_POSTER_URL_PREFIX 	= 	"poster_";

//	<!-- Preference String -->
	public const string PrefGcm_registeration_id = "gcm_registeration_id";
	public const string PrefProperty_app_version = "property_app_version";
	public const string PrefMem_seq = "mem_seq";
	public const string PrefBetting_golden_ball = "betting_golden_ball";
	public const string PrefMy_total_golden_ball = "my_total_golden_ball";
	public const string PrefMy_temp_golden_ball = "my_temp_golden_ball";
	public const string PrefMy_total_ruby = "my_total_ruby";
	public const string PrefMy_total_diamond = "my_total_diamond";
//	public const string PrefEmail = "email";
//	public const string PrefPwd = "pwd";
//	public const string PrefGuest = "guest";
	public const string PrefNick = "nick";
	public const string PrefNotice = "notice";
	public const string PrefTutorial = "tutorial";
	public const string PrefEvents = "events";
	public const string PrefRegistType = "RegistType";
	public const string PrefServerTest = "serverTest";
	public const string PrefSetting_vibrate_on_off = "setting_vibrate_on_off";
	public const string PrefSetting_watching_method = "setting_system_watching_method";
	public const string PrefIs_first_installed = "is_first_installed";
			
	public static void setServerTest(){
		string flag = PlayerPrefs.GetString (PrefServerTest);
//		Debug.Log ("test flag : " + flag);
		if(flag.Equals("D")){
			QUERY_SERVER_HOST = "http://" + TEST_HOST + ":5002/gameServer/query.frz";
			IMAGE_SERVER_HOST = IMAGE_SERVER_HOST_T;
			
			WITHDRAW_URL =  WITHDRAW_URL_T;
			EVENT_URL = EVENT_URL_T;
			EVENT_ATTENDANCE_URL = EVENT_ATTENDANCE_URL_T;
			EVENT_ATTENDANCE_CONFIRM_URL = EVENT_ATTENDANCE_CONFIRM_URL_T;
			EVENT_NOTI_URL = EVENT_NOTI_URL_T;
			EVENT_NOTI_CONFIRM_URL = EVENT_NOTI_CONFIRM_URL_T;
			MAIL_BOX_URL = MAIL_BOX_URL_T;
			MAIL_BOX_RECEIVE_REWARD_URL = MAIL_BOX_RECEIVE_REWARD_URL_T;
		} else{
			QUERY_SERVER_HOST = QUERY_SERVER_HOST_T;
			IMAGE_SERVER_HOST = IMAGE_SERVER_HOST_T;
			
			WITHDRAW_URL =  WITHDRAW_URL_T;
			EVENT_URL = EVENT_URL_T;
			EVENT_ATTENDANCE_URL = EVENT_ATTENDANCE_URL_T;
			EVENT_ATTENDANCE_CONFIRM_URL = EVENT_ATTENDANCE_CONFIRM_URL_T;
			EVENT_NOTI_URL = EVENT_NOTI_URL_T;
			EVENT_NOTI_CONFIRM_URL = EVENT_NOTI_CONFIRM_URL_T;
			MAIL_BOX_URL = MAIL_BOX_URL_T;
			MAIL_BOX_RECEIVE_REWARD_URL = MAIL_BOX_RECEIVE_REWARD_URL_T;
		}
	}

	public const string POST_SPOS_STATUS = "1000";//	경기상태통보
	public const string POST_GAME_STATUS = "1100";//경기상태변경
	public const string POST_GAME_START = "1101";//경기시작
	public const string POST_GAME_STOP = "1102";//경기종료
	public const string POST_QUIZ_START = "1201";//퀴즈시작
	public const string POST_QUIZ_RESULT = "1202";//퀴즈결과
	public const string POST_QUIZ_CANCEL = "1203";//퀴즈무효
	public const string POST_QUIZ_REFUND = "1204";//퀴즈환불
	public const string POST_QUIZ_MODIFY = "1205";//퀴즈정정
	public const string POST_GAME = "1301";//스코어보드 (모든이닝점수, 각팀의 에러,히트, 홈런....)
	public const string POST_SCORE = "1302";//점수, 주루, 볼카운트, 선수(투수,타자)정보
	public const string POST_PLAYER = "1303";//점수, 주루, 볼카운트, 선수(투수,타자)정보
	public const string POST_BCNT = "1304";//점수, 주루, 볼카운트, 선수(투수,타자)정보
	public const string POST_MSG = "2000";//일반메시지 - 앱을 실행시킴
	public const string POST_POPUP = "2100";//팝업공지

}
