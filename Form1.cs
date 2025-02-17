using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace CurrencyConverterApp
{
    public partial class Form1 : Form
    {
        private static readonly HttpClient _httpClient = new HttpClient();

        private static readonly Dictionary<string, string> currencyNames = new Dictionary<string, string>
        {
            { "PLN", "Polski złoty" },
            { "AED", "Dirham Zjednoczonych Emiratów Arabskich" },
            { "AFN", "Afgani afgańskie" },
            { "ALL", "Lek albański" },
            { "AMD", "Dram armeński" },
            { "ANG", "Gulden antylski" },
            { "AOA", "Kwanza angolska" },
            { "ARS", "Peso argentyńskie" },
            { "AUD", "Dolar australijski" },
            { "AWG", "Florin arubański" },
            { "AZN", "Manat azerbejdżański" },
            { "BAM", "Marka zamienna Bośni i Hercegowiny" },
            { "BBD", "Dolar barbadoski" },
            { "BDT", "Taka bengalska" },
            { "BGN", "Lew bułgarski" },
            { "BHD", "Dinar bahrajski" },
            { "BIF", "Frank burundyjski" },
            { "BMD", "Dolar bermudzki" },
            { "BND", "Dolar brunejski" },
            { "BOB", "Boliviano" },
            { "BRL", "Real brazylijski" },
            { "BSD", "Dolar bahamski" },
            { "BTN", "Ngultrum bhutański" },
            { "BWP", "Pula botswańska" },
            { "BYN", "Rubel białoruski" },
            { "BZD", "Dolar belizeński" },
            { "CAD", "Dolar kanadyjski" },
            { "CDF", "Frank kongijski" },
            { "CHF", "Frank szwajcarski" },
            { "CLP", "Peso chilijskie" },
            { "CNY", "Juan chiński" },
            { "COP", "Peso kolumbijskie" },
            { "CRC", "Colon kostarykański" },
            { "CUP", "Peso kubańskie" },
            { "CVE", "Escudo zielonoprzylądkowe" },
            { "CZK", "Korona czeska" },
            { "DJF", "Frank dżibutyjski" },
            { "DKK", "Korona duńska" },
            { "DOP", "Peso dominikańskie" },
            { "DZD", "Dinar algierski" },
            { "EGP", "Funt egipski" },
            { "ERN", "Nakfa erytrejska" },
            { "ETB", "Birr etiopski" },
            { "EUR", "Euro" },
            { "FJD", "Dolar fidżyjski" },
            { "FKP", "Funt falklandzki" },
            { "FOK", "Korona Wysp Owczych" },
            { "GBP", "Funt brytyjski" },
            { "GEL", "Lari gruzińskie" },
            { "GGP", "Funt Guernsey" },
            { "GHS", "Cedi ghańskie" },
            { "GIP", "Funt gibraltarski" },
            { "GMD", "Dalasi gambijskie" },
            { "GNF", "Frank gwinejski" },
            { "GTQ", "Quetzal gwatemalski" },
            { "GYD", "Dolar gujański" },
            { "HKD", "Dolar hongkoński" },
            { "HNL", "Lempira honduraska" },
            { "HRK", "Kuna chorwacka" },
            { "HTG", "Gourde haitański" },
            { "HUF", "Forint węgierski" },
            { "IDR", "Rupia indonezyjska" },
            { "ILS", "Szekel izraelski" },
            { "IMP", "Funt Wyspy Man" },
            { "INR", "Rupia indyjska" },
            { "IQD", "Dinar iracki" },
            { "IRR", "Rial irański" },
            { "ISK", "Korona islandzka" },
            { "JEP", "Funt Jersey" },
            { "JMD", "Dolar jamajski" },
            { "JOD", "Dinar jordański" },
            { "JPY", "Jen japoński" },
            { "KES", "Szyling kenijski" },
            { "KGS", "Som kirgiski" },
            { "KHR", "Riel kambodżański" },
            { "KID", "Dolar kiribatyjski" },
            { "KMF", "Frank komoryjski" },
            { "KRW", "Won południowokoreański" },
            { "KWD", "Dinar kuwejcki" },
            { "KYD", "Dolar kajmański" },
            { "KZT", "Tenge kazachskie" },
            { "LAK", "Kip laotański" },
            { "LBP", "Funt libański" },
            { "LKR", "Rupia lankijska" },
            { "LRD", "Dolar liberyjski" },
            { "LSL", "Loti lesotyjski" },
            { "LYD", "Dinar libijski" },
            { "MAD", "Dirham marokański" },
            { "MDL", "Lej mołdawski" },
            { "MGA", "Ariary malgaski" },
            { "MKD", "Denar macedoński" },
            { "MMK", "Kiat birmański" },
            { "MNT", "Tugrik mongolski" },
            { "MOP", "Pataka makao" },
            { "MRU", "Ouguiya mauretański" },
            { "MUR", "Rupia maurytyjska" },
            { "MVR", "Rupia malediwska" },
            { "MWK", "Kwacha malawijska" },
            { "MXN", "Peso meksykańskie" },
            { "MYR", "Ringgit malezyjski" },
            { "MZN", "Metical mozambicki" },
            { "NAD", "Dolar namibijski" },
            { "NGN", "Naira nigeryjska" },
            { "NIO", "Cordoba nikaraguańska" },
            { "NOK", "Korona norweska" },
            { "NPR", "Rupia nepalska" },
            { "NZD", "Dolar nowozelandzki" },
            { "OMR", "Rial omański" },
            { "PAB", "Balboa panamski" },
            { "PEN", "Sol peruwiański" },
            { "PGK", "Kina papuaska" },
            { "PHP", "Peso filipińskie" },
            { "PKR", "Rupia pakistańska" },
            { "PYG", "Guarani paragwajski" },
            { "QAR", "Rial katarski" },
            { "RON", "Lej rumuński" },
            { "RSD", "Dinar serbski" },
            { "RUB", "Rubel rosyjski" },
            { "RWF", "Frank rwandyjski" },
            { "SAR", "Rial saudyjski" },
            { "SBD", "Dolar Wysp Salomona" },
            { "SCR", "Rupia seszelska" },
            { "SDG", "Funt sudański" },
            { "SEK", "Korona szwedzka" },
            { "SGD", "Dolar singapurski" },
            { "SHP", "Funt Świętej Heleny" },
            { "SLE", "Leone sierraleońskie" },
            { "SOS", "Szyling somalijski" },
            { "SRD", "Dolar surinamski" },
            { "SSP", "Funt południowosudański" },
            { "STN", "Dobra Wysp Świętego Tomasza" },
            { "SYP", "Funt syryjski" },
            { "SZL", "Lilangeni suazi" },
            { "THB", "Baht tajski" },
            { "TJS", "Somoni tadżycki" },
            { "TMT", "Manat turkmeński" },
            { "TND", "Dinar tunezyjski" },
            { "TOP", "Pa'anga tongijska" },
            { "TRY", "Lira turecka" },
            { "TTD", "Dolar Trynidadu i Tobago" },
            { "TVD", "Dolar Tuvalu" },
            { "TWD", "Nowy dolar tajwański" },
            { "TZS", "Szyling tanzański" },
            { "UAH", "Hrywna ukraińska" },
            { "UGX", "Szyling ugandyjski" },
            { "USD", "Dolar amerykański" },
            { "UYU", "Peso urugwajskie" },
            { "UZS", "Sum uzbecki" },
            { "VES", "Boliwar wenezuelski" },
            { "VND", "Dong wietnamski" },
            { "VUV", "Vatu vanuackie" },
            { "WST", "Tala samoańska" },
            { "XAF", "Frank CFA (BEAC)" },
            { "XCD", "Dolar wschodniokaraibski" },
            { "XDR", "Specjalne prawa ciągnienia" },
            { "XOF", "Frank CFA (BCEAO)" },
            { "XPF", "Frank CFP" },
            { "YER", "Rial jemeński" },
            { "ZAR", "Rand południowoafrykański" },
            { "ZMW", "Kwacha zambijska" },
            { "ZWL", "Dolar Zimbabwe" }
        };

        public Form1()
        {
            InitializeComponent();
            InitializeListView();
        }

        private void InitializeListView()
        {
            lvRates.View = View.Details;
            lvRates.Columns.Add("Waluta", 80);
            lvRates.Columns.Add("Nazwa waluty", 200);
            lvRates.Columns.Add("Kurs", 100);
        }

        private async void BtnFetchAllCurrencies_Click(object sender, EventArgs e)
        {
            await FetchAllCurrencies();
        }

        private async Task FetchAllCurrencies()
        {
            string url = "https://api.exchangerate-api.com/v4/latest/PLN";
            try
            {
                string response = await _httpClient.GetStringAsync(url);
                JObject json = JObject.Parse(response);

                lvRates.Items.Clear();
                lvRates.Columns.Clear();

                lvRates.Columns.Add("Waluta", 80);
                lvRates.Columns.Add("Nazwa waluty", 200);
                lvRates.Columns.Add("Kurs", 100);

                lvRates.Items.Add(new ListViewItem(new[] { "PLN", "Polski Złoty", "1.00" }));

                var rates = json["rates"]?.ToObject<Dictionary<string, decimal>>();

                if (rates == null)
                {
                    MessageBox.Show("Błąd pobierania kursów. Spróbuj ponownie.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                foreach (var rate in rates.OrderBy(x => x.Key))
                {
                    string currencyCode = rate.Key;
                    string currencyName = currencyNames.ContainsKey(currencyCode) ? currencyNames[currencyCode] : "Nieznana waluta";
                    string currencyRate = rate.Value.ToString("F2");
                    lvRates.Items.Add(new ListViewItem(new[] { currencyCode, currencyName, currencyRate }));
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie można połączyć się z serwerem. Sprawdź połączenie internetowe.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            ConvertCurrency();
        }

        private void ConvertCurrency()
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Niepoprawna kwota!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string targetCurrency = txtTargetCurrency.Text.ToUpper();

            if (string.IsNullOrWhiteSpace(targetCurrency))
            {
                MessageBox.Show("Podaj kod waluty docelowej!", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            decimal baseRateValue = 1;
            string baseCurrencyName = "PLN";

            var targetRate = lvRates.Items.Cast<ListViewItem>().FirstOrDefault(item => item.SubItems[0].Text == targetCurrency);
            if (targetRate != null && decimal.TryParse(targetRate.SubItems[2].Text, out decimal targetRateValue))
            {
                decimal amountInPLN = amount * baseRateValue;
                decimal convertedAmount = amountInPLN * targetRateValue;

                lblResult.Text = $"{amount} {baseCurrencyName} = {amountInPLN:F2} PLN = {convertedAmount:F2} {targetCurrency}";
            }
            else
            {
                MessageBox.Show("Nie znaleziono kursu dla waluty docelowej.", "Błąd", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
