using HandyControl.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Media;
using TextBox = HandyControl.Controls.TextBox;

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

        public static bool Check(TextBox textBox, TextBlock txtBlock, InputType type, string errortxt)
        {
            if (!ValidationCheck.ValidateInput(textBox.Text, type))
            {
                textBox.BorderBrush = Brushes.Red;
                txtBlock.Visibility = Visibility.Visible;
                txtBlock.Text = errortxt;
                return false;
            }
            else
            {
                textBox.BorderBrush = new BrushConverter().ConvertFromString("#FFE0E0E0") as Brush;
                txtBlock.Visibility = Visibility.Collapsed;
                txtBlock.Text = null;
            }
            return true;
        }
    }
}
