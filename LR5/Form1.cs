using LR5.BuilderBurger;
using LR5.DBCon;
using System;
using System.Linq;
using System.Windows.Forms;

namespace LR5
{
    public partial class Form1 : Form
    {
        Model1 model = new Model1();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            BurgerBuilder burgerBuilder = new BurgerBuilder();
            BurgerDirector burgerDirector = new BurgerDirector(burgerBuilder);

            if (comboBoxBurger.SelectedItem.ToString() == "Бургер стандартный")
                burgerDirector.BuildDefault();
            else
                burgerDirector.BuildWithBeacon();

            try
            {
                model.Burgers.Add(burgerBuilder.GetBurgers());
                model.SaveChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            LoadData();
        }

        private void LoadData()
        {
            comboBoxBurger.SelectedIndex = 0;
            dataGridView1.DataSource = model.Burgers.ToList();
        }
    }
}
