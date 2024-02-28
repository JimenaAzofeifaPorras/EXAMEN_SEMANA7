using DAL.Interfaces;
using Entitities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class DistritoDALImpl : DALGenericoImpl<Distrito>, IDistritoDAL
    {
        ExamenContext _context;

        public DistritoDALImpl(ExamenContext context) : base(context)
        {
            _context = context;
        }


    }
}