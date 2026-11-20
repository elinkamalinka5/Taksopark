using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Taksopark
{
    public partial class HistoryForm : Form
    {
        public HistoryForm(Car selectedCar)
        {
            InitializeComponent();

            this.Text = $"История: {selectedCar.Model}";

            int number = 1;
            foreach (var trip in selectedCar.Trip)
            {
                listHistory.Items.Add($"Поездка {number}: {trip:hh\\:mm\\:ss}");
                number++;
            }

            if (selectedCar.IsOnTrip)
            {
                TimeSpan currentTrip = DateTime.Now - selectedCar.TripStartTime;
                listHistory.Items.Add($"Текущая поездка: {currentTrip:hh\\:mm\\:ss} (ещё не завершена)");
            }

            if (selectedCar.Trip.Count == 0 && !selectedCar.IsOnTrip)
            {
                listHistory.Items.Add("Поездок еще не было.");
            }
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}

