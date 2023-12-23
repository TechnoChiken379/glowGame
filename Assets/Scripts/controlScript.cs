using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controlScript : MonoBehaviour
{
    public static float controlDamage;
    public static float controlAttackSpeed;
    public static float controlGruntSpawnRate;
    // Start is called before the first frame update
    void Start()
    {
        controlDamage = 0.5f; //make damage lower for less damage, higher for more
        controlAttackSpeed = 2f; // make attack speed higher for slower attacks, lower for faster attacks
        controlGruntSpawnRate = 1f; //make higher to spawn less grunts, lower to spawn more
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
