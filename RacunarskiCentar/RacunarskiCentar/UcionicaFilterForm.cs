﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static RacunarskiCentar.UcionicaForm;

namespace RacunarskiCentar
{
    public partial class UcionicaFilterForm : Form
    {
        public UcionicaFilterForm()
        {
            InitializeComponent();
            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
            checkedListBox1.ItemCheck += CheckedListBox1_ItemCheck;
        }


        private void CheckedListBox1_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            ComboValue cv = (ComboValue)checkedListBox1.Items[e.Index];
            if (cv.Value.Equals(UcionicaAssets.windows) || cv.Value.Equals(UcionicaAssets.linux))
            {
                popuniSoftvere();

            }
        }


        private void popuniSoftvere()
        {
            checkedListBox2.Items.Clear();
            List<UcionicaAssets> listaSistema = new List<UcionicaAssets>();

            foreach (ComboValue cv in checkedListBox1.CheckedItems)
            {
                if (cv.Value.Equals(UcionicaAssets.linux) || (cv.Value.Equals(UcionicaAssets.windows)))
                {
                    listaSistema.Add(cv.Value);
                }
            }

            foreach (Software s in DataManger.softverOperativanSistemFiltiriranje(listaSistema))
            {
                checkedListBox2.Items.Add(s, false);
            }

        }

        private void buttonPotvrdi_Click(object sender, EventArgs e)
        {
            DataManger.UcionicaFilter.ID = textBoxID.Text;
            DataManger.UcionicaFilter.BrRadnihMesta = Convert.ToInt32(numericUpDownBrRadnihMesta.Value);
            DataManger.UcionicaFilter.Assets = getUcionicaAssets();
            DataManger.UcionicaFilter.InstalledSoftware = getInstalledSoft();
        }

        private HashSet<Software> getInstalledSoft()
        {
            throw new NotImplementedException();
        }

        private HashSet<UcionicaAssets> getUcionicaAssets()
        {
            HashSet<UcionicaAssets> rets = new HashSet<UcionicaAssets>();
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {

                ComboValue item = ((ComboValue)itemChecked);
                rets.Add(item.Value);

            }
            return rets;
        }
    }
}
