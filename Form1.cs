using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WeatherApp
{
    public partial class WeatherForm : Form
    {
        private WeatherDatabase _weather;

        public WeatherForm()
        {
            InitializeComponent();

            _weather = new WeatherDatabase();
            _weather.Initialize();

            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void textBox1_TextChanged(object sender, System.EventArgs e)
        {

            WeatherDataGrid.DataSource = _weather.Weathers.Where(u=>u.CityName.ToLower().Contains(textBox1.Text.ToLower())).ToList();

        }

        private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            switch (comboBox1.SelectedIndex) 
            { 
                case 0:
                    WeatherDataGrid.DataSource = _weather.Weathers.Where(u => u.MeasureUnit== MeasureUnits.Celsius).ToList();
                   break; 
                case 1:
                    WeatherDataGrid.DataSource = _weather.Weathers.Where(u => u.MeasureUnit == MeasureUnits.Fahrenheit).ToList();
                    break;
                case 2:
                    WeatherDataGrid.DataSource = _weather.Weathers.Where(u => u.MeasureUnit == MeasureUnits.Kelvin).ToList();
                    break;
                    
            }
            
        }

        private void button1_Click(object sender, System.EventArgs e)
        {
            textBox1.Text = "";
            WeatherDataGrid.DataSource = _weather.Weathers.ToList();
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers.Where(u => u.Temperature>0 ).ToList();
        }

        private void button3_Click(object sender, System.EventArgs e)
        {
            WeatherDataGrid.DataSource = _weather.Weathers.OrderBy(u => u.Temperature).ToList();
        }

    }
}