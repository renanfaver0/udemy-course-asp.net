using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SistemaMVC_lanches.Context;
using SistemaMVC_lanches.Models;
using SistemaMVC_lanches.Repositories.Interfaces;

namespace SistemaMVC_lanches.Repositories
 {
    public class CategoriaRepository : ICategoriaRepository
    {
         private readonly AppDbContext _context;
         
         public CategoriaRepository(AppDbContext context)
         {
            _context = context;
         }

        public IEnumerable<Categoria> Categorias => _context.Categorias;
    }

}