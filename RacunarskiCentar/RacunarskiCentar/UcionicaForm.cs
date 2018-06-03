using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class UcionicaForm : Form
    {
        private Ucionica ucionica;
        public UcionicaForm(Ucionica ucionica)
        {
            this.ucionica = ucionica;
            InitializeComponent();
        }

        public Action GetAction()
        {
            Action action;
            if (ucionica == null)
            {
                ucionica = new Ucionica(textBoxID.Text, richTextBox1.Text, Convert.ToInt32(numericUpDown1.Value), getUcionicaAssets(), getInstalledSoft());

                action = new CreateAction(ucionica);

            }
            else
            {
                action = new EditAction(ucionica);
                ucionica.ID = textBoxID.Text;
                ucionica.Opis = richTextBox1.Text;
                ucionica.BrRadnihMesta = Convert.ToInt32(numericUpDown1.Value);

            }
            DataControllercs.addAction(action);
            return action;

        }

        private HashSet<UcionicaAssets> getUcionicaAssets()
        {
            HashSet<UcionicaAssets> rets = new HashSet<UcionicaAssets>();
            foreach (object itemChecked in checkedListBox1.CheckedItems)
            {
                
                ComboValue item = ((ComboValue) itemChecked);
                rets.Add(item.Value);

            }
            return rets;
        }

        private HashSet<Software> getInstalledSoft()
        {
            return new HashSet<Software>();
        }

        private class ComboValue
        {
            UcionicaAssets _value;
            public override string ToString()
            {
                return _value.getDisplayName();
            }
            public ComboValue(UcionicaAssets a)
            {
                this._value = a;
            }
            public UcionicaAssets Value
            {
                get => _value;
                set => _value = value;
            }
        }

        private void UcionicaForm_Load(object sender, EventArgs e)
        {

            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
        }

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {

        }
    }
}
