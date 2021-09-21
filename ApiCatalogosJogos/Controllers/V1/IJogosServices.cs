using ApiCatalogosJogos.InputModel;
using System.Threading.Tasks;

namespace ApiCatalogosJogos.Controllers.V1
{
    internal interface IJogosServices
    {
        Task Inserir(JogoInputModel jogoInputModel);
    }
}