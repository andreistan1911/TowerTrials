using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VFXManager : MonoBehaviour
{
    public ParticleSystem FW;

    public void PlayFW(GameObject obj)
    {
        ParticleSystem vfxInstance = Instantiate(FW, obj.transform.position, obj.transform.rotation);

        vfxInstance.transform.parent = obj.transform;

        vfxInstance.Play();
        StartCoroutine(DestroyAfterParticlesFinished(vfxInstance));
    }

    private IEnumerator DestroyAfterParticlesFinished(ParticleSystem particleSystem)
    {
        // Wait until the ParticleSystem has stopped emitting or the object is destroyed
        float remainingDuration = particleSystem.main.duration + particleSystem.main.startLifetime.constant;
        float timer = 0;

        while (timer <= remainingDuration)
        {
            if (particleSystem == null)
                yield break;

            if (particleSystem.isPlaying)
                yield return null;

            timer += Time.deltaTime;
        }

        if (timer > remainingDuration)
            Destroy(particleSystem.gameObject);
    }

    public void PlayFN()
    {
    }

}
