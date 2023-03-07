
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
            this.components = new System.ComponentModel.Container();
            this.googleMap = new Wisej.Web.Ext.GoogleMaps.GoogleMap();
            this.javaScript = new Wisej.Web.JavaScript(this.components);
            this.SuspendLayout();
            // 
            // googleMap
            // 
            this.googleMap.Location = new System.Drawing.Point(24, 102);
            this.googleMap.Name = "googleMap";
            this.googleMap.Size = new System.Drawing.Size(672, 491);
            this.googleMap.TabIndex = 0;
            this.googleMap.Text = "googleMap1";
            // 
            // UserControlGoogleMap
            // 
            this.Controls.Add(this.googleMap);
            this.Name = "UserControlGoogleMap";
            this.Size = new System.Drawing.Size(729, 635);
            this.ResumeLayout(false);

        }

        #endregion

        private Wisej.Web.Ext.GoogleMaps.GoogleMap googleMap;
        private Wisej.Web.JavaScript javaScript;
    }
}
