using System.Windows.Forms;

namespace CurrencyConverterApp
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private TextBox txtAmount;
        private TextBox txtTargetCurrency;
        private Label lblResult;
        private Label lblTitle; 
        private Button btnConvert;
        private Button btnFetchAllCurrencies;
        private ListView lvRates;
        private Label lblDescription; 

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.txtAmount = new TextBox();
            this.txtTargetCurrency = new TextBox();
            this.lblResult = new Label();
            this.lblTitle = new Label(); 
            this.btnConvert = new Button();
            this.btnFetchAllCurrencies = new Button();
            this.lvRates = new ListView();
            this.lblDescription = new Label();

            this.SuspendLayout();


            this.txtAmount.Location = new System.Drawing.Point(170, 50);
            this.txtAmount.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtAmount.Width = this.ClientSize.Width - 190;

            this.txtTargetCurrency.Location = new System.Drawing.Point(170, 80);
            this.txtTargetCurrency.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            this.txtTargetCurrency.Width = this.ClientSize.Width - 190;


            this.btnConvert.Text = "Przelicz";
            this.btnConvert.Location = new System.Drawing.Point(170, 110);
            this.btnConvert.Anchor = AnchorStyles.Top | AnchorStyles.Left;
            this.btnConvert.Click += new EventHandler(this.btnConvert_Click);


            this.btnFetchAllCurrencies.Text = "Pobierz wszystkie waluty";
            this.btnFetchAllCurrencies.Location = new System.Drawing.Point(100, 140);
            this.btnFetchAllCurrencies.Size = new System.Drawing.Size(200, 30);
            this.btnFetchAllCurrencies.Click += new EventHandler(this.BtnFetchAllCurrencies_Click);


            this.lblResult.Location = new System.Drawing.Point(40, 170);
            this.lblResult.Size = new System.Drawing.Size(300, 20);
            this.lblResult.Text = "Wynik:";


            this.lblTitle.Text = "KANTOR";
            this.lblTitle.Font = new Font("Arial", 18, FontStyle.Bold);
            this.lblTitle.Location = new System.Drawing.Point(txtAmount.Left - 20, txtAmount.Top - 50);
            this.lblTitle.Size = new System.Drawing.Size(txtAmount.Width + 40, 40); 
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;


            this.lblDescription.Text = "*Kurs wymiany walut w oparciu o 1 PLN*";
            this.lblDescription.Location = new System.Drawing.Point(40, 200);
            this.lblDescription.Size = new System.Drawing.Size(300, 20);
            this.lblDescription.AutoSize = true;


            this.lvRates.Location = new System.Drawing.Point(40, 230);
            this.lvRates.Size = new System.Drawing.Size(350, 260);
            this.lvRates.View = View.Details;
            this.lvRates.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;


            this.Controls.Add(new Label { Text = "Kwota *PLN*:", Location = new System.Drawing.Point(50, 50), AutoSize = true });
            this.Controls.Add(txtAmount);
            this.Controls.Add(new Label { Text = "Waluta docelowa:", Location = new System.Drawing.Point(50, 80), AutoSize = true });
            this.Controls.Add(txtTargetCurrency);
            this.Controls.Add(btnConvert);
            this.Controls.Add(btnFetchAllCurrencies);
            this.Controls.Add(lblResult);
            this.Controls.Add(lblTitle);
            this.Controls.Add(lblDescription);
            this.Controls.Add(lvRates);

            this.ClientSize = new System.Drawing.Size(420, 550);
            this.Text = "Kalkulator Walut";
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}
