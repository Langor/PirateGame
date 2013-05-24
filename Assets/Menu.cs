using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public Rect RectStart;
	public Rect RectLoad;
	public Rect RectOptions;
	public Rect RectQuit;
	public bool isOptions; //подменю(опции)
	public string SceneNameStart;
	public GUISkin skin;
	public Texture2D fon; //фон главного меню
	
	void OnGUI(){
		GUI.skin = skin;
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),fon);//расположение по высоте и ширине экрана
		
		if(!isOptions){
			if(GUI.Button(RectStart, "Start")){
				Application.LoadLevel(SceneNameStart);
			}
			
			//if(GUI.Button(RectLoad, "Load")){
			//	
			//}
			
			//if(GUI.Button(RectOptions, "Options")){
			//	isOptions = true;
			//}
			
			if(GUI.Button(RectQuit, "Quit")){
				Application.Quit();
			}
		//}
		//else{
		//	if(GUI.Button(RectStart, "+")){ //прибавляем дистанцию теней
		//		QualitySettings.shadowDistance = 10;
		//	}
		//	
		//	if(GUI.Button(RectLoad, "-")){
		//		QualitySettings.shadowDistance = 0;
		//	}
		//	
		//	if(GUI.Button(RectQuit, "<<Back")){
		//		isOptions = false;
		//	}
		}
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
