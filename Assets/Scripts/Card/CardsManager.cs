using UnityEngine;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private CardDatabase cardDatabase;
    [SerializeField] private List<CardController> cardControllers;

    private List<int> cards = new List<int> { 1,1,1,1,1,1,1};

    private void Awake()
    {
        for (int i =0;i<cards.Count;i++)
        {
            foreach (var a in cardDatabase.allCardData)
                if (cards[i] == a.id)
                {
                    cardControllers[i].CardData = a;
                }
        }
    }
}
