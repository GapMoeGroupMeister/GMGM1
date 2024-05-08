using UnityEngine;

public class Mine : FieldObject
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy();
        }
    }
}
