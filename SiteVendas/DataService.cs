using business.classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SiteVendas.Data;
using System;
using System.Threading.Tasks;

namespace SiteVendas
{
    public class DataService : IDataService
    {
        string[] arr = new string[50];
        string[] arr2 = new string[10];
        string[] arr3 = new string[50];
        string[] arr4 = new string[10];
        Random randNum = new Random();
        int loop = 500;

        public async Task InicializaDBAsync(IServiceProvider provider)
        {
            var contexto = provider.GetService<ApplicationDbContext>();

            await contexto.Database.MigrateAsync();

            if (await contexto.Set<Produto>().AnyAsync())
            {
                return;
            }

          await save(provider);
            
        }

        private async Task<string> save(IServiceProvider provider)
        {
            var contexto = provider.GetService<ApplicationDbContext>();

            arr[0] = "Paulo"; arr[10] = "Sandra"; arr[20] = "Sebastião"; arr[30] = "Thais"; arr[40] = "Adriana";
            arr[1] = "Jorge"; arr[11] = "Jaco"; arr[21] = "Lucas"; arr[31] = "Pamela"; arr[41] = "Adriano";
            arr[2] = "Maria"; arr[12] = "Rubens"; arr[22] = "Alice"; arr[32] = "Nayara"; arr[42] = "Alex";
            arr[3] = "Pedro"; arr[13] = "Marta"; arr[23] = "Aline"; arr[33] = "Oliver"; arr[43] = "Fred";
            arr[4] = "Sandro"; arr[14] = "Madalena"; arr[24] = "Zezé"; arr[34] = "Hugo"; arr[44] = "Tiago";
            arr[5] = "Gustavo"; arr[15] = "Judas"; arr[25] = "Romulo"; arr[35] = "Icaro"; arr[45] = "Neymar";
            arr[6] = "Henrique"; arr[16] = "Amanda"; arr[26] = "Geraldo"; arr[36] = "Bruno"; arr[46] = "Mariano";
            arr[7] = "Isaque"; arr[17] = "Erik"; arr[27] = "Denis"; arr[37] = "Vinicius"; arr[47] = "Fabricio";
            arr[8] = "Salomão"; arr[18] = "Leonardo"; arr[28] = "Gisele"; arr[38] = "Ramon"; arr[48] = "Felipe";
            arr[9] = "Camila"; arr[19] = "Simone"; arr[29] = "Bianca"; arr[39] = "Charles"; arr[49] = "Carlos";


            arr2[0] = "Silva Mendes";
            arr2[1] = "Oliveira Prado";
            arr2[2] = "Bitencourt Silva";
            arr2[3] = "Chavier dos Santos";
            arr2[4] = "Gomes Pereira";
            arr2[5] = "Vasconcelos";
            arr2[6] = "Magalhães";
            arr2[7] = "Santos";
            arr2[8] = "Menezes";
            arr2[9] = "Reimon";

            arr3[0] = "Geladeira";  arr3[10] = "Cadeira";       arr3[20] = "Tablet";     
            arr3[1] = "Microondas"; arr3[11] = "Freezer";       arr3[21] = "Notbook";  
            arr3[2] = "sofá";       arr3[12] = "Panela";        arr3[22] = "DVD";         
            arr3[3] = "tesoura";    arr3[13] = "Martelo";       arr3[23] = "escada";    
            arr3[4] = "caneta";     arr3[14] = "Tesoura";       arr3[24] = "Inchada";      
            arr3[5] = "Cd virgem";  arr3[15] = "Alicate";       arr3[25] = "Foice";     
            arr3[6] = "Impressora"; arr3[16] = "Vasoura";       arr3[26] = "Baralho";    
            arr3[7] = "Cama";       arr3[17] = "Tomada";        arr3[27] = "Iphone";    
            arr3[8] = "Mesa";       arr3[18] = "Churrasqueira"; arr3[28] = "Espelho"; 
            arr3[9] = "Fogão";      arr3[19] = "Celular";       arr3[29] = "Carregador";

            arr3[30] = "Pneu de moto";   arr3[40] = "Mochila";
            arr3[31] = "Fone de ouvido"; arr3[41] = "Pasta";
            arr3[32] = "Pen drive";      arr3[42] = "Computador";
            arr3[33] = "Caderno";        arr3[43] = "Caneca";
            arr3[34] = "Armário";        arr3[44] = "Garrafa";
            arr3[35] = "Camisa";         arr3[45] = "Ar condicionado";
            arr3[36] = "Calça";          arr3[46] = "Chinelo";
            arr3[37] = "Televisão 42'";  arr3[47] = "Sapato";
            arr3[38] = "Televisão 48'";  arr3[48] = "Tênis";
            arr3[39] = "Ventilador";     arr3[49] = "Sandalha";

            arr4[0] = "Arno";
            arr4[1] = "Brastemp";
            arr4[2] = "Samsung";
            arr4[3] = "Semp Toshiba";
            arr4[4] = "HP";
            arr4[5] = "Marval";
            arr4[6] = "Santos";
            arr4[7] = "Positivo";
            arr4[8] = "Models";
            arr4[9] = "Calvin Klein";

            for (var i = 0; i <= loop; i++)
            {
                var cli = new Cliente
                {
                    Email = arr[randNum.Next(0, 49)] + arr2[randNum.Next(0, 9)] + "@gmail.com",
                    FirstName = arr[randNum.Next(0, 49)],
                    LastName = arr2[randNum.Next(0, 9)]
                };

                if (i.ToString().Length == 1)
                    cli.Cpf = "0000000000" + i;
                if (i.ToString().Length == 2)
                    cli.Cpf = "000000000" + i;
                if (i.ToString().Length == 3)
                    cli.Cpf = "00000000" + i;
                if (i.ToString().Length == 4)
                    cli.Cpf = "0000000" + i;
                if (i.ToString().Length == 5)
                    cli.Cpf = "000000" + i;

                await contexto.Cliente.AddAsync(cli);
            }
                await contexto.SaveChangesAsync();


            for (int i = 0; i <= loop; i++)
            {
                var loja = new Loja
                {
                    Cnpj = "",
                    NomeFantasia = arr[randNum.Next(0, 49)] + "loja - " + i,
                    PessoaId = randNum.Next(1, loop)
                };

                if (i.ToString().Length == 1)
                    loja.Cnpj = "0000000000" + i;
                if (i.ToString().Length == 2)
                    loja.Cnpj = "000000000" + i;
                if (i.ToString().Length == 3)
                    loja.Cnpj = "00000000" + i;
                if (i.ToString().Length == 4)
                    loja.Cnpj = "0000000" + i;
                if (i.ToString().Length == 5)
                    loja.Cnpj = "000000" + i;

                await contexto.Loja.AddAsync(loja);
            }
                await contexto.SaveChangesAsync();

            for (int i = 0; i < 50000; i++)
            {
                var prod = new Produto
                {
                    Categoria = new Categoria { Nome = arr3[randNum.Next(0, 49)] },
                    Nome = arr3[randNum.Next(0, 49)] + " " + arr4[randNum.Next(0, 9)],
                    LojaId = randNum.Next(1, 500),
                    Preco = randNum.Next(1, 10000)
                };

                await contexto.Produto.AddAsync(prod);
            }
                await contexto.SaveChangesAsync();

            return "";
        }
    }
}
