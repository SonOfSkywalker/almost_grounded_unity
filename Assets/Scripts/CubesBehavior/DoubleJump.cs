using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    private float Height;


    void Awake(){

      // Add a Mesh Collider if there is not any
      if (gameObject.GetComponent<MeshCollider>() == null){
        gameObject.AddComponent<MeshCollider>();
      }
      // Set the mesh collider on trigger mode
      gameObject.GetComponent<MeshCollider>().convex = true;
      gameObject.GetComponent<MeshCollider>().isTrigger = true;

    }

    void OnTriggerEnter(Collider other) {
      // Add DoubleJump
      Character_Movement.Instance.AllowDoubleJump = true;

      // Play Sound
      PlaySound();

      // Die with particles
      Explode();
    }

    void Start(){
      Height = transform.position.y;
    }

    void Update(){

      Vector3 targetPosition = new Vector3(transform.position.x, Height + Mathf.PingPong(Time.time/1.3f, 1)/2f, transform.position.z);

      transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);

      // Rotation de durée infinie
      Quaternion Rot1 = Quaternion.AngleAxis(75*Time.deltaTime, transform.up);
      Quaternion Rot2 = Quaternion.AngleAxis(75*Time.deltaTime, transform.right);
      transform.rotation = Rot1 * Rot2* transform.rotation;
    }

    public ParticleSystem ParticleEffect; //assign prefab in editor or elsewhere
                                         //in code

    void Explode()
    {
       //Instantiate our one-off particle system
       ParticleSystem Death = Instantiate(ParticleEffect)
                                        as ParticleSystem;
       Death.transform.position = transform.position;
       //play it
       Death.loop = false;
       Death.Play();

       //destroy the particle system when its duration is up, right
       //it would play a second time.
       Destroy(Death.gameObject, Death.main.duration);
       //destroy our game object
       Destroy(gameObject);

    }

    void PlaySound(){

      AudioManager AM = FindObjectOfType<AudioManager>();
      if (AM != null){
        AM.Play("DoubleJump");
      }

    }


}
