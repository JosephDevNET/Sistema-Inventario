using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Dto.Categoria;
using BLL.Validations;
using DAL.Db;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace BLL.Repository
{
    public class CategoriaRepository : IRepository<Categorias, CategoriaInsertDTO, CategoriaUpdateDTO>
    {
        public List<Categorias> GetAll()
        {
            try
            {
                using (TiendaEntities entities = new TiendaEntities())
                {
                    var result = entities.Categorias.ToList();
                    return result;
                }
            }catch
            {
                return null;
            }
        }
        public List<Categorias> GetAllFilter(Func<Categorias, bool> func)
        {
            try
            {
                using (TiendaEntities context = new TiendaEntities())
                {
                    return context.Categorias.Where(func).ToList();
                }
            }
            catch
            {
                return null;
            }
        }

        public Categorias GetFilter(Func<Categorias, bool> func)
        {
            try
            {
                using (TiendaEntities context = new TiendaEntities())
                {
                    return context.Categorias.FirstOrDefault(func);
                }
            }
            catch
            {
                return null;
            }
        }
        public OperationResult Add(CategoriaInsertDTO insert)
        {
            try
            {
                if(insert == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Nueva categoria no puede ser null."
                    };
                }

                if(insert.Nombre != string.Empty && insert.Descripcion != string.Empty)
                {
                    var NewCategory = new Categorias
                    {
                        Nombre = insert.Nombre,
                        Descripcion = insert.Descripcion
                    };

                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Categorias.Add(NewCategory);
                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Nueva categoria ingresada con exito."
                    };
                }
                else
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Ambos campos son necesarios."
                    };
                }

            }catch(Exception ex)
            {
                return new OperationResult()
                {
                    Success = false,
                    ErrorMessage = ex.ToString()
                };
            }
        }
        public OperationResult Update(CategoriaUpdateDTO update)
        {
            try
            {
                var categoria = this.GetFilter(p => p.ID == update.ID);
                if (categoria == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "No puede ser null."
                    };
                }
                else
                {
                    if (update.Nombre != string.Empty || update.Descripcion != string.Empty)
                    {
                        categoria.Nombre = update.Nombre ?? categoria.Nombre;
                        categoria.Descripcion = update.Descripcion ?? categoria.Descripcion;
                        using (TiendaEntities entities = new TiendaEntities())
                        {
                            entities.Categorias.Attach(categoria);
                            entities.Entry(categoria).Property(x => x.Nombre).IsModified = true;
                            entities.Entry(categoria).Property(x => x.Descripcion).IsModified = true;
                            entities.SaveChanges();
                        }

                        return new OperationResult()
                        {
                            Success = true,
                            ErrorMessage = "Categoria actualizada con exito."
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
                var categoria = this.GetFilter(p => p.ID == id);
                if (categoria == null)
                {
                    return new OperationResult()
                    {
                        Success = false,
                        ErrorMessage = "Categoria no encontrada."
                    };
                }
                else
                {
                    using (TiendaEntities entities = new TiendaEntities())
                    {
                        entities.Categorias.Attach(categoria);
                        entities.Categorias.Remove(categoria);
                        entities.SaveChanges();
                    }

                    return new OperationResult()
                    {
                        Success = true,
                        ErrorMessage = "Categoria eliminada con exito."
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
