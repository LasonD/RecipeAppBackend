using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RecipesAppApiFull.Dtos
{
    public abstract class DtoBase<TId>
    {
        public TId Id { get; set; }
    }
}
