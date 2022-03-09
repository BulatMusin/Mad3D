
  
using UnityEngine;

public class EnemyLook : MonoBehaviour
{
    private Transform player;
    public bool canLookDown;
    
    void Start()
    {
        player = FindObjectOfType<PlayerHealth>().transform;
    }
    
    void Update()
    {
        if (canLookDown)
        {
            transform.LookAt(player);
        }
        else
        {
            // looks at players x and z, but own y to have it believe
            // the player is always level with the enemy
            
            Vector3 modifiedPlayerPosition = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(modifiedPlayerPosition);
        }
    }
}