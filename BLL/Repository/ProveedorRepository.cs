using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Proveedor;
using BLL.Validations;
using DAL.Db;

namespace BLL.Repository
{
    public class ProveedorRepository : IRepository<Proveedores, ProveedorInsertDTO, ProveedorUpdateDTO>
    {
        public List<Proveedores> GetAll()
        {
            try
            {
                using (TiendaEntities entities = new TiendaEntities())
                {
                    var result = entities.Proveedores.ToList();
                    return result;
                }
            }
            catch
            {
                return null;
            }
        }

        public List<Proveedores> GetAllFilter(Func<Proveedores, bool> func)
        {
            try
            {
                using (TiendaEntities context = new TiendaEntities())
                {
                    return context.Proveedores.Where(func).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public Proveedores GetFilter(Func<Proveedores, bool> func)
        {
            try
            {
                using (TiendaEntities context = new TiendaEntities())
                {
                    return context.Proveedores.FirstOrDefault(func);
                }
            }
            catch
            {
                return null;
            }
        }
        public OperationResult Add(ProveedorInsertDTO insert)
        {
            try
            {
                if (insert == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Nuevo Proveedor no puede ser null."
                    };
                }

                if (insert.Nombre != string.Empty && insert.Contacto != string.Empty
                    && !string.IsNullOrEmpty(insert.Telefono) && !string.IsNullOrEmpty(insert.Email)
                    && !string.IsNullOrEmpty(insert.Direccion))
                {
                    var NewProveedor = new Proveedores
                    {
                        Nombre = insert.Nombre,
                        Contacto = insert.Contacto,
                        Telefono = insert.Telefono,
                        Email = insert.Email,
                        Direccion = insert.Direccion,
                        FechaRegistro = DateTime.Now
                    };

                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Proveedores.Add(NewProveedor);
                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Nuevo proveedor ingresado con exito."
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
            catch (Exception ex)
            {
                return new OperationResult()
                {
                    Success = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }
        public OperationResult Update(ProveedorUpdateDTO update)
        {
            try
            {
                var proveedor = this.GetFilter(p => p.ID == update.ID);

                if (update == null || proveedor == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Proveedor no puede ser null."
                    };
                }

                if (update.Nombre != string.Empty || update.Contacto != string.Empty
                    || !string.IsNullOrEmpty(update.Telefono)|| !string.IsNullOrEmpty(update.Email)
                    || !string.IsNullOrEmpty(update.Direccion))
                {
                    proveedor.Nombre = update.Nombre ?? proveedor.Nombre;
                    proveedor.Contacto = update.Contacto ?? proveedor.Contacto;
                    proveedor.Telefono = update.Telefono ?? proveedor.Telefono;
                    proveedor.Email = update.Email ?? proveedor.Email;
                    proveedor.Direccion = update.Direccion ?? proveedor.Direccion;

                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Proveedores.Attach(proveedor);
                        entities.Entry(proveedor).Property(x => x.Nombre).IsModified = true;
                        entities.Entry(proveedor).Property(x => x.Contacto).IsModified = true;
                        entities.Entry(proveedor).Property(x => x.Telefono).IsModified = true;
                        entities.Entry(proveedor).Property(x => x.Email).IsModified = true;
                        entities.Entry(proveedor).Property(x => x.Direccion).IsModified = true;

                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Proveedor actualizado con exito."
                    };
                }
                else
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Almenos un campo es necesario."
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
        public OperationResult Delete(int id)
        {
            try
            {
                var proveedor = this.GetFilter(p => p.ID == id);
                if (proveedor == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Proveedor no encontrada."
                    };
                }
                else
                {
                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Proveedores.Attach(proveedor);
                        entities.Proveedores.Remove(proveedor);
                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Proveedor eliminado con exito."
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
