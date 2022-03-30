using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random=System.Random;

public class SphereFall : MonoBehaviour
{
    static int delspheres = 0;
    static int grabspheres = 0;
    Rigidbody sphere;
    Random rnd;
    int sphereRnd = 0;
    Transform buttn;
    void Start()
    {
        sphere = GetComponent<Rigidbody>();
        buttn = GetComponent<Transform>();
        rnd = new Random();
        if(sphereRnd == 0){
            int value = rnd.Next(1, 5); 
            sphereRnd = value;
        }
        sphere.mass = 1000;
    }

    // Update is called once per frame
    void Update()
    {
        if(sphereRnd == 1){
            sphere.AddForce(0, 0, 300);
        }
        if(sphereRnd == 2){
            sphere.AddForce(0, 0, 100);
        }
        if(sphereRnd == 3){
            sphere.AddForce(100, 0, 100);
        }
        if(sphereRnd == 4){
            sphere.AddForce(500, 0, 100);
        }
    }
    void OnCollisionEnter(Collision col){
        if(col.gameObject.tag == "dellay"){
            Destroy(gameObject);
            delspheres += 1;
            if(delspheres == 6 && grabspheres < 6){
                print("отлетай в бан");
                
            }
        } 
        
    }
    void OnMouseDown(){
        Destroy(gameObject);
        grabspheres += 1;
        if(grabspheres == 6 && delspheres < 6){
            print("крутой");
            buttn.Translate(0, 0, 90);
        }
    }
}
