
using System;
using System.Linq;
using System.Threading;
using BusinessObjects;
using BusinessObjects.Repository;
using CommonUserControls;
using Ninject;
using Wisej.Web;
using WisejWebApplication1.Modules;

namespace WisejWebApplication1
{
    public partial class Window1 : Page
    {
        private readonly IKernel kernel;
        private MyContext _context;
        readonly HelperCalculo helperCalculo = new HelperCalculo();
        
        public Window1()
        {
            InitializeComponent();
            initControls();

            Bootstraper.InitBootstrapper(new CalcularModule());
            kernel = Bootstraper.Kernel();
        }

        private void initControls()
        {
            comboBoxOperacion.DataSource = Enum.GetValues(typeof(Calculos));

            _context = new MyContext("Entrenamiento");
            _context.LocalizationName = "es-DO";
            _context.TenantId = 1;
            _context.UserName = "Kiefer";
            var culture = new System.Globalization.CultureInfo(_context.LocalizationName);
            Thread.CurrentThread.CurrentCulture = culture;
            Thread.CurrentThread.CurrentUICulture = culture;
            Application.CurrentCulture = culture;
            Resource.Culture = culture;
            _context.ResourceManager = Resource.ResourceManager;
        }

        private void buttonCalcular_Click(object sender, EventArgs e)
        {
            try
            {
                ICalculo calculo = kernel.GetAll<ICalculo>().Where(c => c.Calculos == (Calculos)comboBoxOperacion.SelectedValue).FirstOrDefault();
                //numericUpDownResultado.Value = helperCalculo.Calcular((Calculos)comboBoxOperacion.SelectedValue, numericUpDownNumero1.Value, numericUpDownNumeric2.Value);

                calculo.Numero1 = numericUpDownNumero1.Value;
                calculo.Numero2 = numericUpDownNumeric2.Value;
                numericUpDownResultado.Value = calculo.Calcular();
            }
            catch (Exception ex)
            {

                MessageBox.Show($"Se produjo el siguinte error {ex.Message}" );
            }
            
        }

        private void numericUpDownNumero1_ValueChanged(object sender, EventArgs e)
        {
           
        }

        private void Window1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Page page = new Page();
            //page.Controls.Add();
            //page.Show();

            if(tabPageClientes.Controls.Count == 0)
            {
                var customers = new UserControlCustomers(_context);
                tabPageClientes.Controls.Add(customers);
            
                customers.Dock = DockStyle.Fill;
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Page page = new Page();
            //page.Controls.Add(new UserControlCustomerTypes(_context));
            //page.Show();

            if (tabPageTiposClientes.Controls.Count == 0)
            {
                var userControlCustomerTypes = new UserControlCustomerTypes(_context);
                tabPageTiposClientes.Controls.Add(userControlCustomerTypes);

                userControlCustomerTypes.Dock = DockStyle.Fill;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Page page = new Page();
            //page.Controls.Add(new UserControlInvoices(_context, details));
            //page.Show();

            if (tabPageFacturas.Controls.Count == 0)
            {
                UserControlInvoiceDetails details = new UserControlInvoiceDetails(_context);
                var userControlInvoices = new UserControlInvoices(_context, details);

                tabPageFacturas.Controls.Add(userControlInvoices);
                userControlInvoices.Dock = DockStyle.Fill;
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            //Page page = new Page();
            //page.Controls.Add(new UserControlProducts(_context));
            //page.Show();

            if (tabPageProductos.Controls.Count == 0)
            {
                var userControlProducts = new UserControlProducts(_context);
                tabPageProductos.Controls.Add(userControlProducts);

                userControlProducts.Dock = DockStyle.Fill;
            }

        }

    }
}
