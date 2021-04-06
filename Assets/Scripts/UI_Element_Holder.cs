using Assets.Data;
using Assets.Scripts.Data;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


namespace Assets.Scripts
{
    public class UI_Element_Holder : MonoBehaviour
    {
        // UI elements
        public List<GameObject> ui_texts;

        public List<GameObject> ui_image_colour_1;

        public List<GameObject> ui_image_colour_2;

        public List<GameObject> ui_image_colour_3;

        public List<GameObject> ui_image_colour_4;

        public List<GameObject> ui_image_colour_5;

        // Link to the Master Controller so I can re-render all ui
        MasterController masterController;

        // Start is called before the first frame update
        public void Start()
        {
            // Makes link to the controllerHabit
            // Not used at the moment
            masterController = GameObject.Find("Holder").GetComponent<MasterController>();

        }

        // It can be used to restart the colours on the UI
        public void SetColours(Theme currentTheme)
        {
            foreach (var ui in ui_texts)
            {
                ui.GetComponent<TextMeshProUGUI>().color = currentTheme.Color_1;
            }

            foreach (var ui in ui_image_colour_1)
            {
                ui.GetComponent<Image>().color = currentTheme.Color_1;
            }

            foreach (var ui in ui_image_colour_2)
            {
                ui.GetComponent<Image>().color = currentTheme.Color_2;
            }

            foreach (var ui in ui_image_colour_3)
            {
                ui.GetComponent<Image>().color = currentTheme.Color_3;
            }

            foreach (var ui in ui_image_colour_4)
            {
                ui.GetComponent<Image>().color = currentTheme.Color_4;
            }

            foreach (var ui in ui_image_colour_5)
            {
                ui.GetComponent<Image>().color = currentTheme.Color_5;
            }

        }
    }
}