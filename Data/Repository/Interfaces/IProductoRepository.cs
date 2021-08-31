using System.Collections.Generic;
using System.Threading.Tasks;
using MiPrimerAppMVC.Models;

namespace MiPrimerAppMVC.Data.Repository.Interfaces
{
    public interface IProductoRepository
    {
         Task<IEnumerable<Producto>> GetAll();

         // GetByID
         Task<Producto> GetById(int Id);
        // Create
        Task<int> Create(Producto producto);
        // Update
        Task<int> Update(Producto producto);

        // Delete
        Task<bool> DeleteById(int Id);
    }
}