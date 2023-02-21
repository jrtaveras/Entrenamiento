//Autor:Jose Roberto Taveras
//Email:roberto.taveras@hotmail.com
//Fecha:2/21/2023 9:02:53 AM
//Licencia:Frederic Schad (Todos los derechos Reservados)

using System;
using System.Data.Entity.Spatial;

namespace Common.Controls
{
    public delegate void RaiseGeography(decimal latitude, decimal longitude);
    public partial class UserControlGeography : Wisej.Web.UserControl
    {
        public event RaiseGeography OnValueChanged;
        public const int SRID = 4326;
        private decimal latitude;
        private decimal longitude;
        public decimal Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                textBoxLatitude.Text = latitude.ToString();
            }
        }
        public decimal Longitude
        {
            get { return longitude; }
            set {
                longitude = value;
                textBoxLongitude.Text = longitude.ToString();
            }
        }

        private DbGeography _value;
        public DbGeography Value
        {
            get { return _value; }
            set
            {
                _value = value;
                setTextBox(_value);

            }
        }

        private void setTextBox(DbGeography value)
        {
            if (value.ToString() == null || !value.ToString().ToUpper().Contains("POINT")) 
            {
                textBoxLatitude.Text = "0";
                textBoxLongitude.Text = "0";
            }

            var start = value.ToString().IndexOf("(");
            var end = value.ToString().LastIndexOf(")");
            var result = value.ToString().Substring(start + 1, end - start - 1);
            string[] positions = result.Split(' ');
            if (positions.Length > 1)
            {

                if (textBoxLatitude.Text != positions[0])
                {
                    textBoxLatitude.Text = positions[0];

                }

                if (textBoxLongitude.Text != positions[1])
                {
                    textBoxLongitude.Text = positions[1];
                }
            }
        }

        public UserControlGeography()
        {
            
            InitializeComponent();
            Value = CreatePoint();
          
        }

        public  DbGeography CreatePoint()
        {

            string wkt = $"POINT({latitude} {longitude})";
            var result = DbGeography.PointFromText(wkt, SRID);
            

            return result;
        }

        private void textBoxLatitude_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        private void validate()
        {

            decimal x;
            decimal y;
            decimal.TryParse(textBoxLatitude.Text, out x) ;
            decimal.TryParse(textBoxLongitude.Text, out y);

            if (x > 15069 || x < -15069)
                x = 0;

            if (y > 90 || y < -90)
                y = 0;

            if (x != latitude || y != longitude)
            {
                latitude = x;
                longitude = y;
                Value = CreatePoint();
                OnValueChanged?.Invoke(latitude, longitude);
            }
        }

        private void textBoxLongitude_TextChanged(object sender, EventArgs e)
        {
            validate();
        }

        public override string ToString()
        {
            return Value.ToString();
        }

        private void textBoxLatitude_Leave(object sender, EventArgs e)
        {
           
        }

        private void textBoxLongitude_Leave(object sender, EventArgs e)
        {
            
        }
    }
}
