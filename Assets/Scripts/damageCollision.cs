using UnityEngine;
using UnityEngine.UIElements;

public class DamageCollision : MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {

    }

<<<<<<< Updated upstream
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.GetComponent<BoxCollider2D>() != null)
        {
            Debug.Log("COLLISION");
            Destroy(gameObject);
        }
    }
=======
    private void OnCollisionEnter2D(Collision2D collision)
    {

    }



>>>>>>> Stashed changes
}

