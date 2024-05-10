using UnityEngine;

public class Mine : FieldObject
{
    AudioSource _audioSource;

    private void Awake()
    {
        _audioSource = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy();
            _audioSource.PlayOneShot(_audioSource.clip);
        }
    }
}
