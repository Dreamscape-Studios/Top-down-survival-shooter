using UnityEngine;

public class Pickup : MonoBehaviour
{
    PlayerManager player;

    public LayerMask itemLayer;

    private void Start()
    {
        player = GetComponent<PlayerManager>();
    }

    public void CheckForItem(Vector3 mousePos, float pickupDistance)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, mousePos - transform.position, pickupDistance, itemLayer);
        if (hit.collider != null)
        {
            if (hit.collider.GetComponent<ItemPickup>() != null)
            {
                ItemPickup itemObject = (ItemPickup)hit.collider.GetComponent<ItemPickup>();
                Item item = itemObject.item;

                if (player.inventory.AddItem(item))
                    Destroy(itemObject.gameObject);
            }
        }
    }
}
