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
        Item item = null;
        ItemPickup itemObject = null;

        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.position + mousePos, pickupDistance, itemLayer);
        if (hit.collider.GetComponent<ItemPickup>() != null)
        {
            itemObject = (ItemPickup)hit.collider.GetComponent<ItemPickup>();
            item = itemObject.item;
        }

        if (item != null)
        {
            if (player.inventory.AddItem(item))
                Destroy(itemObject.gameObject);
        }
    }
}
