using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LojaItemUI : MonoBehaviour
{
    public Image itemImage;
    public TextMeshProUGUI itemNameText;
    public TextMeshProUGUI itemCostText;
    public Image coinImage;
    public Button buyButton;

    private int itemPrice;

    public void SetItem(ItemLoja.ItemType itemType) {
        Sprite itemSprite = ItemLoja.GetSprite(itemType);
        string itemName = itemType.ToString();
        int price = ItemLoja.GetCost(itemType);
        // Define the sprite for the coin
        Sprite coinSprite = null;

        itemImage.sprite = itemSprite;
        itemNameText.text = itemName;
        itemCostText.text = price.ToString();
        coinImage.sprite = coinSprite;
        itemPrice = price;

        // Remove previous listeners to avoid multiple calls
        //buyButton.onClick.RemoveAllListeners();
        //buyButton.onClick.AddListener(BuyItem);
    }

    //private void BuyItem() {
        //if (GerirEconomia.Instance.CanAfford(itemPrice)) {
            //GerirEconomia.Instance.SpendMoney(itemPrice);
            //Debug.Log("Bought item: " + itemNameText.text);
        //} else {
            //Debug.Log("Not enough money to buy item: " + itemNameText.text);
        //}
    //}
}
