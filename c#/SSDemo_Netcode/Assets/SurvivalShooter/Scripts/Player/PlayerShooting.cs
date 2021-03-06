using UnityEngine;
using UnitySampleAssets.CrossPlatformInput;

using Unity.Netcode;

public class PlayerShooting : NetworkBehaviour
{
    public int damagePerShot = 20;                  // The damage inflicted by each bullet.
    public float timeBetweenBullets = 0.15f;        // The time between each shot.
    public float range = 100f;                      // The distance the gun can fire.


    float timer;                                    // A timer to determine when to fire.
    Ray shootRay = new Ray();                       // A ray from the gun end forwards.
    RaycastHit shootHit;                            // A raycast hit to get information about what was hit.
    int shootableMask;                              // A layer mask so the raycast only hits things on the shootable layer.
    ParticleSystem gunParticles;                    // Reference to the particle system.
    LineRenderer gunLine;                           // Reference to the line renderer.
    AudioSource gunAudio;                           // Reference to the audio source.
    Light gunLight;                                 // Reference to the light component.
    public Light faceLight;								// Duh
    float effectsDisplayTime = 0.2f;                // The proportion of the timeBetweenBullets that the effects will display for.

    //network stuff
    private NetworkVariable<bool> networkPlayerShooting;

    private bool playerShooting;


    void Awake ()
    {
        // Create a layer mask for the Shootable layer.
        shootableMask = LayerMask.GetMask ("Shootable");

        // Set up the references.
        gunParticles = GetComponent<ParticleSystem> ();
        gunLine = GetComponent <LineRenderer> ();
        gunAudio = GetComponent<AudioSource> ();
        gunLight = GetComponent<Light> ();
        //faceLight = GetComponentInChildren<Light> ();
    }


    void Update ()
    {
        // Add the time since Update was last called to the timer.
        timer += Time.deltaTime;

#if !MOBILE_INPUT

        // if we are the owner, do the input processing
        if (IsOwner) 
        {
            // when we start clicking, we need to tell the server to start firing
            if (Input.GetButtonDown("Fire1"))
            {
                // do the shooting
                OwnerSetPotionServerRpc(true);
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                // stop the shooting
                OwnerSetPotionServerRpc(false);
            }
            // when we stop clicking, we need to tell the server to stop firing
            // the server needs to process our fire request and tell us that we can fire
            // all clients need to update this character to show the firing effects

            // If the Fire1 button is being press and it's time to fire...
            if (Input.GetButton ("Fire1") && timer >= timeBetweenBullets && Time.timeScale != 0)
            {
                // playerShooting = true;
                // ... shoot the gun.
                
                // Shoot ();

                //OwnerSetPotionServerRpc(playerShooting);
            }
            
        
    #else
            // If there is input on the shoot direction stick and it's time to fire...
            if ((CrossPlatformInputManager.GetAxisRaw("Mouse X") != 0 || CrossPlatformInputManager.GetAxisRaw("Mouse Y") != 0) && timer >= timeBetweenBullets)
            {
                // ... shoot the gun
                Shoot();
            }
    #endif
            //// If the timer has exceeded the proportion of timeBetweenBullets that the effects should be displayed for...
            //if(timer >= timeBetweenBullets * effectsDisplayTime)
            //{
            //    playerShooting = false;
            //    // ... disable the effects.
            //    DisableEffects ();
            //    OwnerSetPotionServerRpc(playerShooting);
            //}
        }

        // process shooting
        // do we need to play the fx for shooting?

        // if we're trying to shoot
        // - we can only shoot every .15 seconds
        // - the shoot effect needs to disappear .03 seconds after the shot

        if(networkPlayerShooting.Value )
        {
            Shoot();
        }
        //if       player request to shoot    &&  timer is greater than or equal to .03
        if (networkPlayerShooting.Value && timer >= /*.15*/timeBetweenBullets * /*.2*/effectsDisplayTime/*.15 * .2 = .03*/)
        {
            DisableEffects();
        }
        if (!networkPlayerShooting.Value)
        {
            DisableEffects();
        }
    }

    [ServerRpc(Delivery = RpcDelivery.Reliable)]
    void OwnerSetPotionServerRpc(bool newBool)
    {
        networkPlayerShooting.Value = newBool;
        Debug.Log("Player is now shooting? " + (newBool ? "Yes" : "No"));
    }


    public void DisableEffects ()
    {
        // Disable the line renderer and the light.
        gunLine.enabled = false;
        faceLight.enabled = false;
        gunLight.enabled = false;
    }


    void Shoot ()
    {
        if (timer >= timeBetweenBullets)
        {
            // Reset the timer.
            timer = 0f;

            // Play the gun shot audioclip.
            gunAudio.Play();

            // Enable the lights.
            gunLight.enabled = true;
            faceLight.enabled = true;

            // Stop the particles from playing if they were, then start the particles.
            gunParticles.Stop();
            gunParticles.Play();

            // Enable the line renderer and set it's first position to be the end of the gun.
            gunLine.enabled = true;
            gunLine.SetPosition(0, transform.position);

            // Set the shootRay so that it starts at the end of the gun and points forward from the barrel.
            shootRay.origin = transform.position;
            shootRay.direction = transform.forward;
            // Perform the raycast against gameobjects on the shootable layer and if it hits something...
            if(Physics.Raycast (shootRay, out shootHit, range, shootableMask))
            {
                // Try and find an EnemyHealth script on the gameobject hit.
                EnemyHealth enemyHealth = shootHit.collider.GetComponent <EnemyHealth> ();

                // If the EnemyHealth component exist...
                if(enemyHealth != null)
                {
                    // ... the enemy should take damage.
                    enemyHealth.TakeDamage (damagePerShot, shootHit.point);
                }

                // Set the second position of the line renderer to the point the raycast hit.
                gunLine.SetPosition (1, shootHit.point);
            }
            // If the raycast didn't hit anything on the shootable layer...
            else
            {
                // ... set the second position of the line renderer to the fullest extent of the gun's range.
                gunLine.SetPosition (1, shootRay.origin + shootRay.direction * range);
            }
        }

        


        
    }
}