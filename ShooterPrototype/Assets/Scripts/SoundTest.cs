using System.Collections.Generic;
using UnityEngine;

public class SoundTest : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private List<AudioClip> clip;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            audioSource.clip = clip[Random.Range(0, clip.Count)];
            audioSource.Play();
            //audioSource.PlayOneShot(clip);
        }
    }
}
