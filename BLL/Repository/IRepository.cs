using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Validations;

namespace BLL.Repository
{
    public interface IRepository <TOrigin , TInsert , TUpdate>
    {
        List<TOrigin> GetAll ();
        List<TOrigin> GetAllFilter (Func<TOrigin, bool> func);
        TOrigin GetFilter(Func<TOrigin, bool> func);

        OperationResult Add(TInsert insert);
        OperationResult Update(TUpdate update);
        OperationResult Delete(int id);
    }
}
