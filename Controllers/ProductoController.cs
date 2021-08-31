using Microsoft.AspNetCore.Mvc;
using MiPrimerAppMVC.Models;
using System.Collections.Generic;
using System;
using MiPrimerAppMVC.Data;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MiPrimerAppMVC.Data.Repository.Interfaces;

namespace MiPrimerAppMVC.Controllers
{
    public class ProductoController : Controller
    {
        private readonly ProductosContext _context;
        private readonly IProductoRepository _productoRepository;
        // public ProductoController(ProductosContext context)
        // {
        //     _context = context;
        // }
        public ProductoController(IProductoRepository productoRepository)
        {
            _productoRepository= productoRepository;
        }
        
        public async  Task<IActionResult> Index()
        {
            //var productos= GetData();
            //var productos = await _context.Productos.ToListAsync();
            var productos = await _productoRepository.GetAll();
           
            return View(productos);
        }
        public IActionResult Inicio()
        {
            return View();
        }

        // GET:localhost:puerto/Producto/Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: localhost:puerto/Producto/Create
        [HttpPost]
        public async Task<IActionResult> Create(Producto producto)
        {
            if(ModelState.IsValid)
            {
                /// agregar logica para grabar en BD
                // producto.FechaDeAlta = DateTime.Now;
                // _context.Add(producto);
                // await _context.SaveChangesAsync();
                var result = await _productoRepository.Create(producto);
                if(result <0)
                {
                    ViewBag.ErrorMessage="Error al guardar los datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage="Modelo no valido";
            return View(producto);

        }
        
        // GET: localhost:puerto/Producto/Edit/2
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if(id==0)
                return NotFound();
            
            var producto = await _productoRepository.GetById(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            if(producto == null)
                return NotFound();
            
            return View(producto);
        }

        // POST: localhost:puerto/Producto/Edit/2
        [HttpPost]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if(id != producto.Id)
                return NotFound();
            
            if(ModelState.IsValid)
            {
                // _context.Update(producto);
                // await _context.SaveChangesAsync();
                var result = await  _productoRepository.Update(producto);
                if(result <= 0)
                {
                    ViewBag.ErrorMessage="Error al guardar los datos";
                    return View(producto);
                }
                return RedirectToAction(nameof(Index));
            }
            ViewBag.ErrorMessage="Modelo no valido";
            return View(producto);
        }
        
        // GET: localhost:puerto/Producto/Delete/2
        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
                return NotFound();

            //var producto = await _context.Productos.FindAsync(id);
            var producto = await _productoRepository.GetById(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            if(producto == null)
                return NotFound();
                    
            return View(producto);
            
        }

        // POST: localhost:puerto/Producto/Delete/2
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
           
            //var producto = await _context.Productos.FindAsync(id);
            //var producto1 = await _context.Productos.FirstOrDefaultAsync(p => p.Id==id);
            // _context.Productos.Remove(producto);
            // await _context.SaveChangesAsync();
            var result = await _productoRepository.DeleteById(id);
            if(result)
            {    
                return RedirectToAction(nameof(Index));
            }
            else
            {
               ViewBag.ErrorMessage="Error al borrar el producto";
               return View(); 
            }

            
        }

        public List<Producto> GetData()
        {
            List<Producto> productos = new List<Producto>();
            productos.Add(new Producto{Id=1,Nombre="Cafe", Descripcion="Cafe en grano", Precio = 201.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=2,Nombre="Cafe colombiano", Descripcion="Cafe en grano colombiano", Precio = 230.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=3,Nombre="Cafe sumatra", Descripcion="Cafe en grano tipo sumatra", Precio = 250.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=4,Nombre="Cafe molido", Descripcion="Cafe en molido fino", Precio = 300.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=5,Nombre="Cafe molido", Descripcion="Cafe en molido medio", Precio = 400.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=6,Nombre="Leche de almendras", Descripcion="Leche de almendras", Precio = 50.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=7,Nombre="Leche", Descripcion="Leche natural de vaca", Precio = 40.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});
            productos.Add(new Producto{Id=8,Nombre="Botella de agua", Descripcion="Botella de agua de 500 ml", Precio = 10.00m, Activo=true,FechaDeAlta = DateTime.Now.AddDays(-1)});

            return productos;
        }
    }
}