using UnityEngine;
using System.Collections;

public class AutoFade : MonoBehaviour
{
	private static AutoFade m_Instance = null;
	private string m_LevelName = "";
	
	private static AutoFade Instance
	{
		get
		{
			if (m_Instance == null)
			{
				m_Instance = (new GameObject("AutoFade")).AddComponent<AutoFade>();
			}
			return m_Instance;
		}
	}
	
	private void Awake()
	{
		DontDestroyOnLoad(this);
		m_Instance = this;
	}
	
	private IEnumerator Fade(float aFadeOutTime, float aFadeInTime)
	{
//		TweenAlpha.Begin (GameObject.Find("UI Root"), aFadeOutTime, 0f);
//		yield return new WaitForSeconds(aFadeOutTime);
		yield return new WaitForSeconds(0);

//		Application.LoadLevel(m_LevelName);
		Application.LoadLevelAsync(m_LevelName);
//		yield return new AsyncOperation ();

//		TweenAlpha.Begin (GameObject.Find("UI Root"), 0f, 0f);
//		TweenAlpha.Begin (GameObject.Find("UI Root"), aFadeInTime, 1.0f);
//		yield return new WaitForSeconds(aFadeInTime);

	}
	private void StartFade(float aFadeOutTime, float aFadeInTime)
	{
		UtilMgr.PreLoadedLevelName = Application.loadedLevelName;
//		StartCoroutine(Fade(aFadeOutTime, aFadeInTime));
		UtilMgr.IsUntouchable = true;
		Application.LoadLevelAsync(m_LevelName);
		UtilMgr.IsUntouchable = false;
	}
	
	public static void LoadLevel(string aLevelName,float aFadeOutTime, float aFadeInTime)
	{
		DialogueMgr.DismissDialogue();
		Instance.m_LevelName = aLevelName;
		Instance.StartFade(aFadeOutTime, aFadeInTime);
	}

	public static void LoadLevel(string aLevelName)
	{
		LoadLevel(aLevelName, 0, 0);
	}

}