using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RacunarskiCentar
{
    public partial class UcionicaForm : Form
    {

        //TO-DO: srediti regex za nazive ucionica
        Regex idRegex = new Regex("[a-zA-Z0-9]");
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

        public class ComboValue
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
            DialogResult = DialogResult.None;
            foreach (UcionicaAssets aset in Enum.GetValues(typeof(UcionicaAssets)))
            {
                checkedListBox1.Items.Add(new ComboValue(aset), false);
            }
        }
        
        private void textBoxID_Validated(object sender, EventArgs e)
        {
            if (!idRegex.IsMatch(textBoxID.Text)) 
            {
                labelID.ForeColor = Color.Red;
            }
            else
            {
                // TO-DO: proveriti da li vec postoji id u bazi
                labelID.ForeColor = Color.Black;

            }
        }

        private void numericUpDown1_Validated(object sender, EventArgs e)
        {
            if(numericUpDown1.Value <= 0)
            {
                labelBrMesta.ForeColor = Color.Red;
            }
            else
            {
                labelBrMesta.ForeColor = Color.Black;
            }

        }

        private void buttonSacuvaj_Click(object sender, EventArgs e)
        {
            //TO-DO: dugme sacuvaj 
            //TO-DO: u msg boxu dopisati format id ucionice
            string poruka = "";
            if (numericUpDown1.Value <= 0 || numericUpDown1.Value.Equals(""))
            {
                poruka += "Broj mesta u ucionici mora biti veci od nula. \n";
            }
            if (textBoxID.Text.Length == 0)
            {
                poruka += "Morate uneti ID ucionice.";
            }
            if (poruka.Length > 0)
            {
                DialogResult = DialogResult.None;
                MessageBox.Show(poruka, "Upozorenje", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            }


        }

        private void checkedListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
