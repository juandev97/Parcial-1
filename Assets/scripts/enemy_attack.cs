using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_attack : MonoBehaviour
{
    // Start is called before the first frame update



private void OnTriggerEnter(Collider other) {

    // si el personaje hace un ataque frente a la capsula 
    if(other.gameObject.tag == "punch"){
        // se destruye 
        Destroy(this.gameObject);
        Debug.Log("Buum");


    }else  if(other.gameObject.tag == "Player"){
        // si la capsula toca al perosnaje 
        // aparece este mensaje
        Debug.Log("aaah");
    }
}

}
