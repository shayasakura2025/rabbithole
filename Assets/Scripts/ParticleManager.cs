using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleManager : MonoBehaviour
{
    [SerializeField] GameObject EatingParticle;
    [SerializeField] GameObject EatenParticle;
    [SerializeField] GameObject CantEatParticle;
    
    public void playEating(Vector3 pos)
    {
        /*pos.z -= 10;
        GameObject psObject = Instantiate(EatingParticle, pos, Quaternion.identity);
        ParticleSystem ps = psObject.GetComponent<ParticleSystem>();
        if (ps)
            ps.Play();*/
            StartCoroutine(PlayParticleAndWait(pos, EatingParticle));
    }

    public void playEaten(Vector3 pos)
    {
        StartCoroutine(PlayParticleAndWait(pos, EatenParticle));
    }

    public void playCantEat(Vector3 pos)
    {
        StartCoroutine(PlayParticleAndWait(pos, CantEatParticle));
    }

    private IEnumerator PlayParticleAndWait(Vector3 pos, GameObject givenParticle)
    {
        // Instantiate the particle system at the given position
        pos.z -= 10;
        GameObject particleSystemObject = Instantiate(givenParticle, pos, Quaternion.identity);

        // Get the ParticleSystem component from the instantiated object
        ParticleSystem ps = particleSystemObject.GetComponent<ParticleSystem>();
        
        if (ps != null)
        {
            // Play the particle system
            ps.Play();

            // Wait until the particle system is no longer playing
            while (ps.isPlaying)
            {
                yield return null;  // Wait for the next frame
            }
        }

        // The particle system has finished playing, you can now perform other actions
        Debug.Log("Particle system finished playing!");
        
        // Optionally destroy the particle system object after it has finished
        Destroy(particleSystemObject);
    }
}
