using UnityEngine;

[CreateAssetMenu(fileName = "CardData", menuName = "Scriptable Objects/CardData")]
public class CardData : ScriptableObject
{
    public int id;
    public Sprite avatar;
    public GameObject character;
    public int price;
}
