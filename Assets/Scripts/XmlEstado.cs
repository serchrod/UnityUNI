using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.IO;
#if NETFX_CORE
using Windows.Storage;
using Windows.Storage.Streams;
#endif
//using System.IO.IsolatedStorage;

public class XmlEstado : MonoBehaviour {
	public int puntuacionMax = 0;
	public int distanciaMax = 0;
	public int muertesTotal = 0;
	//private static IsolatedStorageFile isoStore = IsolatedStorageFile.GetStore(IsolatedStorageScope.User | IsolatedStorageScope.Assembly, null, null);
	private static XmlDocument xmlDoc = new XmlDocument();
	public static XmlEstado xmlEstado;

	void Start(){
		LoadFromXml();
		string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml";
		//string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml"
		Debug.Log (filepath);
		/*if (!(File.Exists (filepath))) {
		//if (!((filepath))) {
			WriteToXml();
		}
		 */
	}

	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

	void Awake(){
		if(xmlEstado==null){
			xmlEstado = this;
			DontDestroyOnLoad(gameObject);
		}else if(xmlEstado!=this){
			Destroy(gameObject);
		}
	}

	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void WriteToXml(){
		string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml";
		//string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml"
		//if(File.Exists (filepath)){
		#if NETFX_CORE
		if(filepath != null){
		#else
		if(File.Exists (filepath)){
		#endif
			xmlDoc.Load(filepath);
			
			XmlElement elmRoot = xmlDoc.DocumentElement;
			
			elmRoot.RemoveAll(); // clear all inside the transforms node.
			
			XmlElement elmNew = xmlDoc.CreateElement("datos"); // create the rotation node.
			
			XmlElement record = xmlDoc.CreateElement("record"); // create the x node.
			record.InnerText = puntuacionMax.ToString(); // apply to the node text the values of the variable.
			
			XmlElement distancia = xmlDoc.CreateElement("distanciaMax"); // create the y node.
			distancia.InnerText = distanciaMax.ToString(); // apply to the node text the values of the variable.
			
			XmlElement muertes = xmlDoc.CreateElement("muertes"); // create the z node.
			muertes.InnerText = muertesTotal.ToString(); // apply to the node text the values of the variable.
			
			elmNew.AppendChild(record); // make the rotation node the parent.
			elmNew.AppendChild(distancia); // make the rotation node the parent.
			elmNew.AppendChild(muertes); // make the rotation node the parent.
			elmRoot.AppendChild(elmNew); // make the transform node the parent.
			
			xmlDoc.Save(filepath); // save file.
		//}
		#if NETFX_CORE
		}
		#else
		}
		#endif 
	}
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void LoadFromXml(){
		string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml";
		//string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml"
		//if(File.Exists (filepath)){
		#if NETFX_CORE
		if(filepath != null){ 
		#else
			if(File.Exists (filepath)){
		#endif
			xmlDoc.Load(filepath); 
			
			XmlNodeList transformList = xmlDoc.GetElementsByTagName("datos");
			
			foreach (XmlNode transformInfo in transformList){
				XmlNodeList transformcontent = transformInfo.ChildNodes;
				
				foreach (XmlNode transformItens in transformcontent){
					if(transformItens.Name == "record"){
						puntuacionMax = int.Parse(transformItens.InnerText); // convert the strings to float and apply to the X variable.
					}
					if(transformItens.Name == "distanciaMax"){
						distanciaMax = int.Parse(transformItens.InnerText); // convert the strings to float and apply to the Y variable.
					}
					if(transformItens.Name == "muertes"){
						muertesTotal = int.Parse(transformItens.InnerText); // convert the strings to float and apply to the Z variable.
					}
				}
			}
		//}
		#if NETFX_CORE
		}
		#else
		}
		#endif
	}
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
}
