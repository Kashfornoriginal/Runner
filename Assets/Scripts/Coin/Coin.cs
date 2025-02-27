using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private int _coinCost;
    private void OnTriggerEnter(Collider collider)
    {
        if(collider.TryGetComponent(out Player player))
        {
            player.AddCoin(_coinCost, false);
            Hide();
        }
    }
    private void Hide()
    {
        gameObject.SetActive(false);
    }
}
