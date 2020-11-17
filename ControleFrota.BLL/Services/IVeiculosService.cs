using ControleFrota.MDL.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControleFrota.BLL.Services
{
    public interface IVeiculosService
    {

        Veiculo FindByChassi(string chassi);
        bool Exists(string chassi);
        List<Veiculo> GetAll();
        void Delete(Veiculo veiculo);
        bool Create(Veiculo veiculo);
        void Update(Veiculo veiculo);
    }
}
