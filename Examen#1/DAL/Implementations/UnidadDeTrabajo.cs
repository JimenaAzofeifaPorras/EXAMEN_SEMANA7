using DAL.Interfaces;
using Entitities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Implementations
{
    public class UnidadDeTrabajo : IUnidadDeTrabajo
    {

        public IDistritoDAL _distritoDAL { get; }

        private readonly ExamenContext _context;

        public UnidadDeTrabajo(ExamenContext examenContext,
                                IDistritoDAL distritoDAL
                                )
        {
            _context = examenContext;
            _distritoDAL = distritoDAL;
        }


        public bool Complete()
        {
            try
            {
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}