
#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;

public class Editor_openScene : EditorWindow
{

    //--------------------------------------------------------------------------
    // Init()
    //--------------------------------------------------------------------------
    [MenuItem("@RankingBall/opneScene")]
    static void Init()
    {
        Editor_openScene win = (Editor_openScene)EditorWindow.GetWindow(typeof(Editor_openScene));
        win.Show();
    }





    //--------------------------------------------------------------------------
    // OnGUI()
    //--------------------------------------------------------------------------
    void OnGUI()
    {
        GUILayout.Label("", GUILayout.Width(200));
        if (GUILayout.Button("Play", GUILayout.Width(150)))
        {
            string path = Application.dataPath + "/Scenes/Login.unity";
            Press_LoadScene(path, true);
        }

        GUILayout.Label("", GUILayout.Width(200));
        if (GUILayout.Button("Stop", GUILayout.Width(150)))
        {
			if(EditorApplication.isPlaying) EditorApplication.isPlaying = false;
        }


        GUILayout.Label("", GUILayout.Width(200));
        if (GUILayout.Button("Landing", GUILayout.Width(150)))
        {
            string path = Application.dataPath + "/Scenes/Landing.unity";
            Press_LoadScene(path, false);
        }


    }

	void Press_LoadScene(string path, bool play)
    {
		if(EditorApplication.isPlaying) return;

        bool want = EditorApplication.SaveCurrentSceneIfUserWantsTo();
        if(want) EditorApplication.OpenScene(path);

		if(play) EditorApplication.isPlaying = true;
    }


}
#endif




