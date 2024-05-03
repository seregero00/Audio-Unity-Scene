using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    public AudioClip[] footstepsGrass;
    public AudioClip[] footstepsStone;
    public AudioClip[] footstepsWood;

    public string material = "";
    void PlayFootstepSound()
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        audioSource.volume = Random.Range(0.9f, 1.0f);
        audioSource.pitch = Random.Range(0.8f, 1.2f);

        switch (material)
        {
            case "Grass":

                audioSource.PlayOneShot(footstepsGrass[Random.Range(0, footstepsGrass.Length)]);
                break;
            case "Stone":

                audioSource.PlayOneShot(footstepsStone[Random.Range(0, footstepsStone.Length)]);
                break;
            case "Wood":

                audioSource.PlayOneShot(footstepsWood[Random.Range(0, footstepsWood.Length)]);
                break;
            default:
                break;
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        material = collision.gameObject.tag;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (material != "Grass" && material != "Stone" && material != "Wood") return;

        PlayFootstepSound();
    }
}
