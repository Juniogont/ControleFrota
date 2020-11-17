using ControleFrota.BLL.Data;
using ControleFrota.MDL.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControleFrota.BLL.Services
{
    public class VeiculosService : IVeiculosService
    {
        private readonly ControleFrotaContext _context;

        public VeiculosService(ControleFrotaContext context)
        {
            _context = context;
        }

        public Veiculo FindByChassi(string chassi)
        {
            return _context.Veiculos.FirstOrDefault(x => x.Chassi == chassi);
        }

        public bool Exists(string chassi)
        {
            return _context.Veiculos.Any(e => e.Chassi == chassi);
        }

        public List<Veiculo> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public void Delete(Veiculo veiculo)
        {
            _context.Veiculos.Remove(veiculo);
            _context.SaveChanges();
        }
        public bool Create(Veiculo veiculo)
        {
            var existe = _context.Veiculos.FirstOrDefault(x => x.Chassi == veiculo.Chassi);
            if (existe != null)
                throw new InvalidOperationException("Já existe um veículo cadastrado com  esse Chassi.");
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
            return true;
        }

        public void Update(Veiculo veiculo)
        {
            _context.Veiculos.Update(veiculo);
            _context.SaveChanges();
        }
    }
}
