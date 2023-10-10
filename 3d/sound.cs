using System.Collections;
using UnityEngine;

public class sound : MonoBehaviour
{
    public AudioClip[] audioClipsSFX;
    public AudioSource audioSource;

    void Start()
    {
        StartCoroutine("DoCheck");
    }

    IEnumerator DoCheck()
    {
        for (; ; )
        {
            if (Input.GetKey("w") || Input.GetKey("s") || Input.GetKey("d") || Input.GetKey("a"))
            {
                audioSource.PlayOneShot(audioClipsSFX[Random.Range(0, 6)]);
            }                
            yield return new WaitForSeconds(.5f);            
        }
    }
}
