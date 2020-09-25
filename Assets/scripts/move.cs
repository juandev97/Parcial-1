using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class move : MonoBehaviour
{

// los personajes necesitan una propiedad controller

    // y una velocidad base y un salto 
    public float movimiento;
    public float rotacion;
    public float speed = 10f;
    public float velocidadDeRotacion = 600f;

      public int aux;
    public float salto = 100f;

    public GameObject punch;

    public float maxTime = 10f;
    public float time;

    public Text timeText;

    string auxText;
     Animator anim;
    //public Animator anim;
// Rigidbody es el encargado de gestionar la fisica del pj


    // Start is called before the first frame update
    void Start()
    {
      
        anim = GetComponent<Animator>();
        time = maxTime;
        
    }

    // Update is called once per frame
    void Update()
    {

// obtenemos la tecla de ataque
        if(Input.GetKeyDown("space")){
// se dispara la animación y se activa el collider punch
            anim.SetTrigger("punch");
            punch.SetActive(true);
        }

        if(Input.GetKeyUp("space")){
            // al soltar se apaga el collider
              
               punch.SetActive(false);
        }

    }

    private void FixedUpdate() {
       
       // en pocas palabras se aplica un valor condo se preciona A o D (o las flechas de Izq y der)
       rotacion = Input.GetAxis("Horizontal")*velocidadDeRotacion;
        
        // en pocas palabras se aplica un valor condo se preciona W o S (o las flechas de arriba y abajo)
        movimiento = Input.GetAxis("Vertical")*speed;

        //  se multiplica por el tiempo en el que la tecla se presiona (llega a un valor maximo)
        movimiento *= Time.deltaTime;
        rotacion *= Time.deltaTime;
        
        // y se aplica el movimiento 
        transform.Translate(0,0,movimiento);
        transform.Rotate(0,rotacion,0);

        // usamos una variable auxiliar para calcular cuando se ejecuta la animación
        aux = (int) ((movimiento*4) * speed);

        // y se le pasa el valor a la animacion 
        anim.SetInteger("speed",aux);



        // contador cuando esta parado 

        // fijamos el valor del contador = al tiempo actual (es necesario pasarlo de float a string)
        auxText= time.ToString();
        timeText.text = auxText;

        if(aux == 0){
            // si el pj esta quieto la el aux es igual a 0 
            // se activa el contador en pantalla 
            timeText.enabled = true;

            // y se resta el tiempo
            time -= Time.deltaTime;

            if(time <= 0){
                // si se acaba el tiempo se carga la pantalla gameover
                SceneManager.LoadScene("gameover");
            }
        }else {
            // si el personaje se mueve el contador para y se resetea 
            time = maxTime;
            timeText.text = maxTime.ToString();
            timeText.enabled = false;
        }
    }



}
