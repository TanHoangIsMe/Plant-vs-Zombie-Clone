using System;
using UnityEngine;

public class CardSelectionManager : MonoBehaviour
{
    public static Action<CardController> OnCardSelected;
    public static Action OnFinishSpawn;
}
