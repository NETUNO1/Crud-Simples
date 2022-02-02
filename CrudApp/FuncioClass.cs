using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudApp
{
    public class FuncioClass
    {
        public int Id { get; set; }
        public string nome { get; set; }
        public string Area { get; set; }
        public int Idade { get; set; }
        public char sexo { get; set; }
        public float Salario { get; set; }
        public string Entrada { get; set; }

        public FuncioClass(int id, string nome, string area, int idade, char sexo, float salario, string entrada)
        {
            Id = id;
            this.nome = nome;
            Area = area;
            Idade = idade;
            this.sexo = sexo;
            Salario = salario;
            Entrada = entrada;
        }
    }
}
