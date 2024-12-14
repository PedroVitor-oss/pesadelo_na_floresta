using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonstroControle : MonoBehaviour
{
    public Transform player;
    public bool followPlayer = false;
    public float speed;
    void Start(){
        player = GameObject.FindWithTag("Player").transform;
    }

    void Update(){
        //olhe para o player
         Vector3 moveDirection = (player.transform.position - transform.position).normalized;
            // moveDirection.y = 0;

            // Faz o player olhar na direção do inimigo
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10.0f * Time.deltaTime);

            //escutando plyaer
            if(Vector3.Distance(player.position,transform.position)<10)
            {
                followPlayer = true  ;

            }else{
                followPlayer = false;
            }

            if(followPlayer)
            {
                transform.Translate(moveDirection * speed * Time.deltaTime);
            }
    }
}
