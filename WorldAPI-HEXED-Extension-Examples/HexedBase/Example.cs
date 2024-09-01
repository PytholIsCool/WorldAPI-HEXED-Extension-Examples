using HexedTools.HookUtils;
using System.Collections;
using UnityEngine;
using WorldAPI.ButtonAPI.QM.Carousel;
using WorldAPI.ButtonAPI.QM.Carousel.Items;
using WorldAPI.ButtonAPI;
using WorldAPI.ButtonAPI.Buttons;
using WorldAPI.ButtonAPI.Groups;

namespace WorldAPIExtentionExample
{
    internal class Example
    {
        public static VRCPage ExamplePage;
        public static ButtonGroup ExampleGroup;
        public static QMCGroup ExampleQMCGroup;
        public static Tab ExampleTab;

        public static IEnumerator WaitForQM() //Use the system IEnumerator
        {
            Logs.Log("Finding Quick Menu...");

            while (GameObject.Find("Canvas_QuickMenu(Clone)") == null) yield return null; //Waiting for the Quick Menu Before making new buttons
            yield return null;

            Logs.Log("Quick Menu Found!");

            CreateMenus();

            yield break;
        }
        private static void CreateMenus()
        {
            ExamplePage = new VRCPage("Example Page"); //Create a page to host your button groups and buttons
            ExampleGroup = new ButtonGroup(ExamplePage, "Example Button Group"); //Create a button group to host your buttons
            ExampleTab = new Tab(ExamplePage, "Example"); //Create a tab so you can reach your new page

            new VRCButton(ExampleGroup, "Example Button", "Example Tooltip", () =>
            {
                Logs.Log("This is a button!...");
            });
            new VRCToggle(ExampleGroup, "Example Toggle", (val) =>
            {
                if (val)
                {
                    Logs.Log("Example Toggle Value Set To: " + val.ToString());
                }
                else
                {
                    Logs.Log("Example Toggle Value Set To: " + val.ToString());
                }
            });

            //New additions to the API
            ExampleQMCGroup = new QMCGroup(ExamplePage, "Example Carousel Button Group");
            new QMCTitle(ExampleQMCGroup, "This is a title!", true);
            new QMCToggle(ExampleQMCGroup, "Example Carousel Toggle", (val) =>
            {
                if (val)
                {
                    Logs.Log("Example Carousel Toggle Value Set To: " + val.ToString());
                }
                else
                {
                    Logs.Log("Example Carousel Toggle Value Set To: " + val.ToString());
                }
            }, true, "Example Tooltip");
            var exampleSlider = new QMCSlider(ExampleQMCGroup, "Example Carousel Slider", "Example Tooltip", (val, slider) =>
            { 
                Logs.Log("Example Carousel Toggle Value Set To: " + val.ToString());
            }, 50f, 0f, 100f, false, "Units");
            var exampleSelector = new QMCSelector(ExampleQMCGroup, "Example Selector", "Example Tooltip");
            exampleSelector.AddSetting("Setting1", "Example Tooltip", () =>
            {
                Logs.Log("Setting1 has been applied!");
            });
            exampleSelector.AddSetting("Setting2", "Example Tooltip", () =>
            {
                Logs.Log("Setting2 has been applied!");
            });
            exampleSelector.AddSetting("Setting3", "Example Tooltip", () =>
            {
                Logs.Log("Setting3 has been applied!");
            });
            var exampleFunctionButtons = new QMCFuncButton(ExampleQMCGroup, "This is a button!", "This is a tooltip!", () =>
            {
                Logs.Log("Example listener");
            });
            exampleFunctionButtons.AddButton("Also a button!", "Also a tooltip!", () =>
            {
                Logs.Log("Example listener");
            });
            new QMCTitle(ExampleQMCGroup, "Still a title!", true);
        }
    }
}
