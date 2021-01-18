using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicController : MonoBehaviour
{

    [SerializeField] private AudioSource audio;

    void Start()
    {
        audio = GetComponent<AudioSource>();
        audio.loop = true;
        audio.Play();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
