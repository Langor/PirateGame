using UnityEngine;
using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Collections;
using System.Collections.Generic;

public class SaviorAndLoader : MonoBehaviour {
	public void Save(){
		PositionVariable pv = new PositionVariable();
		pv.positionX = transform.position.x;
		pv.positionY = transform.position.y;
		pv.positionZ = transform.position.z;
		
		//далее создаём файл, куда будут сохраняться позиции
		FileStream file = new FileStream("Save.dat", FileMode.Create);
		BinaryFormatter binFor = new BinaryFormatter();
		binFor.Serialize(file,pv);
		file.Close();
	}
	public void Load(){
		IFormatter If = new BinaryFormatter();
		FileStream file = new FileStream("Save.dat", FileMode.Open, FileAccess.Read);
		PositionVariable pv2 = (PositionVariable)If.Deserialize(file);
		transform.position = new Vector3(pv2.positionX, pv2.positionY, pv2.positionZ);
		file.Close();
	}
}

[Serializable]
class PositionVariable{
	public float positionX;
	public float positionY;
	public float positionZ;
}
	

