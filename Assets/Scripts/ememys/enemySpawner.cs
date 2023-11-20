using UnityEngine;

public class SpawnClones : MonoBehaviour
{
    public GameObject grunt;  // The prefab to clone
    public Transform EnemySpawnPoint;      // The spawn point
    public int numberOfClones = 5;     // Number of clones to spawn

    void Start()
    {
        // Spawn the clones when the scene loads
        SpawnClonesAtSpawnPoint();
    }

    void SpawnClonesAtSpawnPoint()
    {
        for (int i = 0; i < numberOfClones; i++)
        {
            // Instantiate the prefab at the spawn point
            GameObject clone = Instantiate(grunt, EnemySpawnPoint.position, EnemySpawnPoint.rotation);

            // Assign a unique name to each clone
            clone.name = "Clone_" + i;

            // You can also attach other scripts or components to the clone if needed
            // clone.AddComponent<YourComponent>();

            // Additional customization or setup for each clone can be done here

            // Set the parent to keep the hierarchy clean
            clone.transform.SetParent(transform);
        }
    }
}
