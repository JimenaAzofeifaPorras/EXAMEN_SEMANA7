using BackEnd.Models;

namespace BackEnd.Services.Interfaces
{
    public interface IDistritoService
    {
        IEnumerable<DistritoModel> GetDistritos();
        DistritoModel GetById(int id);
        bool AddDistrito(DistritoModel distrito);
        bool UpdateDistrito(DistritoModel distrito);
        bool DeteleDistrito(DistritoModel cmpleado);


    }
}