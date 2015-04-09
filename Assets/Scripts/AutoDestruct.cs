using UnityEngine;
using System.Collections;
/*Script de auto destruccion de un GameObject.
 * Las variables publicas se usan para vincular objetos de la escena.
 * 
*/
public class AutoDestruct : MonoBehaviour{
    public float DestructTime = 0.10f;// Tiempo para auto destruccion 0.1 equivale a un segundo.
    void Start(){
        Destroy(gameObject, DestructTime);// Destruye el game object.
    }
}
