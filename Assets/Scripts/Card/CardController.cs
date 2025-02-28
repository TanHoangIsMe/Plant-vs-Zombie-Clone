using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardController : MonoBehaviour, IPointerClickHandler
{
    private Outline outline;
    private Image image;

    private CardData cardData;
    public CardData CardData { get { return cardData; } set { cardData = value; } }

    private void OnEnable()
    {
        outline = GetComponent<Outline>();

        image = transform.GetChild(0).GetComponent<Image>();
        if (image != null) image.sprite = cardData.avatar;

        CardSelectionManager.OnCardSelected += HandleCardSelected;
        CardSelectionManager.OnFinishSpawn += HandleResetSelected;
    }

    private void OnDisable()
    {
        CardSelectionManager.OnCardSelected -= HandleCardSelected;
        CardSelectionManager.OnFinishSpawn -= HandleResetSelected;
    }

    private void HandleCardSelected(CardController selectedCard)
    {
        if (selectedCard != this)
            outline.effectColor = Color.black;
    }

    private void HandleResetSelected()
    {
        outline.effectColor = Color.black;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        outline.effectColor = Color.yellow;

        CardSelectionManager.OnCardSelected?.Invoke(this);
    }
}
