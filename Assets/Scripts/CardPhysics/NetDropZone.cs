using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Com.StinkyBrotherStudio.Orbu
{
    public class NetDropZone : Photon.PunBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnDrop(PointerEventData eventData)
        {
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>(); //object being dragged
            if (d != null)
            {
                d.originalParent = this.transform;
            }
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>(); //object being dragged
            if (d != null)
            {
                d.placeholderParent = this.transform;
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (eventData.pointerDrag == null) { return; }
            Draggable d = eventData.pointerDrag.GetComponent<Draggable>(); //object being dragged
            if (d != null && d.placeholderParent == this.transform)
            {
                d.placeholderParent = d.originalParent;
            }
        }
    }
}