using UnityEngine;

public class Gravitation : MonoBehaviour
{
    public float gravityScaleUp = -1f; // Гравитация вверх (по умолчанию -1)
    public float gravityScaleDown = 1f; // Гравитация вниз (по умолчанию 1)
    

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>(); 
            player.GravityChange(true, gravityScaleUp);
            
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>(); 
            player.GravityChange(false, gravityScaleDown);
            
        }
    }
}