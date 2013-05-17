using UnityEngine;
using System.Collections;

public class MenuInGame : MonoBehaviour {
	public Rect RectStart;
	public Rect RectSave;
	public Rect RectLoad;
	public Rect RectOptions;
	public Rect RectQuit;
	public GUISkin skin;
	public bool isMenu;
	public bool isOptions;
	
		void OnGUI(){
		GUI.skin = skin;
		
		if(isMenu){
		
			if(!isOptions){
				if(GUI.Button(RectStart, "Resume")){
					isMenu = false;
					Time.timeScale = 1;
				}
				
				if(GUI.Button(RectSave, "Save")){
					gameObject.SendMessage("Save");//ищем в игровых объектах метод Save
				}
				
				if(GUI.Button(RectLoad, "Load")){
					gameObject.SendMessage("Load");//ищем метод Load
				}
				
				if(GUI.Button(RectOptions, "Options")){
					isOptions = true;
				}
				
				if(GUI.Button(RectQuit, "Quit")){
					Application.LoadLevel("Scene1");
				}
			}
			else{
				if(GUI.Button(RectStart, "+")){ //прибавляем дистанцию теней
					QualitySettings.shadowDistance = 10;
				}
				
				if(GUI.Button(RectLoad, "-")){
					QualitySettings.shadowDistance = 0;
				}
				
				if(GUI.Button(RectQuit, "<<Back")){
					isOptions = false;
				}
			}
		}
	}
	
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape)){
			isMenu = true;
			Time.timeScale = 0;
		}
	}
}
