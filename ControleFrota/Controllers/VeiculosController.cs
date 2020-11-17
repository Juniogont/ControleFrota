using AutoMapper;
using ControleFrota.BLL.Data;
using ControleFrota.BLL.Services;
using ControleFrota.MDL.Enumeradores;
using ControleFrota.MDL.Models;
using ControleFrota.UI.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ControleFrota.UI.Controllers
{
    public class VeiculosController : Controller
    {
        private readonly VeiculosService _veiculos;

        public VeiculosController(VeiculosService veiculos)
        {
            _veiculos = veiculos;
        }

        // GET: Veiculos
        [Authorize]
        public IActionResult Index()
        {
            return View(_veiculos.GetAll());
        }

        public IActionResult Sair()
        {
            return View();
        }

        // GET: Veiculos/Details/5
        public IActionResult Details(string chassi)
        {
            if (string.IsNullOrEmpty(chassi))
            {
                ViewData["Erro"] = "Infomre um chassi para localizar o veículo";
                return View(nameof(Encontrar), new BuscaViewModel());
            }

            var veiculo = _veiculos.FindByChassi(chassi);
            if (veiculo == null)
            {
                ViewData["Erro"] = "Não foi localizado nenhum veículo com esse chassi";
                return View(nameof(Encontrar), new BuscaViewModel());
            }

            return View(veiculo);
        }



        // GET: Veiculos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Veiculos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Chassi,Tipo,NumeroPassageiros,Cor")] VeiculoViewModel veiculo)
        {
            if (ModelState.IsValid)
            {
                byte numPass = 2;
                if (veiculo.Tipo == Tipo.Onibus)
                    numPass = (byte)NumPassageiros.Onibus;
                else
                    numPass = (byte)NumPassageiros.Caminhao;
                var _veiculo = new Veiculo(veiculo.Chassi, veiculo.Tipo, numPass, veiculo.Cor);
                if (_veiculos.Exists(veiculo.Chassi))
                {
                    ViewData["Erro"] = "Já existe um veículo cadastrado com esse chassi";
                    return View(veiculo);
                }
                
                _veiculos.Create(_veiculo);
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculos/Edit/5
        public  IActionResult Editar(BuscaViewModel model)
        {
            if (string.IsNullOrEmpty(model.chassi))
            {
                ViewData["Erro"] = "Infomre um chassi para localizar o veículo";
                return View(nameof(Buscar), new BuscaViewModel());
            }

            var veiculo = _veiculos.FindByChassi(model.chassi);
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Veiculo, VeiculoViewModel>();
            });

            IMapper iMapper = config.CreateMapper();

            var destination = iMapper.Map<Veiculo, VeiculoViewModel>(veiculo);
            if (veiculo == null)
            {
                ViewData["Erro"] = "Não foi localizado nenhum veículo com esse chassi";
                return View(nameof(Buscar), new BuscaViewModel());
            }
            ViewData["Erro"] = "Somente a Cor do veículo pode ser editada.";
            return View(nameof(Edit), destination);
        }

        public IActionResult Buscar()
        {
            ViewData["Erro"] = "Informe um chassi para localizar o veículo";
            return View(new BuscaViewModel());
        }

        public IActionResult Encontrar()
        {
            ViewData["Erro"] = "Informe um chassi para localizar o veículo";
            return View(new BuscaViewModel());
        }

        public IActionResult Deletar()
        {
            ViewData["Erro"] = "Informe um chassi para localizar o veículo";
            return View(new BuscaViewModel());
        }

        // POST: Veiculos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Chassi,Tipo,NumeroPassageiros,Cor")] VeiculoViewModel veiculo)
        {
            if (id != veiculo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var _veiculo = _veiculos.FindByChassi(veiculo.Chassi);
                    _veiculo.SetCor(veiculo.Cor);
                    _veiculos.Update(_veiculo);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VeiculoExists(veiculo.Chassi))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(veiculo);
        }

        // GET: Veiculos/Delete/5
        public  IActionResult Delete(Veiculo veiculo)
        {
            return View(veiculo);
        }

        public IActionResult DeletarVeiculo(BuscaViewModel model)
        {
            if (string.IsNullOrEmpty(model.chassi))
            {
                return View(nameof(Deletar), new BuscaViewModel());
            }

            var veiculo = _veiculos.FindByChassi(model.chassi);
            if (veiculo == null)
            {
                ViewData["Erro"] = "Não foi localizado nenhum veículo com esse chassi";
                return View(nameof(Deletar), new BuscaViewModel());
            }

            return View(nameof(Delete), veiculo);
        }


        // POST: Veiculos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(string chassi)
        {
            var veiculo = _veiculos.FindByChassi(chassi);
            _veiculos.Delete(veiculo);
            return RedirectToAction(nameof(Index));
        }

        private bool VeiculoExists(string chassi)
        {
            return _veiculos.Exists(chassi);
        }

        [HttpPost]
        public byte GetNumeroPassageiros(Tipo tipo)
        {
            if (tipo == Tipo.Onibus)
                return (byte)NumPassageiros.Onibus;
            else
                return (byte)NumPassageiros.Caminhao;
        }
    }
}
