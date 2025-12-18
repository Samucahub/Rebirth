using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemLoja
{
     public enum ItemType {
        Eterguard,
        Enlatado,
        Agua
    }

    public static int GetCost(ItemType itemType) {
        switch (itemType) {
            default:
            case ItemType.Eterguard:    return 50;
            case ItemType.Enlatado:     return 5;
            case ItemType.Agua:         return 10;
        }
    }

    public static Sprite GetSprite(ItemType itemType) {
        switch (itemType) {
            default:
            case ItemType.Eterguard:    return GameAssets.i.Eterguard;
            case ItemType.Enlatado:     return GameAssets.i.Enlatado;
            case ItemType.Agua:         return GameAssets.i.Agua;
        }
    }
}
