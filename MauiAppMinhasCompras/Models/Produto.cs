using System;
using System.Collections.Generic;
using System.Linq;
using SQLite;

namespace MauiAppMinhasCompras.Models
{
    public class Produto
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Descricao { get; set; }
        public double Quantidade { get; set; }
        public double Preco { get; set; }
        public string Categoria { get; set; } // Novo campo
        public double Total { get => Quantidade * Preco; }
    }

    public class Compra
    {
        public List<Produto> Produtos { get; set; }

        public Compra()
        {
            Produtos = new List<Produto>();
        }

        public void AdicionarProduto(Produto produto)
        {
            Produtos.Add(produto);
        }

        public void ExibirRelatorioPorCategoria()
        {
            var relatorio = Produtos.GroupBy(p => p.Categoria)
                .Select(g => new { Categoria = g.Key, TotalGasto = g.Sum(p => p.Total) });

            Console.WriteLine("--- Relatório de Compras por Categoria ---");
            foreach (var item in relatorio)
            {
                Console.WriteLine($"Categoria: {item.Categoria}, Total Gasto: R${item.TotalGasto}");
            }
        }
    }
}
