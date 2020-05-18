using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;
using System.Net;

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
            string cep = txtCEP.Text.Trim().Replace("-", "");

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);
                    //TODO - Validações
                    if (end != null)
                        lblResultado.Text = string.Format("Endereco: {0} - {1} - {2} - {3}", end.logradouro + (!string.IsNullOrEmpty(end.complemento) ? " - " + end.complemento : ""),
                            end.bairro, end.localidade, end.uf);
                    else
                        DisplayAlert("Erro", "Endereço não encontrado para o CEP informado: "+txtCEP.Text+".", "OK");
                }
                catch (WebException ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
                catch (Exception ex)
                {
                    DisplayAlert("ERRO CRÍTICO", ex.Message, "OK");
                }
            }
        }

        public bool isValidCEP(string cep)
        {
            bool valido = true;
            if (cep.Length != 8)
            {
                DisplayAlert("Erro", "CEP Inválido! CEP deve conter 8 caracteres.", "OK");
                valido = false;
            }
            int novoCEP = 0;

            if (!int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("Erro", "CEP Inválido! CEP deve conter apenas números.", "OK");
                valido = false;
            }

            return valido;
        }

    }
}
