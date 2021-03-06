﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryWindow : MonoBehaviour
{
    [SerializeField] private EquipmentSystem playerEquipment;

    //ui parenting related
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject inventoryPanel;

    //equipment slots
    [SerializeField] private GameObject equipmentSlot1;
    [SerializeField] private GameObject equipmentSlot2;
    [SerializeField] private GameObject equipmentSlot3;

    /// <summary>
    /// Called when an implant is clicked on from the implant menu
    /// </summary>
    /// <param name="implant">The implant in question</param>
    public void ImplantClicked(Button implant)
    {
        implant.transform.SetParent(canvas.transform,false);
        implant.gameObject.GetComponent<FollowMouse>().Following = true;
    }

    /// <summary>
    /// Called when an implant is released in the implant menu
    /// </summary>
    /// <param name="implant">The implant in question</param>
    public void ImplantReleased(Button implant)
    {
        //get position of the first slot
        Vector3[] firstSlotCorners = new Vector3[4];
        equipmentSlot1.GetComponent<RectTransform>().GetWorldCorners(firstSlotCorners);

        //get position of the second slot
        Vector3[] secondSlotCorners = new Vector3[4];
        equipmentSlot2.GetComponent<RectTransform>().GetWorldCorners(secondSlotCorners);

        //get position of the second slot
        Vector3[] thirdSlotCorners = new Vector3[4];
        equipmentSlot3.GetComponent<RectTransform>().GetWorldCorners(thirdSlotCorners);

        //get mouse pos
        Vector2 mousePos = Input.mousePosition;

        //check if implant is being released over the first slot
        if (mousePos.x >= firstSlotCorners[0].x && mousePos.x <= firstSlotCorners[3].x && mousePos.y >= firstSlotCorners[0].y && mousePos.y <= firstSlotCorners[1].y)
        {
            //previously equipped stuff goes back to the inventory
            if(equipmentSlot1.transform.childCount > 0)
            {
                foreach(Transform child in equipmentSlot1.transform)
                {
                    //move UI
                    child.SetParent(inventoryPanel.transform, false);
                    child.gameObject.GetComponent<FollowMouse>().Following = false;

                    //disable component
                    playerEquipment.DisableImplant(child.gameObject.name, 1);
                }
            }

            //attach the implant to the slot
            implant.transform.SetParent(equipmentSlot1.transform, false);
            implant.gameObject.GetComponent<FollowMouse>().Following = false;
            RectTransform rectTransform = implant.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(.5f, .5f);
            rectTransform.anchorMax = new Vector2(.5f, .5f);
            rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.anchoredPosition = Vector2.zero;

            //enable the new component
            playerEquipment.ActivateImplant(implant.gameObject.name, 1);
        }
        //check if implant is being released over the second slot
        else if(mousePos.x >= secondSlotCorners[0].x && mousePos.x <= secondSlotCorners[3].x && mousePos.y >= secondSlotCorners[0].y && mousePos.y <= secondSlotCorners[1].y)
        {
            //previously equipped stuff goes back to the inventory
            if (equipmentSlot2.transform.childCount > 0)
            {
                foreach (Transform child in equipmentSlot2.transform)
                {
                    //move UI
                    child.SetParent(inventoryPanel.transform, false);
                    child.gameObject.GetComponent<FollowMouse>().Following = false;

                    //diable component
                    playerEquipment.DisableImplant(child.gameObject.name, 2);
                }
            }

            //attach the implant to the slot
            implant.transform.SetParent(equipmentSlot2.transform, false);
            implant.gameObject.GetComponent<FollowMouse>().Following = false;
            RectTransform rectTransform = implant.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(.5f, .5f);
            rectTransform.anchorMax = new Vector2(.5f, .5f);
            rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.anchoredPosition = Vector2.zero;

            //enable the new component
            playerEquipment.ActivateImplant(implant.gameObject.name, 2);
        }
        //check if implant is being released over the third slot
        else if (mousePos.x >= thirdSlotCorners[0].x && mousePos.x <= thirdSlotCorners[3].x && mousePos.y >= thirdSlotCorners[0].y && mousePos.y <= thirdSlotCorners[1].y)
        {
            //previously equipped stuff goes back to the inventory
            if (equipmentSlot3.transform.childCount > 0)
            {
                foreach (Transform child in equipmentSlot3.transform)
                {
                    //move UI
                    child.SetParent(inventoryPanel.transform, false);
                    child.gameObject.GetComponent<FollowMouse>().Following = false;

                    //diable component
                    playerEquipment.DisableImplant(child.gameObject.name, 3);
                }
            }

            //attach the implant to the slot
            implant.transform.SetParent(equipmentSlot3.transform, false);
            implant.gameObject.GetComponent<FollowMouse>().Following = false;
            RectTransform rectTransform = implant.gameObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(.5f, .5f);
            rectTransform.anchorMax = new Vector2(.5f, .5f);
            rectTransform.pivot = new Vector2(.5f, .5f);
            rectTransform.anchoredPosition = Vector2.zero;

            //enable the new component
            playerEquipment.ActivateImplant(implant.gameObject.name, 3);
        }
        else 
        {
            implant.transform.SetParent(inventoryPanel.transform, false);
            implant.gameObject.GetComponent<FollowMouse>().Following = false;

            //disable component incase it was being removed
            playerEquipment.DisableImplant(implant.gameObject.name, 0);
        }
    }

    public void SendBackToInventory(int equipmentSlot)
    {
        switch (equipmentSlot)
        {            
            case 1:
                Transform implant1 = equipmentSlot1.transform.GetChild(0);

                implant1.transform.SetParent(inventoryPanel.transform, false);
                implant1.gameObject.GetComponent<FollowMouse>().Following = false;

                //disable component incase it was being removed
                //playerEquipment.DisableImplant(implant1.gameObject.name, 3);
                break;
            case 2:
                Transform implant2 = equipmentSlot2.transform.GetChild(0);

                implant2.transform.SetParent(inventoryPanel.transform, false);
                implant2.gameObject.GetComponent<FollowMouse>().Following = false;

                //disable component incase it was being removed
                //playerEquipment.DisableImplant(implant2.gameObject.name, 3);
                break;
            case 3:
                Transform implant3 = equipmentSlot3.transform.GetChild(0);

                implant3.transform.SetParent(inventoryPanel.transform, false);
                implant3.gameObject.GetComponent<FollowMouse>().Following = false;

                //disable component incase it was being removed
                //playerEquipment.DisableImplant(implant.gameObject.name, 3);
                break;
        }
    }
}
