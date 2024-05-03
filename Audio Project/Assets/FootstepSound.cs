using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootstepSound : MonoBehaviour
{

    public AudioClip[] footstepsGrass;
    public AudioClip[] footstepsStone;
    public AudioClip[] footstepsWood;

    public string material = "";


    private float timer = 0f;
    public  float delay = 0.2f;

    private bool moving;
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
    private void Update()
    {
        if (timer > delay)
        {
            StartCoroutine(CheckMoving());
            if (CheckGround() && moving) PlayFootstepSound();
            timer = 0f;

        }

        timer += Time.deltaTime;
    }

    private bool CheckGround()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down, out hit)) {
            material = hit.collider.gameObject.tag;
            return true;
        }
        return false;
    }

    private IEnumerator CheckMoving()
    {
        Vector3 startPos = transform.position;
        yield return new WaitForSeconds(1f);
        Vector3 finalPos = transform.position;

        if (startPos.x != finalPos.x || startPos.y != finalPos.y
            || startPos.z != finalPos.z)
            moving = true;
        else moving = false;

    }
}
