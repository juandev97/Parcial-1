using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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

            anim.SetTrigger("punch");
            punch.SetActive(true);
        }

        if(Input.GetKeyUp("space")){
              
               punch.SetActive(false);
        }

    }

    private void FixedUpdate() {
        // se aplica el movimiento
       rotacion = Input.GetAxis("Horizontal")*velocidadDeRotacion;
        

        movimiento = Input.GetAxis("Vertical")*speed;
        movimiento *= Time.deltaTime;
        rotacion *= Time.deltaTime;
        transform.Translate(0,0,movimiento);
        transform.Rotate(0,rotacion,0);

        aux = (int) ((movimiento*4) * speed);

        anim.SetInteger("speed",aux);


    
        auxText= time.ToString();
        timeText.text = auxText;
        if(aux == 0){
            
            timeText.enabled = true;
            

            time -= Time.deltaTime;
        }else {
            time = maxTime;
            timeText.text = maxTime.ToString();
            timeText.enabled = false;
        }
    }



}
