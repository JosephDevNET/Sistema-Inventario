using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.NewFolder1.Producto;
using BLL.Validations;
using DAL.Db;

namespace BLL.Repository
{
    public class ProductoRepository : IRepository<Productos, ProductoInsertDTO, ProductoUpdateDTO>
    {
        public List<Productos> GetAll()
        {
            try
            {
                using (TiendaEntities entities = new TiendaEntities())
                {
                    var result = entities.Productos.ToList();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }
        public List<Productos> GetAllFilter(Func<Productos, bool> func)
        {
            try
            {
                var productos = this.GetAll();
                return productos.Where(func).ToList();
            }
            catch
            {
                return null;
            }
        }
        public Productos GetFilter(Func<Productos, bool> func)
        {
            try
            {
                var producto = this.GetAll();
                return producto.FirstOrDefault(func);
            }
            catch
            {
                return null;
            }
        }

        public OperationResult Add(ProductoInsertDTO insert)
        {
            try
            {
                if (insert == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Nuevo Producto no puede ser null."
                    };
                }
                var categoria = new CategoriaRepository();
                var proveedor = new ProveedorRepository();

                if (categoria.GetFilter(p => p.ID == insert.CategoriaID) == null || proveedor.GetFilter(p => p.ID == insert.ProveedorID) == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "La categoria o el proveedor no se ha encontrado o no existe."
                    };
                }
                else
                {

                    if (insert.Nombre != string.Empty && insert.Precio > 0
                        && insert.Stock > 0 )
                    {
                        var NewProducto = new Productos
                        {
                            Nombre = insert.Nombre,
                            Precio = insert.Precio,
                            Stock = insert.Stock,
                            ProveedorID = insert.ProveedorID,
                            CategoriaID = insert.CategoriaID
                        };

                        using (TiendaEntities entities = new TiendaEntities())
                        {
                            entities.Productos.Add(NewProducto);
                            entities.SaveChanges();
                        }

                        return new OperationResult()
                        {
                            Success = true,
                            ErrorMessage = "Nuevo producto ingresado con exito."
                        };
                    }
                    else
                    {
                        return new OperationResult()
                        {
                            Success = false,
                            ErrorMessage = "Todos los campos son necesarios."
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new OperationResult()
                {
                    Success = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }
        public OperationResult Update(ProductoUpdateDTO update)
        {
            try
            {
                if (update == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Nuevo Producto no puede ser null."
                    };
                }

                var producto = this.GetFilter(p => p.ID == update.ID);
                if(producto == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Producto no encontrado."
                    };
                }

                var categoria = new CategoriaRepository();
                var proveedor = new ProveedorRepository();

                if (categoria.GetFilter(p => p.ID == update.CategoriaID) == null || proveedor.GetFilter(p => p.ID == update.ProveedorID) == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "La categoria o el proveedor no se ha encontrado o no existe."
                    };
                }
                else
                {
                    if (update.Nombre != string.Empty || update.Precio > 0
                        || update.Stock > 0)
                    {
                        producto.Nombre = string.IsNullOrWhiteSpace(update.Nombre) ? producto.Nombre : update.Nombre;
                        producto.Precio = update.Precio;
                        producto.Stock = update.Stock;
                        producto.ProveedorID = update.ProveedorID;
                        producto.CategoriaID = update.CategoriaID;

                        using (TiendaEntities entities = new TiendaEntities())
                        {
                            entities.Productos.Attach(producto);
                            entities.Entry(producto).Property(x => x.Nombre).IsModified = true;
                            entities.Entry(producto).Property(x => x.Precio).IsModified = true;
                            entities.Entry(producto).Property(x => x.Stock).IsModified = true;
                            entities.Entry(producto).Property(x => x.ProveedorID).IsModified = true;
                            entities.Entry(producto).Property(x => x.CategoriaID).IsModified = true;
                            entities.SaveChanges();
                        }

                        return new OperationResult()
                        {
                            Success = true,
                            ErrorMessage = "Producto actualizado con exito."
                        };
                    }
                    else
                    {
                        return new OperationResult()
                        {
                            Success = false,
                            ErrorMessage = "Todos los campos son necesarios."
                        };
                    }
                }

            }
            catch (Exception ex)
            {
                return new OperationResult()
                {
                    Success = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }
        public OperationResult Delete(int id)
        {
            try
            {
                var producto = this.GetFilter(p => p.ID == id);
                if (producto == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Producto no encontrada."
                    };
                }
                else
                {
                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Productos.Attach(producto);
                        entities.Productos.Remove(producto);
                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Producto eliminado con exito."
                    };
                }
            }
            catch (Exception ex)
            {
                return new OperationResult()
                {
                    Success = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }
    }
}
