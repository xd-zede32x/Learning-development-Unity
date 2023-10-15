using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            _gameManager.Items += 1;
            Destroy(transform.gameObject);
        }
    }
}