﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WrcaySalesInventorySystem.Class;

namespace WrcaySalesInventorySystem.custom
{
    /// <summary>
    /// Interaction logic for TransactionPanel.xaml
    /// </summary>
    public partial class TransactionPanel : UserControl, IUpdatePanels
    {
        public TransactionPanel()
        {
            InitializeComponent();
        }

        public void UpdateUI()
        {
            //throw new NotImplementedException();
        }
    }
}
