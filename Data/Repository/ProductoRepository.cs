using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data.Repository.Interfaces;
using MiPrimerAppMVC.Models;


namespace MiPrimerAppMVC.Data.Repository
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly ProductosContext _context;
        public ProductoRepository(ProductosContext context)
        {
            _context= context;
        }
        public async Task<IEnumerable<Producto>> GetAll()
        {
            var productos = await _context.Productos.ToListAsync();
            return productos;
        }

        // GetByID
        public async Task<Producto> GetById(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            return producto;
        }
        // Create
        public async Task<int> Create(Producto producto)
        {
            producto.FechaDeAlta = DateTime.Now;
             _context.Add(producto);
            return await _context.SaveChangesAsync();
        }
        // Update
        public async Task<int> Update(Producto producto)
        {
            _context.Update(producto);
            return await _context.SaveChangesAsync();
        }
        // Delete
        public async Task<bool> DeleteById(int Id)
        {
            var producto = await _context.Productos.FindAsync(Id);
            _context.Productos.Remove(producto);
            if(await _context.SaveChangesAsync()>=0)
                return true;
            
            return false;
        }
    }
}