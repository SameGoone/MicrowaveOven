using MicrowaveOven;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Курсовая_работа_ООП
{
    public partial class MainForm : Form
    {
        Microwave _microwave;
        Table _table;
        Controller _controller;
        public MainForm()
        {
            InitializeComponent();
            _microwave = new Microwave();
            _table = new Table();
            _controller = new Controller(_microwave, _table);
            PowerLabel.Text = _microwave.Power.ToString();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            _microwave.Working();
            _table.Working();
        }

        private void StartMicrowaveButton_Click(object sender, EventArgs e)
        {
            if (_microwave.GetProductCount() == 0)
            {
                MessageBox.Show("Микроволновая печь пуста");
                return;
            }
            else if(_microwave.IsWorking)
            {
                MessageBox.Show("Микроволновая печь уже запущена");
            }
            else
            {
                _microwave.IsWorking = true;
            }
        }

        private void StopMicrowaveButton_Click(object sender, EventArgs e)
        {
            if (!_microwave.IsWorking)
            {
                MessageBox.Show("Микроволновая печь уже отключена");
            }
            else
            {
                _microwave.IsWorking = false;
            }
        }
        private void UpdatePowerLabel()
        {
            PowerLabel.Text = _microwave.Power.ToString();
        }
        private void IncreasePowerButton_Click(object sender, EventArgs e)
        {
            _microwave.IncreasePower();
            UpdatePowerLabel();
        }

        private void ReducePowerButton_Click(object sender, EventArgs e)
        {
            _microwave.ReducePower();
            UpdatePowerLabel();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //_microwave.AddProduct(new Water(this, _controller));
        }

        private void button2_Click(object sender, EventArgs e)
        {
           // _microwave.AddProduct(new Soup(this, _controller));
        }
    }
}
