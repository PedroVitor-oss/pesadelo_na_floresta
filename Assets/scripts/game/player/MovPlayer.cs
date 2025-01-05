using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.InputSystem;

public class MovPlayer : MonoBehaviour
{[Header("Move")]
    public float moveSpeed = 5.0f;
    private float speed = 0;
    public float estamina = 5;
    public float autoRotationSpeed = 10.0f;
    private Rigidbody rig;
    float horizontal;
    float vertical;
    Vector3 moveDirection;
    public GameObject cam;
    [Header("Animação")]
    public Animator ani;

    void Start()
    {
        rig = GetComponent<Rigidbody>();
        speed = moveSpeed;
    }

    private void Update()
    {
        // Pega as entradas do teclado
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        moveDirection = Vector3.zero;

        //verifica se pode se mover
       
            // Verifica se há movimento
            if ((horizontal != 0 || vertical != 0) || Input.GetMouseButton(1))
            {
                // Calcula a direção do movimento com base na câmera
                Vector3 cameraForward = cam.transform.forward;
                cameraForward.y = 0; // Ignora a rotação vertical da câmera
                cameraForward.Normalize();

                Vector3 cameraRight = cam.transform.right;
                cameraRight.y = 0;
                cameraRight.Normalize();

                moveDirection = (cameraForward * vertical + cameraRight * horizontal).normalized;

                // Faz o player olhar na direção do movimento
                Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, autoRotationSpeed * Time.deltaTime);


                // Move o player
                // transform.position += moveDirection * moveSpeed * Time.deltaTime;


                //Animação de andando
                
                ani.SetFloat("MoveVertical", Mathf.Clamp(Mathf.Abs(vertical) + Mathf.Abs(horizontal), -1, 1));
                 ani.SetBool("run",estamina > 0 && Input.GetKey(KeyCode.LeftShift));
                 if(Input.GetKey(KeyCode.LeftShift))
                 {
                    if(estamina>0) moveSpeed = speed * 1.5f;// + 50%
                    estamina -= Time.deltaTime;
                 }else{
                    moveSpeed = speed;
                    estamina+=Time.deltaTime;
                 }
            }
        }
        
    
    private void FixedUpdate()
    {
            float vy = rig.velocity.y;
            Vector3 mov = moveDirection * moveSpeed * Time.deltaTime;
            mov.y = vy;

            rig.velocity = mov;
            
        

    }

// '' void OnCollisionEnter(Collision collision)
//     {
//         if(collision.gameObject.layer == 6)
//         {
//             Destroy(gameObject);
//         }
//     }
 
    
}