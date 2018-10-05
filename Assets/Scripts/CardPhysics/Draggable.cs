using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Com.StinkyBrotherStudio.Orbu
{
    public class Draggable : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
    {
        public GameObject placeholder = null; // Literally holds the place of the card
        public Transform originalParent = null;
        public Transform placeholderParent = null;

        public void OnBeginDrag(PointerEventData eventData)
        {
            // TODO Stop the hop (when you grab non-center) here

            placeholder = new GameObject();
            placeholder.transform.SetParent(this.transform.parent); // return location

            // for placement in layout (index in hand)
            LayoutElement le = placeholder.AddComponent<LayoutElement>();
            le.preferredWidth = this.GetComponent<LayoutElement>().preferredWidth;
            le.preferredHeight = this.GetComponent<LayoutElement>().preferredHeight;
            le.flexibleHeight = 0;
            le.flexibleWidth = 0;

            placeholder.transform.SetSiblingIndex(this.transform.GetSiblingIndex());

            originalParent = this.transform.parent;
            placeholderParent = originalParent;
            this.transform.SetParent(this.transform.parent.parent);

            this.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }

        public void OnDrag(PointerEventData eventData)
        {
            this.transform.position = eventData.position;

            if (placeholder.transform.parent != placeholderParent)
                placeholder.transform.SetParent(placeholderParent);

            // Putting card in index where mouse is
            int newSiblingIndex = placeholderParent.childCount;
            for(int i = 0; i < placeholderParent.childCount; i++)
            {
                if(this.transform.position.x < placeholderParent.GetChild(i).position.x)
                {
                    newSiblingIndex = i;
                    
                    if(placeholder.transform.GetSiblingIndex() < newSiblingIndex)
                    {
                        newSiblingIndex--;
                    }

                    break;
                }
            }
            placeholder.transform.SetSiblingIndex(newSiblingIndex);
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            this.transform.SetParent(originalParent);
            Debug.Log("End Dragging");

            this.GetComponent<CanvasGroup>().blocksRaycasts = true;

            this.transform.SetSiblingIndex(placeholder.transform.GetSiblingIndex());
            Destroy(placeholder);
        }
    }
}
