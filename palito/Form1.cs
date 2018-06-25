using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace palito
{
    public partial class Formpalito : Form
    { private int quantpali, resto, palitos ,bandeira=0;
        public Formpalito()
        {
            InitializeComponent();
            maskedTextBoxpalitos.Visible = false;//inicia invisel 
            labelretirada.Visible = false;//inicia invisel 
            buttonretiradapali.Visible = false;//inicia invisel 
        }

        private void buttonretiradapali_Click(object sender, EventArgs e)
        {
            
            if (maskedTextBoxpalitos.Text == "")//para mostrar mensagem caso o usuário não digite nenhum numero
            {
                MessageBox.Show("voce deve preencher com numero de palitos");
            }
            else
            {
                palitos = Convert.ToInt16(maskedTextBoxpalitos.Text);
                if (palitos == 1 || palitos == 2 || palitos == 3)//caso seja diferente dos 3 numeros ele deve emitir a mensagem que está no else
                {
                    quantpali = quantpali - palitos;
                    if (palitos == 1)//serve para indentificar se ele perdeu ou não 
                    {
                        if (quantpali <= 0)//pra saber se o jogo ainda nao acabou
                        {
                            MessageBox.Show("voce perdeu","EASY");
                            bandeira = 2;//para entrar no if de fim de jogo que coloquei lá em baixo
                        }

                    }
                    if (palitos == 2)//para saber se ele não está tirando mais do que pode!!ex:só tem 1 palito e ele tirar 2
                    {
                        if (quantpali < 1)//caso seja maior ele emitira a mensagem logo a baixo
                        {
                            MessageBox.Show("voce não pode retirar esta quantidade de palitos","ATENÇÃO");
                            bandeira = 1;//para ele não retirar os palitos
                        }
                    }
                    if (palitos == 3)//para saber se ele não está tirando mais do que pode!!ex:só tem 1 palito e ele tirar 3
                    {
                        if (quantpali < 1)//caso seja maior ele emitira a mensagem logo a baixo
                        {
                            MessageBox.Show("voce não pode retirar esta quantidade de palitos", "ATENÇÃO");
                            bandeira = 1;//para ele não retirar os palitos
                        }
                    }
                    if (bandeira == 0)//serve para evitar o usuário não digitar nada diferente do que deveria!ex:só tem 1 palito e ele tirar 3
                    {
                        richTextBoxmostratudo.AppendText("eu retiro " + palitos.ToString() + " palitos (jogador)");
                        richTextBoxmostratudo.AppendText(Environment.NewLine);
                        richTextBoxmostratudo.AppendText("sobraram " + quantpali.ToString() + " palitos (jogador)");
                        richTextBoxmostratudo.AppendText(Environment.NewLine);
                    }
                    resto = quantpali % 4;//saber o resto 
                    if (bandeira == 0)//não permite retirar,caso o usuário tente retirar mais palitos do que o possivel 
                    {
                        if (resto == 0)//baseado no resto para sobrar sempre 1 no final retiro um valor pré estipulado
                        {
                            palitos = 3;
                        }
                        if (resto == 1)
                        {
                            palitos = 3;
                        }
                        if (resto == 2)
                        {
                            palitos = 1;
                        }
                        if (resto == 3)
                        {
                            palitos = 2;
                        }
                        quantpali = quantpali - palitos;//retira os palitos de acordo com o resto e mostra logo em seguida
                        if (quantpali >= 1)
                        {
                            richTextBoxmostratudo.AppendText("eu retiro " + palitos.ToString() + " palitos (pc)");
                            richTextBoxmostratudo.AppendText(Environment.NewLine);
                            richTextBoxmostratudo.AppendText("sobraram " + quantpali.ToString() + " palitos (pc)");
                            richTextBoxmostratudo.AppendText(Environment.NewLine);
                        }
                        else
                        {
                            MessageBox.Show("eu perdi(PC)", "IMPOSSIVEL");
                            bandeira = 2;//para entrar no if de fim de jogo que coloquei lá em baixo
                        }
                    }
                }
                else//mensagem caso seja diferente de 1,2,3 palitos
                {
                    MessageBox.Show("são permtidos retirar de 1 a 3 palitos");
                }
            }
            if (bandeira == 2)
            {           
                MessageBoxButtons botao = MessageBoxButtons.YesNo;
                DialogResult resultado = MessageBox.Show("voce deseja jogar novamente?", "fim de jogo", botao);
                if (resultado == DialogResult.Yes)
                {
                    maskedTextBoxpalitos.Visible = false;
                    labelretirada.Visible = false;
                    buttonretiradapali.Visible = false;
                    buttonjogar.Enabled = true;
                    numericUpDownquantpali.Enabled = true;
                    richTextBoxmostratudo.Text = "";
                    bandeira = 0;//para ele não entrar no mesmo if caso eu reinicie o jogo
                }
                else
                {                 
                    this.Close();//fecha a aplicação
                }
            }
        }
        private void buttonjogar_Click(object sender, EventArgs e)
        {
            buttonjogar.Enabled = false;//desliga para não poder clicar
            numericUpDownquantpali.Enabled = false;//desliga para não poder clicar
            maskedTextBoxpalitos.Visible = true;//torna visivel para poder jogar
            labelretirada.Visible = true;
            buttonretiradapali.Visible = true;
            quantpali = (int)numericUpDownquantpali.Value;
            resto = quantpali % 4;
            if (bandeira != 1)
            {
                if (resto == 0)
                {
                    palitos = 3;
                }
                if (resto == 1)
                {
                    palitos = 3;
                }
                if (resto == 2)
                {
                    palitos = 1;
                }
                if (resto == 3)
                {
                    palitos = 2;
                }
                quantpali = quantpali - palitos;
                richTextBoxmostratudo.AppendText("eu começo (pc)");
                richTextBoxmostratudo.AppendText(Environment.NewLine);
                richTextBoxmostratudo.AppendText("eu retiro " + palitos.ToString() + " palitos (pc)");
                richTextBoxmostratudo.AppendText(Environment.NewLine);
                richTextBoxmostratudo.AppendText("sobraram " + quantpali.ToString() + " palitos (pc)");
                richTextBoxmostratudo.AppendText(Environment.NewLine);
            }
        }
    }
}
