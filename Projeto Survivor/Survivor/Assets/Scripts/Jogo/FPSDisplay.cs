using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSDisplay : MonoBehaviour
{

    //float deltaTime = 0.0f;

    private void Start()
    {
       // QualitySettings.vSyncCount = 4;
    }
    void Update()
    {
        //deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
    }

    void OnGUI()
    {
        int w = Screen.width, h = Screen.height;

        GUIStyle style = new GUIStyle();

        Rect rect = new Rect(0, 0, w, h * 2 / 100);
        style.alignment = TextAnchor.UpperLeft;
        style.fontSize = h * 5 / 100;
        style.normal.textColor = new Color(0.0f, 0.0f, 0.5f, 1.0f);
        //float msec = deltaTime * 1000.0f;
        float fps = 1.0f / Time.deltaTime;
        string text = string.Format("({0} deltaTime) ({1:0.} fps)", Time.deltaTime, fps);
        GUI.Label(rect, text, style);

    }
}
