using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrippingApp.Runtime
{
    public class CameraApi
    {
        public static Cognex.InSight.Controls.Display.CvsInSightDisplay CvsInSightDisplay2 = new Cognex.InSight.Controls.Display.CvsInSightDisplay();
        public static void Initialize()
        {
            Cognex.InSight.CvsInSightSoftwareDevelopmentKit.Initialize();
            CvsInSightDisplay2.LoadStandardTheme();
            CvsInSightDisplay2.ConnectedChanged += CvsInSightDisplay2_ConnectedChanged;
            CvsInSightDisplay2.StateChanged += CvsInSightDisplay2_StateChanged;
            CvsInSightDisplay2.ConnectCompleted += CvsInSightDisplay2_ConnectCompleted;
            CvsInSightDisplay2.StatusInformationChanged += CvsInSightDisplay2_StatusInformationChanged;
            CvsInSightDisplay2.ResultsChanged += CvsInSightDisplay2_ResultsChanged;
            _ = CvsInSightDisplay2.GetBitmap();
        }

        private static void CvsInSightDisplay2_ResultsChanged(object sender, EventArgs e)
        {
            try
            {
                if (CvsInSightDisplay2.Results.Cells.GetCell(31, 1) != null)
                {
                    var a = CvsInSightDisplay2.Results.Cells.GetCell(31, 1).Text;
                    Console.WriteLine(a);
                }
            }
            catch (Exception)
            {


            }
        }

        private static void CvsInSightDisplay2_StatusInformationChanged(object sender, EventArgs e)
        {

        }

        private static void CvsInSightDisplay2_ConnectCompleted(object sender, Cognex.InSight.CvsConnectCompletedEventArgs e)
        {

        }

        private static void CvsInSightDisplay2_StateChanged(object sender, Cognex.InSight.Controls.Display.CvsDisplayStateChangedEventArgs e)
        {
        }

        private static void CvsInSightDisplay2_ConnectedChanged(object sender, EventArgs e)
        {
            
        }
    }
}
