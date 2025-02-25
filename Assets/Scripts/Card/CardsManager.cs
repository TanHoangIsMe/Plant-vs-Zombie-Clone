using UnityEngine;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
    [SerializeField] private CardDatabase cardDatabase;
    [SerializeField] private List<CardController> cards;

    private List<int> cardList = new List<int> { 1,2,1,2,1,2,1};

    private void Awake()
    {
        for (int i =0; i<cardList.Count; i++)
        {
            foreach (var card in cardDatabase.allCardData)
                if (card.id == cardList[i])
                    cards[i].CardData = card;
        }
    }
}
