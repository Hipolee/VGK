using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.Jeux;
namespace Model
{
    public interface IDataManager
    {
        

        void Add(object obj);

        void Remove(object obj);

        void Update(object obj);
    }
}
