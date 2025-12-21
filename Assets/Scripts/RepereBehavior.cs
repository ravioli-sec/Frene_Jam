using UnityEngine;

public class RepereBehavior : MonoBehaviour
{
    [SerializeField] private BlockBehavior Block;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player" && General.isTeleporting)
        {
            Block.isHovered = true;
        }

        if (collision.tag != "Player")
        {
            Block.objectsColliding += 1;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player" && General.isTeleporting)
        {
            Block.isHovered = false;
        }

        if (collision.tag != "Player")
        {
            Block.objectsColliding -= 1;
        }
    }
}
