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

public class XmlEstado : MonoBehaviour {
	public int puntuacionMax = 0;// Variable de la puntuacion mas alta.
	public int distanciaMax = 0;// Variable de la distancia mas alta.
	public int muertesTotal = 0;// Variable del total de muertes.
	public int dies = 0;// Contador de las muertes.
	// Variable de tipo XmlDocument que maneja todo con respecto al archivo.
	private static XmlDocument xmlDoc = new XmlDocument();
	// Variable publica de tipo XmlStado para acceder a los valores del XML desde cualquier archivo.
	public static XmlEstado xmlEstado;

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

	void Start(){
		LoadFromXml();
	}

	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void WriteToXml(){
		//Directorio del archivo XML.
		string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml";
		#if NETFX_CORE
		if(filepath != null){
		#else
		if(File.Exists (filepath)){// Comprueba que exista el archivo en ese directorio.
		#endif
			xmlDoc.Load(filepath);// Carga el archivo XML.

			XmlElement elmRoot = xmlDoc.DocumentElement;// Obtiene un elemento del XML.
			
			elmRoot.RemoveAll(); // Elimina el para re-escribirlo.
			
			XmlElement elmNew = xmlDoc.CreateElement("datos"); // Crea el nodo "datos".
			
			XmlElement record = xmlDoc.CreateElement("record"); // Crea el nodo "record".
			record.InnerText = puntuacionMax.ToString(); // Aplica al texto del nodo el valor de la varible.
			
			XmlElement distancia = xmlDoc.CreateElement("distanciaMax"); // Crea nodo "distanciaMax".
				distancia.InnerText = distanciaMax.ToString(); // Aplica al texto del nodo el valor de la variblee.
			
			XmlElement muertes = xmlDoc.CreateElement("muertes"); // Crea el nodo "muertes".
				muertes.InnerText = muertesTotal.ToString(); // Aplica al texto del nodo el valor de la variblee.
			
			elmNew.AppendChild(record); // hace el nodo datos el padre.
			elmNew.AppendChild(distancia); // hace el nodo datos el padre.
			elmNew.AppendChild(muertes); // hace el nodo datos el padre.
			elmRoot.AppendChild(elmNew); // make the transform node the parent.
			
			xmlDoc.Save(filepath); // Guarda el archivo.
		//}
		#if NETFX_CORE
		}
		#else
		}
		#endif 
	}
	//~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
	public void LoadFromXml(){
		//Directorio del archivo XML.
		string filepath = Application.dataPath + @"/StreamingAssets/juegoData.xml";
		#if NETFX_CORE
		if(filepath != null){ 
		#else
			if(File.Exists (filepath)){// Comprueba que exista el archivo en ese directorio.2
		#endif
			xmlDoc.Load(filepath);// Carga el archivo XML.
			
			// Crea una lista de nodos de los nodos con etiqueta datos.
			XmlNodeList datosList = xmlDoc.GetElementsByTagName("datos");
			//For Each que recorre la lista anterior 
			foreach (XmlNode datosInfo in datosList){
				XmlNodeList datosContent = datosInfo.ChildNodes;// Crea variable que almacena los nodos hijos de cada elementos.
				//For Each que recorre cada nodo de la lista anterior.
				foreach (XmlNode datosItems in datosContent){
						if(datosItems.Name == "record"){// Comprueba que exista un Item con el nombre record.
							puntuacionMax = int.Parse(datosItems.InnerText);// Convierte el string a int y lo almacena en la variable.
					}
						if(datosItems.Name == "distanciaMax"){// Comprueba que exista un Item con el nombre distanciaMax.
							distanciaMax = int.Parse(datosItems.InnerText);// Convierte el string a int y lo almacena en la variable..
					}
						if(datosItems.Name == "muertes"){// Comprueba que exista un Item con el nombre muertes.
							muertesTotal = int.Parse(datosItems.InnerText);// Convierte el string a int y lo almacena en la variable.
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
