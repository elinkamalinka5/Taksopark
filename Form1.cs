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
    public partial class Form1 : Form
    {
        private List<Car> allCars = new List<Car>();
        private List<Car> carsOnTrip = new List<Car>();
        public Form1()
        {
            InitializeComponent();
            allCars.Add(new Car("Тойота"));
            allCars.Add(new Car("Киа"));
            allCars.Add(new Car("Форд"));
            allCars.Add(new Car("БМВ"));


            ShowCars();
        }

        private void ShowCars()
        {
            listCars.Items.Clear();
            foreach (var car in allCars)
            {
                listCars.Items.Add(car);
            }
        }

        private void ShowTrips()
        {
            listTrips.Items.Clear();
            foreach (var car in carsOnTrip)
            {
                TimeSpan currentTrip = DateTime.Now - car.TripStartTime;
                TimeSpan total = car.TotalTime + currentTrip;
                listTrips.Items.Add($"{car.Model} | Время в пути: {total:hh\\:mm\\:ss}");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (listCars.SelectedIndex == -1) return;

            Car car = allCars[listCars.SelectedIndex];

            if (car.IsOnTrip)
            {
                MessageBox.Show("Эта машина на выезде!");
                return;
            }

            car.IsOnTrip = true;
            car.TripStartTime = DateTime.Now;

            if (!carsOnTrip.Contains(car))
            {
                carsOnTrip.Add(car);
            }

            ShowCars();
            ShowTrips();
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            if (listCars.SelectedIndex == -1) return;

            Car car = allCars[listCars.SelectedIndex];

            if (!car.IsOnTrip)
            {
                MessageBox.Show("Эта машина в парке!");
                return;
            }

            TimeSpan time = DateTime.Now - car.TripStartTime;
            car.Trip.Add(time);
            car.IsOnTrip = false;
            carsOnTrip.Remove(car);

            ShowCars();
            ShowTrips();
        }

        private void btnItog_Click(object sender, EventArgs e)
        {
            if (listCars.SelectedIndex == -1)
            {
                MessageBox.Show("Выберите машину в первом списке!");
                return;
            }

            Car car = allCars[listCars.SelectedIndex];

            HistoryForm historyForm = new HistoryForm(car);
            historyForm.ShowDialog();
        }
    }
}
