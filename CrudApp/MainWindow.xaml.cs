using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
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
using MySql.Data.MySqlClient;


namespace CrudApp
{
    public partial class MainWindow : Window
    {
        string sql = "datasource=localhost;port=3306;username=root;password=12345678;database=funcionarios";
        public MainWindow()
        {
            InitializeComponent();
            Mostrar();
        }
        public void Mostrar()
        {
            MySqlConnection con = new MySqlConnection(sql);
            MySqlCommand cmd = new MySqlCommand("select * from funcionario", con);
            DataTable dt = new DataTable();
            con.Open();
            MySqlDataAdapter msqlda = new MySqlDataAdapter(cmd);
            msqlda.Fill(dt);
            datagrid.ItemsSource = dt.DefaultView;
        }
        public static MySqlConnection GetConnection()
        {
            string sql = "datasource=localhost;port=3306;username=root;password=12345678;database=funcionarios";
            MySqlConnection con = new MySqlConnection(sql);
            try
            {
                con.Open();
            }
            catch (MySqlException ex)
            {
                MessageBox.Show("error ao obter conexao com banco de dados" + ex);
            }
            return con;
        }

        public FuncioClass DadosFuncio()
        {
            //pegando os dados da tabela para salvar no banco de dados
            int id = 0;
            id = int.Parse(IdText.Text);
            string nome = "";
            nome = NomeText.Text;
            string area = "";
            area = AreaText.Text;
            int idade = 0;
            idade = int.Parse(IdadeText.Text);
            char sexo = ' ';
            sexo = char.Parse(SexoText.Text);
            float salario = 0;
            salario = float.Parse(SalarioText.Text);
            string entrada = "";
            entrada = EntradaText.Text;

                FuncioClass funcionario = new FuncioClass(id, nome, area, idade, sexo, salario, entrada);
                return funcionario;
        }
            public static void AddFuncio(FuncioClass funcio)
            {
                string msql = $"INSERT INTO funcionario VALUES(@Id, @nome, @Area, @Idade, @sexo, @Salario, @Entrada);";
                MySqlConnection con = GetConnection();
                MySqlCommand cmd = new MySqlCommand(msql, con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.Add("@Id", MySqlDbType.Int32).Value = funcio.Id;
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar).Value = funcio.nome;
                cmd.Parameters.Add("@Area", MySqlDbType.VarChar).Value = funcio.Area;
                cmd.Parameters.Add("@Idade", MySqlDbType.Int32).Value = funcio.Idade;
                cmd.Parameters.Add("@sexo", MySqlDbType.VarChar).Value = funcio.sexo;
                cmd.Parameters.Add("@Salario", MySqlDbType.Float).Value = funcio.Salario;
                cmd.Parameters.Add("@Entrada", MySqlDbType.Date).Value = funcio.Entrada;

                try
                {
                    cmd.ExecuteNonQuery();
                }
                catch (MySqlException ex)
                {
                    MessageBox.Show("ERRO!!! " + ex);
                    MessageBox.Show($"{ funcio.Id}, { funcio.Area}, { funcio.Idade}, { funcio.sexo}, { funcio.Salario}, { funcio.Entrada}");
                }
            }
            public void ButtonAplicar_Click(object sender, RoutedEventArgs e)
            {
                FuncioClass funcio = DadosFuncio();
                AddFuncio(funcio);
            }
            public void ButtonAtualzar_Click(object sender, RoutedEventArgs e)
            {
            Mostrar();
            }

    }
  }
