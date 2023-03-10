
namespace WisejWebApplication1.UserControls
{
    partial class UserControlGoogleMap
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Wisej Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TextBoxApiKey = new Wisej.Web.TextBox();
            this.label1 = new Wisej.Web.Label();
            this.ButtonLoadMap = new Wisej.Web.Button();
            this.TextBoxApiKeyService = new Wisej.Web.TextBox();
            this.label2 = new Wisej.Web.Label();
            this.ButtonOptimizeRoutes = new Wisej.Web.Button();
            this.label3 = new Wisej.Web.Label();
            this.ComboBoxMapServices = new Wisej.Web.ComboBox();
            this.PanelMapServices = new Wisej.Web.Panel();
            this.ComboBoxLocationTypes = new Wisej.Web.ComboBox();
            this.label4 = new Wisej.Web.Label();
            this.ButtonAddLocation = new Wisej.Web.Button();
            this.label5 = new Wisej.Web.Label();
            this.TextBoxLocation = new Wisej.Web.TextBox();
            this.PanelMapServices.SuspendLayout();
            this.SuspendLayout();
            // 
            // TextBoxApiKey
            // 
            this.TextBoxApiKey.AutoSize = false;
            this.TextBoxApiKey.Location = new System.Drawing.Point(240, 16);
            this.TextBoxApiKey.Name = "TextBoxApiKey";
            this.TextBoxApiKey.Size = new System.Drawing.Size(290, 44);
            this.TextBoxApiKey.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label1.Location = new System.Drawing.Point(24, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(210, 35);
            this.label1.TabIndex = 2;
            this.label1.Text = "Api Key GoogleMaps";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonLoadMap
            // 
            this.ButtonLoadMap.Location = new System.Drawing.Point(552, 16);
            this.ButtonLoadMap.Name = "ButtonLoadMap";
            this.ButtonLoadMap.Size = new System.Drawing.Size(309, 44);
            this.ButtonLoadMap.TabIndex = 3;
            this.ButtonLoadMap.Text = "Cargar Mapa";
            this.ButtonLoadMap.Click += new System.EventHandler(this.ButtonLoadMap_Click);
            // 
            // TextBoxApiKeyService
            // 
            this.TextBoxApiKeyService.AutoSize = false;
            this.TextBoxApiKeyService.Location = new System.Drawing.Point(216, 135);
            this.TextBoxApiKeyService.Name = "TextBoxApiKeyService";
            this.TextBoxApiKeyService.Size = new System.Drawing.Size(290, 44);
            this.TextBoxApiKeyService.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label2.Location = new System.Drawing.Point(6, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 35);
            this.label2.TabIndex = 11;
            this.label2.Text = "Servicio a utilizar";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ButtonOptimizeRoutes
            // 
            this.ButtonOptimizeRoutes.Location = new System.Drawing.Point(528, 135);
            this.ButtonOptimizeRoutes.Name = "ButtonOptimizeRoutes";
            this.ButtonOptimizeRoutes.Size = new System.Drawing.Size(306, 44);
            this.ButtonOptimizeRoutes.TabIndex = 12;
            this.ButtonOptimizeRoutes.Text = "Optimizar rutas";
            this.ButtonOptimizeRoutes.Click += new System.EventHandler(this.ButtonOptimizeRoutes_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(215, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(291, 35);
            this.label3.TabIndex = 13;
            this.label3.Text = "Api Key Servicio";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ComboBoxMapServices
            // 
            this.ComboBoxMapServices.AutoSize = false;
            this.ComboBoxMapServices.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.ComboBoxMapServices.Location = new System.Drawing.Point(6, 135);
            this.ComboBoxMapServices.Name = "ComboBoxMapServices";
            this.ComboBoxMapServices.Size = new System.Drawing.Size(189, 44);
            this.ComboBoxMapServices.TabIndex = 14;
            // 
            // PanelMapServices
            // 
            this.PanelMapServices.Controls.Add(this.ComboBoxLocationTypes);
            this.PanelMapServices.Controls.Add(this.label4);
            this.PanelMapServices.Controls.Add(this.ButtonAddLocation);
            this.PanelMapServices.Controls.Add(this.label5);
            this.PanelMapServices.Controls.Add(this.TextBoxLocation);
            this.PanelMapServices.Controls.Add(this.ComboBoxMapServices);
            this.PanelMapServices.Controls.Add(this.label3);
            this.PanelMapServices.Controls.Add(this.ButtonOptimizeRoutes);
            this.PanelMapServices.Controls.Add(this.label2);
            this.PanelMapServices.Controls.Add(this.TextBoxApiKeyService);
            this.PanelMapServices.Location = new System.Drawing.Point(24, 67);
            this.PanelMapServices.Name = "PanelMapServices";
            this.PanelMapServices.Size = new System.Drawing.Size(837, 192);
            this.PanelMapServices.TabIndex = 5;
            // 
            // ComboBoxLocationTypes
            // 
            this.ComboBoxLocationTypes.AutoSize = false;
            this.ComboBoxLocationTypes.DropDownStyle = Wisej.Web.ComboBoxStyle.DropDownList;
            this.ComboBoxLocationTypes.Location = new System.Drawing.Point(5, 48);
            this.ComboBoxLocationTypes.Name = "ComboBoxLocationTypes";
            this.ComboBoxLocationTypes.Size = new System.Drawing.Size(190, 44);
            this.ComboBoxLocationTypes.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label4.Location = new System.Drawing.Point(214, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(291, 35);
            this.label4.TabIndex = 18;
            this.label4.Text = "Localización";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ButtonAddLocation
            // 
            this.ButtonAddLocation.Location = new System.Drawing.Point(527, 48);
            this.ButtonAddLocation.Name = "ButtonAddLocation";
            this.ButtonAddLocation.Size = new System.Drawing.Size(306, 44);
            this.ButtonAddLocation.TabIndex = 17;
            this.ButtonAddLocation.Text = "Agregar marcador";
            this.ButtonAddLocation.Click += new System.EventHandler(this.ButtonAddLocation_Click);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("default", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Pixel);
            this.label5.Location = new System.Drawing.Point(5, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(210, 35);
            this.label5.TabIndex = 16;
            this.label5.Text = "Tipo de localización";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TextBoxLocation
            // 
            this.TextBoxLocation.AutoSize = false;
            this.TextBoxLocation.Location = new System.Drawing.Point(215, 48);
            this.TextBoxLocation.Name = "TextBoxLocation";
            this.TextBoxLocation.Size = new System.Drawing.Size(290, 44);
            this.TextBoxLocation.TabIndex = 15;
            // 
            // UserControlGoogleMap
            // 
            this.Controls.Add(this.PanelMapServices);
            this.Controls.Add(this.ButtonLoadMap);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.TextBoxApiKey);
            this.Name = "UserControlGoogleMap";
            this.Size = new System.Drawing.Size(876, 761);
            this.PanelMapServices.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private Wisej.Web.TextBox TextBoxApiKey;
        private Wisej.Web.Label label1;
        private Wisej.Web.Button ButtonLoadMap;
        private Wisej.Web.TextBox TextBoxApiKeyService;
        private Wisej.Web.Label label2;
        private Wisej.Web.Button ButtonOptimizeRoutes;
        private Wisej.Web.Label label3;
        private Wisej.Web.ComboBox ComboBoxMapServices;
        private Wisej.Web.Panel PanelMapServices;
        private Wisej.Web.ComboBox ComboBoxLocationTypes;
        private Wisej.Web.Label label4;
        private Wisej.Web.Button ButtonAddLocation;
        private Wisej.Web.Label label5;
        private Wisej.Web.TextBox TextBoxLocation;
    }
}
