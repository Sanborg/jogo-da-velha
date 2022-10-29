using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace jogo_da_velha
{
    public partial class MainWindow : Window
    {
        SolidColorBrush corDaVitoria = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
        SolidColorBrush corDaVelha = new SolidColorBrush(Color.FromArgb(255, 255, 255, 0));
        SolidColorBrush corDaDerrota = new SolidColorBrush(Color.FromArgb(255, 255, 0, 0));
        SolidColorBrush corDeInicioDosBotoes = new SolidColorBrush(Color.FromArgb(255, 23, 42, 58));

        List<Image> imagensExibidas = new List<Image>();

        bool btnA1Pressionado = false;
        bool btnA2Pressionado = false;
        bool btnA3Pressionado = false;
        bool btnB1Pressionado = false;
        bool btnB2Pressionado = false;
        bool btnB3Pressionado = false;
        bool btnC1Pressionado = false;
        bool btnC2Pressionado = false;
        bool btnC3Pressionado = false;

        int numeroDeJogadas = 0;
        string vencedor = "";
        string jogadorDaVez = "Jogador";
        int qtdVitoriasJogador = 0;
        int qtdVitoriasComputador = 0;
        int qtdVelhas = 0;
        Image ultimaJogada;
        Image penultimaJogada;
        bool jogadorComecou = true;

        public MainWindow()
        {
            InitializeComponent();
            txtResultadoVencedor.Text = "";
            btnNovoJogo.Visibility = Visibility.Hidden;

        }
        private void EscondeImagens()
        {
            List<Image> imagensX = new List<Image>(new Image[] { imgXA1, imgXA2, imgXA3, imgXB1, imgXB2, imgXB3, imgXC1, imgXC2, imgXC3 });
            List<Image> imagensO = new List<Image>(new Image[] { imgOA1, imgOA2, imgOA3, imgOB1, imgOB2, imgOB3, imgOC1, imgOC2, imgOC3 });
            foreach (Image imagem in imagensX)
            {
                imagem.Visibility = Visibility.Hidden;
            }
            foreach (Image imagem in imagensO)
            {
                imagem.Visibility = Visibility.Hidden;
            }
        }
        public async void Esperar()
        {
            await Task.Delay(3000);
            IniciarNovoJogo();
        }
        private void IniciarNovoJogo()
        {
            EscondeImagens();
            PintarBotoesDeNovoJogo();
            btnA1Pressionado = false;
            btnA2Pressionado = false;
            btnA3Pressionado = false;
            btnB1Pressionado = false;
            btnB2Pressionado = false;
            btnB3Pressionado = false;
            btnC1Pressionado = false;
            btnC2Pressionado = false;
            btnC3Pressionado = false;
            numeroDeJogadas = 0;
            vencedor = "";
            txtResultadoVencedor.Text = "";
            if (jogadorComecou == true)
            {
                jogadorDaVez = "Computador";
                jogadorComecou = false;
            }
            else
            {
                jogadorDaVez = "Jogador";
                jogadorComecou = true;
            }
        }
        private void SelecionarBtnA1(object sender, RoutedEventArgs e)
        {
            if (btnA1Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoA1, imgXA1);
                btnA1Pressionado = true;
            }
        }
        private void SelecionarBtnA2(object sender, RoutedEventArgs e)
        {
            if (btnA2Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoA2, imgXA2);
                btnA2Pressionado = true;
            }
        }
        private void SelecionarBtnA3(object sender, RoutedEventArgs e)
        {
            if (btnA3Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoA3, imgXA3);
                btnA3Pressionado = true;
            }
        }
        private void SelecionarBtnB1(object sender, RoutedEventArgs e)
        {
            if (btnB1Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoB1, imgXB1);
                btnB1Pressionado = true;
            }
        }
        private void SelecionarBtnB2(object sender, RoutedEventArgs e)
        {
            if (btnB2Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoB2, imgXB2);
                btnB2Pressionado = true;
            }
        }
        private void SelecionarBtnB3(object sender, RoutedEventArgs e)
        {
            if (btnB3Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoB3, imgXB3);
                btnB3Pressionado = true;
            }
        }
        private void SelecionarBtnC1(object sender, RoutedEventArgs e)
        {
            if (btnC1Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoC1, imgXC1);
                btnC1Pressionado = true;
            }
        }
        private void SelecionarBtnC2(object sender, RoutedEventArgs e)
        {
            if (btnC2Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoC2, imgXC2);
                btnC2Pressionado = true;
            }
        }
        private void SelecionarBtnC3(object sender, RoutedEventArgs e)
        {
            if (btnC3Pressionado == false)
            {
                ExibirimagemPosicaoCorrespondente(btnFundoC3, imgXC3);
                btnC3Pressionado = true;
            }
        }
        private void ExibirimagemPosicaoCorrespondente(Button posicaoSelecionada, Image imagemCorrespondente)
        { 
            if (jogadorDaVez == "Jogador" && vencedor == "" && numeroDeJogadas < 9)
            {
                imagemCorrespondente.Visibility = Visibility.Visible;
                imagensExibidas.Add(imagemCorrespondente);
                if(ultimaJogada == imgParametro || ultimaJogada == null)
                {

                }
                else
                {
                    penultimaJogada = ultimaJogada;
                }
                ultimaJogada = imagemCorrespondente;
                numeroDeJogadas++;
                VerificaVencedor();
                jogadorDaVez = "Computador";
            }
            JogadaDoComputador();
        }
        private void ExibirImagem(Image imagemCorrespondente)
        {
            imagemCorrespondente.Visibility = Visibility.Visible;
        }
        private void JogadaDoComputador()
        {
            
            if(jogadorDaVez == "Computador" && vencedor == "" && numeroDeJogadas < 9)
            {
                bool houveAtaque = JogadasOfensivas();
                if(houveAtaque == false)
                {
                    bool houveDefesa = JogadasDefensivas();
                    if (houveAtaque == false && houveDefesa == false)
                    {
                       JogadasDeConducao();
                    }
                }
                numeroDeJogadas++;
                VerificaVencedor();
            }

        }
        private bool JogadasOfensivas()
        {
            bool jogadaEfetuada = false;

            Image imagemPosicaoCentralX = imgXB2;
            Image imagemPosicaoCentralO = imgOB2;

            List<Image> imagensLinha1X = new List<Image>(new Image[] { imgXA1, imgXB1, imgXC1 });
            List<Image> imagensLinha1O = new List<Image>(new Image[] { imgOA1, imgOB1, imgOC1 });
            List<Image> imagensLinha2X = new List<Image>(new Image[] { imgXA2, imgXB2, imgXC2 });
            List<Image> imagensLinha2O = new List<Image>(new Image[] { imgOA2, imgOB2, imgOC2 });
            List<Image> imagensLinha3X = new List<Image>(new Image[] { imgXA3, imgXB3, imgXC3 });
            List<Image> imagensLinha3O = new List<Image>(new Image[] { imgOA3, imgOB3, imgOC3 });

            List<Image> imagensColunaAX = new List<Image>(new Image[] { imgXA1, imgXA2, imgXA3 });
            List<Image> imagensColunaAO = new List<Image>(new Image[] { imgOA1, imgOA2, imgOA3 });
            List<Image> imagensColunaBX = new List<Image>(new Image[] { imgXB1, imgXB2, imgXB3 });
            List<Image> imagensColunaBO = new List<Image>(new Image[] { imgOB1, imgOB2, imgOB3 });
            List<Image> imagensColunaCX = new List<Image>(new Image[] { imgXC1, imgXC2, imgXC3 });
            List<Image> imagensColunaCO = new List<Image>(new Image[] { imgOC1, imgOC2, imgOC3 });


            List<Image> imagensDiagonal1X = new List<Image>(new Image[] { imgXA1, imgXB2, imgXC3 });
            List<Image> imagensDiagonal1O = new List<Image>(new Image[] { imgOA1, imgOB2, imgOC3 });
            List<Image> imagensDiagonal2X = new List<Image>(new Image[] { imgXC1, imgXB2, imgXA3 });
            List<Image> imagensDiagonal2O = new List<Image>(new Image[] { imgOC1, imgOB2, imgOA3 });

            if (imagensLinha1O[0].Visibility == Visibility.Hidden && imagensLinha1X[0].Visibility == Visibility.Hidden && imagensLinha1O[1].Visibility == Visibility.Visible && imagensLinha1O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador") 
            {
                ExibirImagem(imagensLinha1O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha1O[1].Visibility == Visibility.Hidden && imagensLinha1X[1].Visibility == Visibility.Hidden && imagensLinha1O[0].Visibility == Visibility.Visible && imagensLinha1O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha1O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";               
            }
            else if (imagensLinha1O[2].Visibility == Visibility.Hidden && imagensLinha1X[2].Visibility == Visibility.Hidden && imagensLinha1O[0].Visibility == Visibility.Visible && imagensLinha1O[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha1O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";               
            }
            else if (imagensLinha2O[0].Visibility == Visibility.Hidden && imagensLinha2X[0].Visibility == Visibility.Hidden && imagensLinha2O[1].Visibility == Visibility.Visible && imagensLinha2O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha2O[1].Visibility == Visibility.Hidden && imagensLinha2X[1].Visibility == Visibility.Hidden && imagensLinha2O[0].Visibility == Visibility.Visible && imagensLinha2O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha2O[2].Visibility == Visibility.Hidden && imagensLinha2X[2].Visibility == Visibility.Hidden && imagensLinha2O[0].Visibility == Visibility.Visible && imagensLinha2O[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";               
            }
            else if (imagensLinha3O[0].Visibility == Visibility.Hidden && imagensLinha3X[0].Visibility == Visibility.Hidden && imagensLinha3O[1].Visibility == Visibility.Visible && imagensLinha3O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha3O[1].Visibility == Visibility.Hidden && imagensLinha3X[1].Visibility == Visibility.Hidden && imagensLinha3O[0].Visibility == Visibility.Visible && imagensLinha3O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha3O[2].Visibility == Visibility.Hidden && imagensLinha3X[2].Visibility == Visibility.Hidden && imagensLinha3O[0].Visibility == Visibility.Visible && imagensLinha3O[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }


            else if (imagensColunaAO[0].Visibility == Visibility.Hidden && imagensColunaAX[0].Visibility == Visibility.Hidden && imagensColunaAO[1].Visibility == Visibility.Visible && imagensColunaAO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaAO[1].Visibility == Visibility.Hidden && imagensColunaAX[1].Visibility == Visibility.Hidden && imagensColunaAO[0].Visibility == Visibility.Visible && imagensColunaAO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaAO[2].Visibility == Visibility.Hidden && imagensColunaAX[2].Visibility == Visibility.Hidden && imagensColunaAO[0].Visibility == Visibility.Visible && imagensColunaAO[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaBO[0].Visibility == Visibility.Hidden && imagensColunaBX[0].Visibility == Visibility.Hidden && imagensColunaBO[1].Visibility == Visibility.Visible && imagensColunaBO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaBO[1].Visibility == Visibility.Hidden && imagensColunaBX[1].Visibility == Visibility.Hidden && imagensColunaBO[0].Visibility == Visibility.Visible && imagensColunaBO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaBO[2].Visibility == Visibility.Hidden && imagensColunaBX[2].Visibility == Visibility.Hidden && imagensColunaBO[0].Visibility == Visibility.Visible && imagensColunaBO[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaBO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaCO[0].Visibility == Visibility.Hidden && imagensColunaCX[0].Visibility == Visibility.Hidden && imagensColunaCO[1].Visibility == Visibility.Visible && imagensColunaCO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaCO[1].Visibility == Visibility.Hidden && imagensColunaCX[1].Visibility == Visibility.Hidden && imagensColunaCO[0].Visibility == Visibility.Visible && imagensColunaCO[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensColunaCO[2].Visibility == Visibility.Hidden && imagensColunaCX[2].Visibility == Visibility.Hidden && imagensColunaCO[0].Visibility == Visibility.Visible && imagensColunaCO[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }


            else if (imagensDiagonal1O[0].Visibility == Visibility.Hidden && imagensDiagonal1X[0].Visibility == Visibility.Hidden && imagensDiagonal1O[1].Visibility == Visibility.Visible && imagensDiagonal1O[2].Visibility == Visibility.Visible &&  jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensDiagonal1O[1].Visibility == Visibility.Hidden && imagensDiagonal1X[1].Visibility == Visibility.Hidden && imagensDiagonal1O[0].Visibility == Visibility.Visible && imagensDiagonal1O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensDiagonal1O[2].Visibility == Visibility.Hidden && imagensDiagonal1X[2].Visibility == Visibility.Hidden && imagensDiagonal1O[0].Visibility == Visibility.Visible && imagensDiagonal1O[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensDiagonal2O[0].Visibility == Visibility.Hidden && imagensDiagonal2X[0].Visibility == Visibility.Hidden && imagensDiagonal2O[1].Visibility == Visibility.Visible && imagensDiagonal2O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";               
            }
            else if (imagensDiagonal2O[1].Visibility == Visibility.Hidden && imagensDiagonal2X[1].Visibility == Visibility.Hidden && imagensDiagonal2O[0].Visibility == Visibility.Visible && imagensDiagonal2O[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensDiagonal2O[2].Visibility == Visibility.Hidden && imagensDiagonal2X[2].Visibility == Visibility.Hidden && imagensDiagonal2O[0].Visibility == Visibility.Visible && imagensDiagonal2O[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal2O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            return jogadaEfetuada;
        }
        private bool JogadasDefensivas()
        {
            bool jogadaEfetuada = false;

            Image imagemPosicaoCentralX = imgXB2;
            Image imagemPosicaoCentralO = imgOB2;

            List<Image> imagensLinha1X = new List<Image>(new Image[] { imgXA1, imgXB1, imgXC1 });
            List<Image> imagensLinha1O = new List<Image>(new Image[] { imgOA1, imgOB1, imgOC1 });
            List<Image> imagensLinha2X = new List<Image>(new Image[] { imgXA2, imgXB2, imgXC2 });
            List<Image> imagensLinha2O = new List<Image>(new Image[] { imgOA2, imgOB2, imgOC2 });
            List<Image> imagensLinha3X = new List<Image>(new Image[] { imgXA3, imgXB3, imgXC3 });
            List<Image> imagensLinha3O = new List<Image>(new Image[] { imgOA3, imgOB3, imgOC3 });

            List<Image> imagensColunaAX = new List<Image>(new Image[] { imgXA1, imgXA2, imgXA3 });
            List<Image> imagensColunaAO = new List<Image>(new Image[] { imgOA1, imgOA2, imgOA3 });
            List<Image> imagensColunaBX = new List<Image>(new Image[] { imgXB1, imgXB2, imgXB3 });
            List<Image> imagensColunaBO = new List<Image>(new Image[] { imgOB1, imgOB2, imgOB3 });
            List<Image> imagensColunaCX = new List<Image>(new Image[] { imgXC1, imgXC2, imgXC3 });
            List<Image> imagensColunaCO = new List<Image>(new Image[] { imgOC1, imgOC2, imgOC3 });


            List<Image> imagensDiagonal1X = new List<Image>(new Image[] { imgXA1, imgXB2, imgXC3 });
            List<Image> imagensDiagonal1O = new List<Image>(new Image[] { imgOA1, imgOB2, imgOC3 });
            List<Image> imagensDiagonal2X = new List<Image>(new Image[] { imgXC1, imgXB2, imgXA3 });
            List<Image> imagensDiagonal2O = new List<Image>(new Image[] { imgOC1, imgOB2, imgOA3 });

            if (imagensLinha1X[0].Visibility == Visibility.Hidden && imagensLinha1O[0].Visibility == Visibility.Hidden && imagensLinha1X[1].Visibility == Visibility.Visible && imagensLinha1X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha1O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";                
            }
            else if (imagensLinha1X[1].Visibility == Visibility.Hidden && imagensLinha1O[1].Visibility == Visibility.Hidden && imagensLinha1X[0].Visibility == Visibility.Visible && imagensLinha1X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha1O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha1X[2].Visibility == Visibility.Hidden && imagensLinha1O[2].Visibility == Visibility.Hidden && imagensLinha1X[0].Visibility == Visibility.Visible && imagensLinha1X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha1O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha2X[0].Visibility == Visibility.Hidden && imagensLinha2O[0].Visibility == Visibility.Hidden && imagensLinha2X[1].Visibility == Visibility.Visible && imagensLinha2X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha2X[1].Visibility == Visibility.Hidden && imagensLinha2O[1].Visibility == Visibility.Hidden && imagensLinha2X[0].Visibility == Visibility.Visible && imagensLinha2X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha2X[2].Visibility == Visibility.Hidden && imagensLinha2O[2].Visibility == Visibility.Hidden && imagensLinha2X[0].Visibility == Visibility.Visible && imagensLinha2X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha3X[0].Visibility == Visibility.Hidden && imagensLinha3O[0].Visibility == Visibility.Hidden && imagensLinha3X[1].Visibility == Visibility.Visible && imagensLinha3X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha3X[1].Visibility == Visibility.Hidden && imagensLinha3O[1].Visibility == Visibility.Hidden && imagensLinha3X[0].Visibility == Visibility.Visible && imagensLinha3X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensLinha3X[2].Visibility == Visibility.Hidden && imagensLinha3O[2].Visibility == Visibility.Hidden && imagensLinha3X[0].Visibility == Visibility.Visible && imagensLinha3X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha3O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }


            else if (imagensColunaAX[0].Visibility == Visibility.Hidden && imagensColunaAO[0].Visibility == Visibility.Hidden && imagensColunaAX[1].Visibility == Visibility.Visible && imagensColunaAX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaAX[1].Visibility == Visibility.Hidden && imagensColunaAO[1].Visibility == Visibility.Hidden && imagensColunaAX[0].Visibility == Visibility.Visible && imagensColunaAX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaAX[2].Visibility == Visibility.Hidden && imagensColunaAO[2].Visibility == Visibility.Hidden && imagensColunaAX[0].Visibility == Visibility.Visible && imagensColunaAX[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaAO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaBX[0].Visibility == Visibility.Hidden && imagensColunaBO[0].Visibility == Visibility.Hidden && imagensColunaBX[1].Visibility == Visibility.Visible && imagensColunaBX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaBX[1].Visibility == Visibility.Hidden && imagensColunaBO[1].Visibility == Visibility.Hidden && imagensColunaBX[0].Visibility == Visibility.Visible && imagensColunaBX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaBX[2].Visibility == Visibility.Hidden && imagensColunaBO[2].Visibility == Visibility.Hidden && imagensColunaBX[0].Visibility == Visibility.Visible && imagensColunaBX[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaBO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaCX[0].Visibility == Visibility.Hidden && imagensColunaCO[0].Visibility == Visibility.Hidden && imagensColunaCX[1].Visibility == Visibility.Visible && imagensColunaCX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaCX[1].Visibility == Visibility.Hidden && imagensColunaCO[1].Visibility == Visibility.Hidden && imagensColunaCX[0].Visibility == Visibility.Visible && imagensColunaCX[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensColunaCX[2].Visibility == Visibility.Hidden && imagensColunaCO[2].Visibility == Visibility.Hidden && imagensColunaCX[0].Visibility == Visibility.Visible && imagensColunaCX[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensColunaCO[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }


            else if (imagensDiagonal1X[0].Visibility == Visibility.Hidden && imagensDiagonal1O[0].Visibility == Visibility.Hidden && imagensDiagonal1X[1].Visibility == Visibility.Visible && imagensDiagonal1X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensDiagonal1X[1].Visibility == Visibility.Hidden && imagensDiagonal1O[1].Visibility == Visibility.Hidden && imagensDiagonal1X[0].Visibility == Visibility.Visible && imagensDiagonal1X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensDiagonal1X[2].Visibility == Visibility.Hidden && imagensDiagonal1O[2].Visibility == Visibility.Hidden && imagensDiagonal1X[0].Visibility == Visibility.Visible && imagensDiagonal1X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal1O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensDiagonal2X[0].Visibility == Visibility.Hidden && imagensDiagonal2O[0].Visibility == Visibility.Hidden && imagensDiagonal2X[1].Visibility == Visibility.Visible && imagensDiagonal2X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal2O[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensDiagonal2X[1].Visibility == Visibility.Hidden && imagensDiagonal2O[1].Visibility == Visibility.Hidden && imagensDiagonal2X[0].Visibility == Visibility.Visible && imagensDiagonal2X[2].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensLinha2O[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            else if (imagensDiagonal2X[2].Visibility == Visibility.Hidden && imagensDiagonal2O[2].Visibility == Visibility.Hidden && imagensDiagonal2X[0].Visibility == Visibility.Visible && imagensDiagonal2X[1].Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensDiagonal2O[2]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            return jogadaEfetuada;
        }
        private void JogadasDeConducao()
        {
            bool jogadaEfetuada = false;
            bool jogadaXOXEfetuada = false;
            bool jogadaXOXHorizontal = false;
            bool jogadaXOXVertical = false;
            int parametroPosicaoUltimaJogada = 0;
            int parametroPosicaoPenultimaJogada = 0;

            Image imagemPosicaoCentralX = imgXB2;
            Image imagemPosicaoCentralO = imgOB2;

            List<Image> imagensExtremidadesX = new List<Image>(new Image[] { imgXA1, imgXC1, imgXC3, imgXA3 });
            List<Image> imagensExtremidadesO = new List<Image>(new Image[] { imgOA1, imgOC1, imgOC3, imgOA3 });

            List<Image> imagensLateraisX = new List<Image>(new Image[] { imgXB1, imgXC2, imgXB3, imgXA2 });
            List<Image> imagensLateraisO = new List<Image>(new Image[] { imgOB1, imgOC2, imgOB3, imgOA2 });

            /* 
             *   |   | 
             *   |   | 
             *   |   | 
             */
            if (imagemPosicaoCentralX.Visibility == Visibility.Hidden && imagemPosicaoCentralO.Visibility == Visibility.Hidden && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagemPosicaoCentralO);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            /*
             *   |   | 
             *   | O | 
             *   |   | 
             */
            else if (imagensExtremidadesX[0].Visibility == Visibility.Hidden && imagensExtremidadesO[0].Visibility == Visibility.Hidden && imagemPosicaoCentralX.Visibility == Visibility.Visible && imagemPosicaoCentralO.Visibility == Visibility.Visible && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensExtremidadesO[0]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";

            }
            /*
             *   |   | O
             *   | O | X
             *   | X | 
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                break;
                            case 1:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                break;
                        }
                        if (imagensExtremidadesO[1].Visibility == Visibility.Hidden && imagensExtremidadesX[1].Visibility == Visibility.Hidden && ultimaJogada == imagensLateraisX[parametroPosicaoUltimaJogada] && penultimaJogada == imagensLateraisX[parametroPosicaoPenultimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                        {
                            ExibirImagem(imagensExtremidadesO[1]);
                            jogadaEfetuada = true;
                            jogadorDaVez = "Jogador";
                        }
                    }
                }
            }
            /*
             * X |   |
             *   | O |
             *   |   | O
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            parametroPosicaoUltimaJogada = 2;
                            break;
                        case 1:
                            parametroPosicaoUltimaJogada = 3;
                            break;
                        case 2:
                            parametroPosicaoUltimaJogada = 0;
                            break;
                        case 3:
                            parametroPosicaoUltimaJogada = 1;
                            break;
                    }
                    if (imagensExtremidadesO[i].Visibility == Visibility.Hidden && imagensExtremidadesX[i].Visibility == Visibility.Hidden && ultimaJogada == imagensExtremidadesX[parametroPosicaoUltimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                    {
                        ExibirImagem(imagensExtremidadesO[i]);
                        jogadaEfetuada = true;
                        jogadorDaVez = "Jogador";
                        
                    }
                }
            }
            /*
             * X | O | X
             *   | O |
             *   |   | 
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for(int j = 0; j <= 1; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if(j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                break;
                            case 1:
                                if(j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                break;
                            case 2:
                                if(j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                break;
                            case 3:
                                if(j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                break;
                        }
                        if (imagensLateraisO[i].Visibility == Visibility.Hidden && imagensLateraisX[i].Visibility == Visibility.Hidden && ultimaJogada == imagensExtremidadesX[parametroPosicaoUltimaJogada] && penultimaJogada == imagensExtremidadesX[parametroPosicaoPenultimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                        {
                            ExibirImagem(imagensLateraisO[i]);
                            jogadaEfetuada = true;
                            jogadorDaVez = "Jogador";
                        }
                    }
                }
            }
            /*
             * X | O | 
             *   | O |
             *   |   | X
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for(int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                break;
                            case 1:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                break;
                        }
                        if (imagensLateraisO[0].Visibility == Visibility.Hidden && imagensLateraisX[0].Visibility == Visibility.Hidden && ultimaJogada == imagensExtremidadesX[parametroPosicaoUltimaJogada] && penultimaJogada == imagensExtremidadesX[parametroPosicaoPenultimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                        {
                            ExibirImagem(imagensLateraisO[i]);
                            jogadaEfetuada = true;
                            jogadorDaVez = "Jogador";
                        }
                    }
                }
            }
            /*
             *   |   | 
             * X | O | X
             *   |   | 
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for (int j = 0; j < 2; j++)
                {
                    for (int i = 0; i < 2; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                jogadaXOXHorizontal = true;
                                break;
                            case 1:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                jogadaXOXVertical = true;
                                break;
                        }
                        if (imagensLateraisO[i].Visibility == Visibility.Hidden && imagensLateraisX[i].Visibility == Visibility.Hidden && ultimaJogada == imagensLateraisX[parametroPosicaoUltimaJogada] && penultimaJogada == imagensLateraisX[parametroPosicaoPenultimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                        {
                            ExibirImagem(imagensLateraisO[i]);
                            jogadaEfetuada = true;
                            jogadaXOXEfetuada = true;
                            jogadorDaVez = "Jogador";
                        }
                    }
                }
            }
            /*
             *   | O | 
             * X | O | X
             *   | X | 
             */
            if (jogadaEfetuada == false && jogadaXOXEfetuada == true && jogadorDaVez == "Computador")
            {
                if (jogadaXOXHorizontal == true)
                {
                    if(imagensExtremidadesO[0].Visibility == Visibility.Hidden && imagensExtremidadesX[0].Visibility == Visibility.Hidden && imagensLateraisX[2].Visibility == Visibility.Hidden)
                    {
                        ExibirImagem(imagensExtremidadesO[0]);
                        jogadaEfetuada = true;
                        jogadorDaVez = "Jogador";
                    }
                }
                else if(jogadaXOXVertical == true)
                {
                    if (imagensExtremidadesO[0].Visibility == Visibility.Hidden && imagensLateraisX[0].Visibility == Visibility.Hidden && imagensLateraisX[3].Visibility == Visibility.Hidden)
                    {
                        ExibirImagem(imagensLateraisO[0]);
                        jogadaEfetuada = true;
                        jogadorDaVez = "Jogador";
                    }
                }
            }
            /*
             * X |   | 
             *   | O | X
             * O |   | 
             */
            if (jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                for (int j = 0; j <= 1; j++)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        switch (i)
                        {
                            case 0:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                break;
                            case 1:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 2;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 2;
                                }
                                break;
                            case 2:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 3;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 3;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                break;
                            case 3:
                                if (j == 0)
                                {
                                    parametroPosicaoUltimaJogada = 0;
                                    parametroPosicaoPenultimaJogada = 1;
                                }
                                else
                                {
                                    parametroPosicaoUltimaJogada = 1;
                                    parametroPosicaoPenultimaJogada = 0;
                                }
                                break;
                        }
                        if (imagensExtremidadesO[i].Visibility == Visibility.Hidden && imagensExtremidadesX[i].Visibility == Visibility.Hidden && ultimaJogada == imagensExtremidadesX[parametroPosicaoUltimaJogada] && penultimaJogada == imagensLateraisX[parametroPosicaoPenultimaJogada] && jogadaEfetuada == false && jogadorDaVez == "Computador")
                        {
                            ExibirImagem(imagensExtremidadesO[i]);
                            jogadaEfetuada = true;
                            jogadorDaVez = "Jogador";
                        }
                    }
                }
            }
            /*
             * O |   | O
             *   | X |
             *   |   | X
             */
            if (imagensExtremidadesO[1].Visibility == Visibility.Hidden && imagensExtremidadesX[1].Visibility == Visibility.Hidden && ultimaJogada == imagensExtremidadesX[2] && jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                ExibirImagem(imagensExtremidadesO[1]);
                jogadaEfetuada = true;
                jogadorDaVez = "Jogador";
                
            }
            /*
             * O | X | O
             *   | X |
             * X | O | X
             */
            if(jogadaEfetuada == false && jogadorDaVez == "Computador")
            {
                if(imagensExtremidadesO[0].Visibility == Visibility.Visible && imagensExtremidadesO[1].Visibility == Visibility.Visible && imagensLateraisO[2].Visibility == Visibility.Visible && imagensExtremidadesX[2].Visibility == Visibility.Visible && imagensExtremidadesX[3].Visibility == Visibility.Visible && imagensLateraisX[0].Visibility == Visibility.Visible && imagemPosicaoCentralO.Visibility == Visibility.Visible)
                {
                    ExibirImagem(imagensLateraisO[1]);
                    jogadaEfetuada = true;
                    jogadorDaVez = "Jogador";

                }
            }
        }
        private void VerificaVencedor()
        {
            if (imgXA1.Visibility == Visibility.Visible && imgXA2.Visibility == Visibility.Visible && imgXA3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoA2, btnFundoA3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXB1.Visibility == Visibility.Visible && imgXB2.Visibility == Visibility.Visible && imgXB3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoB1, btnFundoB2, btnFundoB3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXC1.Visibility == Visibility.Visible && imgXC2.Visibility == Visibility.Visible && imgXC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoC1, btnFundoC2, btnFundoC3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXA1.Visibility == Visibility.Visible && imgXB1.Visibility == Visibility.Visible && imgXC1.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoB1, btnFundoC1);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXA2.Visibility == Visibility.Visible && imgXB2.Visibility == Visibility.Visible && imgXC2.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA2, btnFundoB2, btnFundoC2);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXA3.Visibility == Visibility.Visible && imgXB3.Visibility == Visibility.Visible && imgXC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA3, btnFundoB3, btnFundoC3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXA1.Visibility == Visibility.Visible && imgXB2.Visibility == Visibility.Visible && imgXC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoB2, btnFundoC3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            else if (imgXC1.Visibility == Visibility.Visible && imgXB2.Visibility == Visibility.Visible && imgXA3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoC1, btnFundoB2, btnFundoA3);
                qtdVitoriasJogador++;
                txtPontuacaoJogador.Text = $"{qtdVitoriasJogador}";
                vencedor = "jogador";
            }
            if (imgOA1.Visibility == Visibility.Visible && imgOA2.Visibility == Visibility.Visible && imgOA3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoA2, btnFundoA3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOB1.Visibility == Visibility.Visible && imgOB2.Visibility == Visibility.Visible && imgOB3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoB1, btnFundoB2, btnFundoB3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOC1.Visibility == Visibility.Visible && imgOC2.Visibility == Visibility.Visible && imgOC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoC1, btnFundoC2, btnFundoC3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOA1.Visibility == Visibility.Visible && imgOB1.Visibility == Visibility.Visible && imgOC1.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoB1, btnFundoC1);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOA2.Visibility == Visibility.Visible && imgOB2.Visibility == Visibility.Visible && imgOC2.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA2, btnFundoB2, btnFundoC2);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOA3.Visibility == Visibility.Visible && imgOB3.Visibility == Visibility.Visible && imgOC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA3, btnFundoB3, btnFundoC3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOA1.Visibility == Visibility.Visible && imgOB2.Visibility == Visibility.Visible && imgOC3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoA1, btnFundoB2, btnFundoC3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else if (imgOC1.Visibility == Visibility.Visible && imgOB2.Visibility == Visibility.Visible && imgOA3.Visibility == Visibility.Visible)
            {
                PintarBotoesVencedor(btnFundoC1, btnFundoB2, btnFundoA3);
                qtdVitoriasComputador++;
                txtPontuacaoComputador.Text = $"{qtdVitoriasComputador}";
                vencedor = "Computador";
            }
            else
            {
                InformaVelha();
            }
            InformavencedorSeHouver();
        }
        private void InformaVelha()
        {
            if (numeroDeJogadas == 9)
            {
                PintarBotoesDeVelha();
                txtResultadoVencedor.Text = "Deu velha!";
                qtdVelhas++;
                txtPontuacaoVelha.Text = $"{qtdVelhas}";
                Esperar();
            }
        }
        private void InformavencedorSeHouver()
        {
            if (vencedor != "")
            {
                txtResultadoVencedor.Text = $"O {vencedor} venceu!";
                PintarBotoesPerdedor();
                Esperar();
            }
        }
        private void PintarBotoesVencedor(Button btnFundo1, Button btnFundo2, Button btnFundo3)
        {
            btnFundo1.Background = corDaVitoria;
            btnFundo2.Background = corDaVitoria;
            btnFundo3.Background = corDaVitoria;
        }
        private void PintarBotoesPerdedor()
        {
            List<Button> fundosCorrespondentes = new List<Button>(new Button[] { btnFundoA1, btnFundoA2, btnFundoA3, btnFundoB1, btnFundoB2, btnFundoB3, btnFundoC1, btnFundoC2, btnFundoC3 });
            List<Image> imagensX = new List<Image>(new Image[] { imgXA1, imgXA2, imgXA3, imgXB1, imgXB2, imgXB3, imgXC1, imgXC2, imgXC3 });
            List<Image> imagensO = new List<Image>(new Image[] { imgOA1, imgOA2, imgOA3, imgOB1, imgOB2, imgOB3, imgOC1, imgOC2, imgOC3 });
            if(vencedor == "Jogador")
            {
                for(int i = 0; i < 9; i++)
                {
                    if(imagensO[i].Visibility == Visibility.Visible)
                    {
                        fundosCorrespondentes[i].Background = corDaDerrota;
                    }
                }
            }
            else
            {
                for (int i = 0; i < 9; i++)
                {
                    if (imagensX[i].Visibility == Visibility.Visible)
                    {
                        fundosCorrespondentes[i].Background = corDaDerrota;
                    }
                }
            }
        }
        private void PintarBotoesDeVelha()
        {
            btnFundoA1.Background = corDaVelha;
            btnFundoA2.Background = corDaVelha;
            btnFundoA3.Background = corDaVelha;
            btnFundoB1.Background = corDaVelha;
            btnFundoB2.Background = corDaVelha;
            btnFundoB3.Background = corDaVelha;
            btnFundoC1.Background = corDaVelha;
            btnFundoC2.Background = corDaVelha;
            btnFundoC3.Background = corDaVelha;
        }
        private void PintarBotoesDeNovoJogo()
        {
            btnFundoA1.Background = corDeInicioDosBotoes;
            btnFundoA2.Background = corDeInicioDosBotoes;
            btnFundoA3.Background = corDeInicioDosBotoes;
            btnFundoB1.Background = corDeInicioDosBotoes;
            btnFundoB2.Background = corDeInicioDosBotoes;
            btnFundoB3.Background = corDeInicioDosBotoes;
            btnFundoC1.Background = corDeInicioDosBotoes;
            btnFundoC2.Background = corDeInicioDosBotoes;
            btnFundoC3.Background = corDeInicioDosBotoes;
        }
    }
}
