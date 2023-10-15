using UnityEngine;
public class Enemy : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            Debug.Log("Player near");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.name == "Player")
        {
            Debug.Log("Player exit");
        }
    }
}