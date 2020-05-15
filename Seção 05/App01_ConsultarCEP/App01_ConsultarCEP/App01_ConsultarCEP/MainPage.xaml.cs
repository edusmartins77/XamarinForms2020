using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            btnCEP.Clicked += BuscarCEP;
        }

        public void BuscarCEP(object sender, EventArgs args)
        {
            //TODO - Logica do Programa
            string cep = txtCEP.Text.Trim().Replace("-", "");

            Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
            //TODO - Validações

            lblResultado.Text = string.Format("Endereco: {0} - {1} - {2} - {3}", end.logradouro+(!string.IsNullOrEmpty(end.complemento) ? " - "+ end.complemento : ""),
                end.bairro, end.localidade, end.uf);
        }

    }
}
