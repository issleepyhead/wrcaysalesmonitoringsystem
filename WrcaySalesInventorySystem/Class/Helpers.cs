using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;

namespace WrcaySalesInventorySystem.Class
{
    public class Helpers
    {
        public static void CloseDialog(Button btn)
        {
            ButtonAutomationPeer btnPeer = (ButtonAutomationPeer) UIElementAutomationPeer.CreatePeerForElement(btn);
            if (btnPeer != null)
            {
                IInvokeProvider invoke = (IInvokeProvider)btnPeer.GetPattern(PatternInterface.Invoke);
                invoke?.Invoke();
            }
        }

        public static void PaginationConfig(int count,Pagination pagination, int max = 30)
        {
            double res = count / max;
            if (count % max == 0)
            {
                pagination.MaxPageCount = (int)res;
            } else
            {
                pagination.MaxPageCount = (int)res + 1;
            }
        }
    }
}
