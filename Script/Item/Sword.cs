using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    private Rigidbody2D entity;     //获得本体刚体信息
    // Start is called before the first frame update
    void Start()
    {
        entity = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Invoke("Jump", 1);
    }


    private void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.CompareTag("Player")){
            Invoke("Destorys",0.1f);
        }    
    }

    void Destorys(){
        Destroy(this.gameObject);
    }

    void Jump(){
        Vector2 jumpVel = entity.velocity.y > 0 ? new Vector2(0, 1) : new Vector2(0, -1);
        entity.velocity = Vector2.up * jumpVel;
    }
}
