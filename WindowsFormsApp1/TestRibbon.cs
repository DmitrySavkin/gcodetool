using Autodesk.AutoCAD.Runtime;
using Autodesk.Windows;

namespace ConverterGUI
{
    class TestRibbon
    {
        //[CommandMethodAttribute("Teste")]
        [CommandMethod("testmyRibbon", CommandFlags.Transparent)]
        public void Testme()
        {
            // WICHTIG! für Ribbon verweise auf .NET DLL
            RibbonControl ribbon = ComponentManager.Ribbon;
            if (ribbon != null)
            {
                RibbonTab rtab = ribbon.FindTab("TESTME");
                if (rtab != null)
                {
                    ribbon.Tabs.Remove(rtab);
                }
                rtab = new RibbonTab();
                rtab.Title = "TEST  ME";
                rtab.Id = "Testing";
                //Add the Tab
                ribbon.Tabs.Add(rtab);
                addContent(rtab);
            }
        }

        static void addContent(RibbonTab rtab)
        {
            rtab.Panels.Add(AddOnePanel());
        }

        static RibbonPanel AddOnePanel()
        {
            RibbonButton rb;
            RibbonPanelSource rps = new RibbonPanelSource();
            rps.Title = "Test One";
            RibbonPanel rp = new RibbonPanel();
            rp.Source = rps;

            //Create a Command Item that the Dialog Launcher can use,
            // for this test it is just a place holder.
            RibbonButton rci = new RibbonButton();
            rci.Name = "TestCommand";

            //assign the Command Item to the DialgLauncher which auto-enables
            // the little button at the lower right of a Panel
            rps.DialogLauncher = rci;

            rb = new RibbonButton();
            rb.Name = "Test Button";
            rb.ShowText = true;
            rb.Text = "Test Button";
            //Add the Button to the Tab
            rps.Items.Add(rb);
            return rp;
        }
    }
}
