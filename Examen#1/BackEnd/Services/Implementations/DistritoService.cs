using BackEnd.Models;
using BackEnd.Services.Interfaces;
using DAL.Interfaces;
using Entitities.Entities;


namespace BackEnd.Services.Implementations
{
    public class DistritoService : IDistritoService
    {

        public IUnidadDeTrabajo _unidadDeTrabajo;

        public DistritoService(IUnidadDeTrabajo unidadDeTrabajo)
        {
            _unidadDeTrabajo = unidadDeTrabajo;
        }



        public bool AddDistrito(DistritoModel distrito)
        {
            Distrito entity = Convertir(distrito);
            _unidadDeTrabajo._distritoDAL.Add(entity);
            return _unidadDeTrabajo.Complete();
        }

        DistritoModel Convertir(Distrito distrito)
        {
            return new DistritoModel
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
            };
        }

        Distrito Convertir(DistritoModel distrito)
        {
            return new Distrito
            {
                DistritoId = distrito.DistritoId,
                Nombre = distrito.Nombre,
            };
        }
        public bool DeteleDistrito(DistritoModel distrito)
        {
            Distrito entity = Convertir(distrito);
            _unidadDeTrabajo._distritoDAL.Remove(entity);
            return _unidadDeTrabajo.Complete();
        }

        public DistritoModel GetById(int id)
        {
            var entity = _unidadDeTrabajo._distritoDAL.Get(id);

            DistritoModel distritoModel = Convertir(entity);
            return distritoModel;
        }

        public IEnumerable<DistritoModel> GetDistritos()
        {

            var result = _unidadDeTrabajo._distritoDAL.GetAll();
            List<DistritoModel> lista = new List<DistritoModel>();
            foreach (var distrito in result)
            {
                lista.Add(Convertir(distrito));


            }
            return lista;
        }

        public bool UpdateDistrito(DistritoModel distrito)
        {
            Distrito entity = Convertir(distrito);
            _unidadDeTrabajo._distritoDAL.Update(entity);
            return _unidadDeTrabajo.Complete();
        }
    }
}