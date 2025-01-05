using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Combat : MonoBehaviour
{
    public bool hasMachado = false;
    public GameObject machadoObj;

    public Animator ani;
    private bool isAttake = false;
     



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        EquiparMachado();
        if (Input.GetMouseButtonDown(0))
        Atakke();
    }

    void Atakke(){
        ani.SetTrigger("attake");
        isAttake = true;
         Invoke("DesativeAttack", 1);
    }
void DesativeAttack(){
    isAttake = false;
}
    void EquiparMachado(){
        hasMachado = true;
        machadoObj.SetActive(true);
    }

    private void OnCollisionEnter(Collision other) {
        if(isAttake)
        {
            if(other.gameObject.tag == "monster")
            {
                Rigidbody rig = other.gameObject.GetComponent<Rigidbody>();
                if(rig!=null){
                Vector3 directionDnamege = transform.position - other.gameObject.transform.position;
                float force = Random.Range(100,500);
                rig.AddForce(transform.forward * force);
                Debug.Log("dano no monstro, mosnter has rig ");
                Destroy(other.gameObject, 2);
                 }

            }
        }
    }
}
